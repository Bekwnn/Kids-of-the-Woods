using System;

[Serializable]
public class JGatheringComponentInfo
{
    public float gatherSpeed;
    public float gatherYield;
}

/// <summary>
/// The KUnit component which handles various methods of gathering different resources.
/// </summary>
public class KGatheringComponent : KUnitComponent
{
    public KBuffableStat gatherSpeed;
    public KBuffableStat gatherYield;

    public override void Initialize()
    {
        base.Initialize();

        JGatheringComponentInfo info = ReadJson<JGatheringComponentInfo>("gathering");

        //assign values from json info
        gatherSpeed = new KBuffableStat(info.gatherSpeed);
        gatherYield = new KBuffableStat(info.gatherYield);
    }

    public void GatherResource(KResource target)
    {
        //TODO
    }
}
