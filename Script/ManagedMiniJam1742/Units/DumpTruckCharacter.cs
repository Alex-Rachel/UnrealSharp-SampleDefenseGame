using ManagedMiniJam1742.AI;
using ManagedMiniJam1742.AI.Tasks;
using ManagedMiniJam1742.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnrealSharp.AIModule;
using UnrealSharp.Attributes;
using UnrealSharp.CoreUObject;
using UnrealSharp.Engine;
using UnrealSharp.NavigationSystem;
using UnrealSharp.Niagara;

namespace ManagedMiniJam1742.Units;

[UClass]
public class ADumpTruckCharacter : AUnitCharacter
{
    [UProperty(PropertyFlags.EditAnywhere | PropertyFlags.BlueprintReadWrite)]
    public int CarryingPlastic { get; set; }

    [UProperty(PropertyFlags.EditAnywhere | PropertyFlags.BlueprintReadWrite)]
    public int CarryingPlasticLimit { get; set; } = 100;

    private int previousCarryingPlastic;

    public UNiagaraComponent HarvestBeamComponent { get; private set; }

    private APlasticResource targetResource;
    private AAdvancedAIController aiController;

    [UFunction(FunctionFlags.BlueprintEvent)]
    public void OnCarryPlasticChanged() { }

    protected override void BeginPlay()
    {
        base.BeginPlay();

        HarvestBeamComponent = GetComponentByClass<UNiagaraComponent>();

        if (Controller is not AAdvancedAIController aiController) return;
        this.aiController = aiController;
    }

    public override void Tick(float deltaSeconds)
    {
        base.Tick(deltaSeconds);

        if (CarryingPlastic != previousCarryingPlastic)
        {
            OnCarryPlasticChanged();
            previousCarryingPlastic = CarryingPlastic;
        }
    }

    public override void GoToActor(AActor actor)
    {
        if (actor is APlasticResource plasticResource)
        {
            aiController.StopTasks();

            var task = aiController.CreateTask<UHarvestPlasticTask>();
            task.Target = plasticResource;
            aiController.AddTask(task);
        }
        else
        {
            aiController.StopTasks();
        }
    }
}
