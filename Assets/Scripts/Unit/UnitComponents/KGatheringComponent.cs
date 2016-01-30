using System;
using UnityEngine;

[Serializable]
public class JGatheringComponentInfo
{
    public float gatherSpeed;
    public float gatherYield;
    public float gatherRange;
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

    [HideInInspector]
    public KBuffableStat gatherRange;

    public KUnitAnimations animations;

    public override void Initialize()
    {
        base.Initialize();

        JGatheringComponentInfo info = ReadJson<JGatheringComponentInfo>("gathering");

        //assign values from json info
        gatherSpeed = new KBuffableStat(info.gatherSpeed);
        gatherYield = new KBuffableStat(info.gatherYield);
        gatherRange = new KBuffableStat(info.gatherRange);
    }

    protected override void Reset()
    {
        base.Reset();
        if (animations == null)
            animations = GetComponent<KUnitAnimations>();
    }

    public void GatherResource(KUnit target)
    {
        if (target == unit) return;
        Debug.Log("Attempting to gather target");
        StartGather();
    }

    protected void StartGather()
    {
        //TODO
        animations.StartGather();
    }

    protected void LaunchGather()
    {
        //TODO
        Debug.Log("launching gather");
    }
}
