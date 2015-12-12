using System;
using System.IO;
using UnityEngine;

[Serializable]
public class BuildComponentInfo
{
    public float buildSpeed;
}

public class KBuildComponent : KUnitComponent
{
    public KBuffableStat buildSpeed;

    public override void Initialize()
    {
        base.Initialize();

        BuildComponentInfo info = ReadJson<BuildComponentInfo>("build");

        //assign values from json info
        buildSpeed = new KBuffableStat(info.buildSpeed);
    }

    public void Build(KStructure structure)
    {
        //TODO
    }
}
