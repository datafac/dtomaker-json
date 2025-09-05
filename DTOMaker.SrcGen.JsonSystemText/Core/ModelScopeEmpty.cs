﻿using System.Collections.Generic;

namespace DTOMaker.SrcGen.Core
{
    public sealed class ModelScopeEmpty : IModelScope
    {
        private static readonly ModelScopeEmpty _instance = new ModelScopeEmpty();
        public static ModelScopeEmpty Instance => _instance;

        public IReadOnlyDictionary<string, object?> Tokens { get; } = new Dictionary<string, object?>();

        private ModelScopeEmpty() { }
    }
}