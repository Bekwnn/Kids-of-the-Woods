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

    public void GatherResource(KResource target)
    {
        //TODO
    }
}
