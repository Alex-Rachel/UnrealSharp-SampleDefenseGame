using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealSharp.Attributes;
using UnrealSharp.Engine;

namespace ManagedMiniJam1742;

[UClass]
public class AMusicManager : AActor
{
    [UProperty(PropertyFlags.EditAnywhere, DefaultComponent = true)]
    public UAudioComponent AudioComponent { get; set; }

    [UProperty(PropertyFlags.EditAnywhere)]
    public USoundWave Music { get; set; }

    private TimeSpan nextPlayTime;

    protected override void BeginPlay()
    {
        base.BeginPlay();

        nextPlayTime = TimeSpan.FromSeconds(TimeSeconds + 10);
    }

    public override void Tick(float deltaSeconds)
    {
        base.Tick(deltaSeconds);

        if (!AudioComponent.IsPlaying() && TimeSpan.FromSeconds(TimeSeconds) >= nextPlayTime)
        {
            AudioComponent.Sound = Music;
            AudioComponent.Play();

            nextPlayTime = TimeSpan.FromSeconds(TimeSeconds + Music.Duration + 30);
        }
    }
}
