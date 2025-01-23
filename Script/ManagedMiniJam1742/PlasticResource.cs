using ManagedMiniJam1724;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using UnrealSharp.Attributes;
using UnrealSharp.Engine;

namespace ManagedMiniJam1742;

[UClass]
public class APlasticResource : AActor
{
    [UProperty(PropertyFlags.EditAnywhere, DefaultComponent = true, RootComponent = true)]
    public UStaticMeshComponent StaticMeshComponent { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public int Plastic { get; set; } = 1000;

    private AResourceManager resourceManager;

    protected override void BeginPlay()
    {
        base.BeginPlay();

        resourceManager = GetActorOfClass<AResourceManager>();
    }

    public int Harvest(int amount)
    {
        if (StaticMeshComponent != null)
        {
            if (resourceManager != null)
            {
                StaticMeshComponent.OverlayMaterial = resourceManager.DissolveMaterial;
            }
        }

        int maxCanHarvest = Math.Min(amount, Plastic);

        Plastic -= maxCanHarvest;

        if (Plastic <= 0)
        {
            DestroyActor();
        }

        return maxCanHarvest;
    }

    public void StopHarvesting()
    {
        if (StaticMeshComponent != null)
        {
            if (resourceManager != null)
            {
                StaticMeshComponent.OverlayMaterial = null;
            }
        }
    }
}
