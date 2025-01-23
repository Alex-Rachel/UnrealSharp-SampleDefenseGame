using ManagedMiniJam1742.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealSharp;
using UnrealSharp.Attributes;
using UnrealSharp.CoreUObject;
using UnrealSharp.Engine;
using UnrealSharp.EnhancedInput;

namespace ManagedMiniJam1724;

[UClass]
public class AResourceManager : AActor
{
    public static AResourceManager Get()
    {
        return GetActorOfClass<AResourceManager>();
    }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UInputMappingContext MappingContext { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UInputAction MoveAction { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UInputAction PrimaryAction { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UInputAction SecondaryAction { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UMaterial DissolveMaterial { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public TArray<USoundWave> UnitConfirmationSounds { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public USoundWave StructureBuiltConfirmationSound { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UMaterial YellowPlastic { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UMaterial GreenPlastic { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public TSubclassOf<ASoldierCharacter> SoldierUnitClass { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UMaterial GhostMaterial { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public UMaterialParameterCollection GhostMaterialParams { get; set; }
}
