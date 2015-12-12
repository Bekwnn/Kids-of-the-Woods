using System;

[Serializable]
public class BuildComponentInfo
{
    public float buildSpeed;
}

public class KBuildComponent : KUnitComponent
{
    public KBuffableStat buildSpeed;

	public void Build(KStructure structure)
    {
        //TODO
    }
}
