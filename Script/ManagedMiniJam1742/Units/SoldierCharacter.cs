using ManagedMiniJam1742.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealSharp.Attributes;
using UnrealSharp.Engine;

namespace ManagedMiniJam1742.Units;

[UClass]
public class ASoldierCharacter : AUnitCharacter
{

    protected override void BeginPlay()
    {
        base.BeginPlay();

        var animator = GetComponentByClass<UAnimatedSceneComponent>();

        // UObjects are broken and dont save in editor
        if (animator != null)
        {
            animator.Animation = typeof(UWobbleAnimation);
        }
    }
}
