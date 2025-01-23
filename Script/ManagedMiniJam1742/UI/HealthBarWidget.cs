using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealSharp.Attributes;
using UnrealSharp.UMG;

namespace ManagedMiniJam1742.UI;

[UClass]
public class UHealthBarWidget : UUserWidget
{
    [UProperty(PropertyFlags.BlueprintReadWrite)]
    public float HealthPercentage { get; set; }
}
