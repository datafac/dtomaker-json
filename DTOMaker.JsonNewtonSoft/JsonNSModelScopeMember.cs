﻿using DTOMaker.Gentime;

namespace DTOMaker.JsonSystemText
{
    public sealed class JsonNSModelScopeMember : ModelScopeMember
    {
        public JsonNSModelScopeMember(IModelScope parent, IScopeFactory factory, ILanguage language, TargetMember member)
            : base(parent, factory, language, member)
        {
        }
    }
}
