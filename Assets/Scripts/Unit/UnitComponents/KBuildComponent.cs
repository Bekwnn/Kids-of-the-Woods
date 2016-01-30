using System;
using System.IO;
using UnityEngine;

[Serializable]
public class JBuildComponentInfo
{
    public float buildSpeed;
}

/// <summary>
/// The KUnit component which keeps track of a unit's building abilities.
/// </summary>
public class KBuildComponent : KUnitComponent
{
    [HideInInspector]
    public KBuffableStat buildSpeed;

    public override void Initialize()
    {
        base.Initialize();

        JBuildComponentInfo info = ReadJson<JBuildComponentInfo>("build");

        //assign values from json info
        buildSpeed = new KBuffableStat(info.buildSpeed);
    }

    public void Build(KStructureComponent structure)
    {
        //TODO
    }
}
