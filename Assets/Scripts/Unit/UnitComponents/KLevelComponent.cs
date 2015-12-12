using UnityEngine;
using System.Collections;


public class KLevelComponent : KUnitComponent
{
    public int level;
    public KBuffableStat experienceGainRate;
    public KBuffableStat experienceRadius;
    public float experienceToNextLevel;
    public float currentExperience;

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
