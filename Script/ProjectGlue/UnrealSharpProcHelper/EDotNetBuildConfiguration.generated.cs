using UnrealSharp.Attributes;
using UnrealSharp.Core.Attributes;
using UnrealSharp.Interop;
using UnrealSharp.Core.Marshallers;

namespace UnrealSharp.UnrealSharpProcHelper;

[UEnum, GeneratedType("EDotNetBuildConfiguration", "UnrealSharp.UnrealSharpProcHelper.EDotNetBuildConfiguration")]
public enum EDotNetBuildConfiguration : ulong
{
    Debug = 0,
    Release = 1,
    Publish = 2,
}