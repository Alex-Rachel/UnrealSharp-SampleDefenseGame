using ManagedMiniJam1724;
using ManagedMiniJam1742.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealSharp.Attributes;
using UnrealSharp.CoreUObject;
using UnrealSharp.Engine;
using UnrealSharp.UMG;

namespace ManagedMiniJam1742;

[UClass]
public class AStructure : AActor
{
    [UProperty(PropertyFlags.EditAnywhere, DefaultComponent = true, RootComponent = true)]
    public UStaticMeshComponent StaticMeshComponent { get; set; }

    [UProperty(PropertyFlags.EditAnywhere | PropertyFlags.BlueprintReadWrite, DefaultComponent = true, AttachmentComponent = nameof(StaticMeshComponent))]
    public UWidgetComponent HealthBarComponent { get; set; }

    [UProperty(PropertyFlags.BlueprintReadWrite)]
    public ETeam Team { get; set; }

    [UProperty(PropertyFlags.BlueprintReadWrite)]
    public float Health { get; set; }

    [UProperty(PropertyFlags.BlueprintReadWrite)]
    public int Cost { get; set; }

    private AResourceManager resourceManager;


    private float initialHealth;
    private double healthBarVisibleUtillTimestamp;

    public override void ConstructionScript()
    {
        base.ConstructionScript();

        resourceManager = AResourceManager.Get();

        if (resourceManager == null) return;

        var staticMeshComponents = GetComponentsByClass<UStaticMeshComponent>();
        foreach (var staticMeshComponent in staticMeshComponents)
        {
            for (int i = 0; i < staticMeshComponent.NumMaterials; i++)
            {
                if (Team == ETeam.Green)
                {
                    staticMeshComponent.SetMaterial(i, resourceManager.GreenPlastic);
                }
                else if (Team == ETeam.Yellow)
                {
                    staticMeshComponent.SetMaterial(i, resourceManager.YellowPlastic);
                }
            }
        }
    }

    protected override void BeginPlay()
    {
        base.BeginPlay();

        initialHealth = Health;

        UpdateHealthUI();
    }

    [UFunction(FunctionFlags.BlueprintEvent)]
    public virtual void OnBuilt() 
    {
        PlaySound2D(resourceManager.StructureBuiltConfirmationSound);
    }

    [UFunction(FunctionFlags.BlueprintEvent)]
    public void OnTakeDamage(AActor attacker)
    {

    }

    [UFunction(FunctionFlags.BlueprintCallable)]
    public void ChangeTeam(ETeam newTeam)
    {
        var primitiveComponents = GetComponentsByClass<UPrimitiveComponent>();
        foreach (var primitiveComponent in primitiveComponents)
        {
            for (int i = 0; i < primitiveComponent.NumMaterials; i++)
            {
                if (newTeam == ETeam.Green)
                {
                    primitiveComponent.SetMaterial(i, resourceManager.GreenPlastic);
                }
                else if (newTeam == ETeam.Yellow)
                {
                    primitiveComponent.SetMaterial(i, resourceManager.YellowPlastic);
                }
            }
        }

        Team = newTeam;
    }

    public void UpdateHealthUI(bool uiVisible = false)
    {
        if (HealthBarComponent.Widget is not UHealthBarWidget healthBarWidget) return;

        healthBarWidget.HealthPercentage = Health / initialHealth;

        HealthBarComponent.SetVisibility(uiVisible);

        healthBarVisibleUtillTimestamp = TimeSeconds + 2.0;
    }
}
