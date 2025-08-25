﻿using Microsoft.CodeAnalysis;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DTOMaker.SrcGen.Core
{
    public abstract class TargetDomain : TargetBase
    {
        public string Name { get; }
        public ConcurrentDictionary<string, TargetEntity> OpenEntities { get; } = new ConcurrentDictionary<string, TargetEntity>();
        public ConcurrentDictionary<string, TargetEntity> ClosedEntities { get; } = new ConcurrentDictionary<string, TargetEntity>();
        public TargetDomain(string name, Location location) : base(location)
        {
            Name = name;
        }

        private SyntaxDiagnostic? CheckEntityIdsAreUnique()
        {
            var idMap = new Dictionary<int, TargetEntity>();

            foreach (var entity in this.ClosedEntities.Values.OrderBy(e => e.TFN.FullName))
            {
                int id = entity.EntityId;
                if (idMap.TryGetValue(id, out var otherEntity))
                {
                    return new SyntaxDiagnostic(
                        DiagnosticId.DTOM0009, "Duplicate entity id", DiagnosticCategory.Design, Location, DiagnosticSeverity.Error,
                        $"Entity id ({id}) is already used by entity: {otherEntity.TFN}");
                }
                idMap[id] = entity;
            }

            return null;
        }

        protected override IEnumerable<SyntaxDiagnostic> OnGetValidationDiagnostics()
        {
            SyntaxDiagnostic? diagnostic;
            if ((diagnostic = CheckEntityIdsAreUnique()) is not null) yield return diagnostic;
        }
    }
}
