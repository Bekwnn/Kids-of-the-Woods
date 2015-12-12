using System;

[Serializable]
public class GatheringComponentInfo
{
    public float gatherSpeed;
    public float gatherYield;
}

public class KGatheringComponent : KUnitComponent
{
    public KBuffableStat gatherSpeed;
    public KBuffableStat gatherYield;

    public override void Initialize()
    {
        base.Initialize();

        GatheringComponentInfo info = ReadJson<GatheringComponentInfo>("gathering");

        //assign values from json info
        gatherSpeed = new KBuffableStat(info.gatherSpeed);
        gatherYield = new KBuffableStat(info.gatherYield);
    }

    public void GatherResource(KResource target)
    {
        //TODO
    }
}
