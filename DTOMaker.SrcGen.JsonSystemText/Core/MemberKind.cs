﻿namespace DTOMaker.SrcGen.Core
{
    public enum MemberKind
    {
        Unknown,
        Native,
        Entity,
        Binary,
        String,
        Vector, // todo replace with Rank (0=scalar, 1=vector, 2=matrix, 3=tensor, etc.)
    }
}