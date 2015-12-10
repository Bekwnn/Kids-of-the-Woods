using UnityEngine;
using System.Collections;

//growth rate of defensive component stats (armor, hp, etc)
public struct FDefenseGrowth
{
    //TODO
}

//growth rate of offensive component stats (damage, attack speed, etc)
public struct FAttackGrowth
{
    //TODO
}

//growth rate of ability component stats (mana, regen, etc)
public struct FAbilityGrowth
{
    //TODO
}

public class KLevelComponent : KUnitComponent
{
    public int level;
    public KBuffableStat experienceGainRate;
    public KBuffableStat experienceRadius;
    public float experienceToNextLevel;
    public float currentExperience;

    public FDefenseGrowth defenseGrowth;
    public FAttackGrowth attackGrowth;
    public FAbilityGrowth abilityGrowth;

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
