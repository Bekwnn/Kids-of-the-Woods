using System;
using UnityEngine;

[Serializable]
public class JGatheringComponentInfo
{
    public float gatherSpeed;
    public float gatherYield;
}

public struct FGatherInfo
{
    public KUnit unit;
    public int yield;
}

/// <summary>
/// The KUnit component which handles various methods of gathering different resources.
/// </summary>
public class KGatheringComponent : KUnitComponent
{
    [HideInInspector]
    public KBuffableStat gatherSpeed;

    [HideInInspector]
    public KBuffableStat gatherYield;

    public override void Initialize()
    {
        base.Initialize();

        JGatheringComponentInfo info = ReadJson<JGatheringComponentInfo>("gathering");

        //assign values from json info
        gatherSpeed = new KBuffableStat(info.gatherSpeed);
        gatherYield = new KBuffableStat(info.gatherYield);
    }

    public void GatherResource(KResourceComponent target)
    {
        //TODO
    }
}
