using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class JLevelComponentInfo
{
    public float experienceGainRate;
    public float experienceRadius;
}

/// <summary>
/// Handles the KUnit's experience and leveling up.
/// </summary>
public class KLevelComponent : KUnitComponent
{
    public int level;

    [HideInInspector]
    public KBuffableStat experienceGainRate;

    [HideInInspector]
    public KBuffableStat experienceRadius;

    public float experienceToNextLevel;
    public float currentExperience;

    public override void Initialize()
    {
        base.Initialize();

        JLevelComponentInfo info = ReadJson<JLevelComponentInfo>("defensive");

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
		KAbilityComponent abil = GetComponent<KAbilityComponent>();
		if (abil) abil.availableSkillPoints++;
    }

    public void SetLevelTo(int val)
    {
        //TODO: set level and de-allocate all skill points to be re-allocated
    }
}
