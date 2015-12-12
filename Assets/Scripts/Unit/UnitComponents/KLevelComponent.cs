using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class LevelComponentInfo
{
    public float experienceGainRate;
    public float experienceRadius;
}

public class KLevelComponent : KUnitComponent
{
    public int level;
    public KBuffableStat experienceGainRate;
    public KBuffableStat experienceRadius;
    public float experienceToNextLevel;
    public float currentExperience;

    public override void Initialize()
    {
        base.Initialize();

        LevelComponentInfo info = ReadJson<LevelComponentInfo>("defensive");

        //assign values from json info
        experienceGainRate = new KBuffableStat(info.experienceGainRate);
        experienceRadius = new KBuffableStat(info.experienceRadius);
    }

    public void GainExperience(float amount)
    {
        //TODO
    }

    public void LevelUp()
    {
        //TODO
    }

    public void SetLevelTo(int val)
    {
        //TODO: set level and de-allocate all skill points to be re-allocated
    }
}
