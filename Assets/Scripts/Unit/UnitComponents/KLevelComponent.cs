using UnityEngine;
using System.Collections;

//growth rate of defensive component stats (armor, hp, etc)
public struct FDefenseGrowth
{

}

//growth rate of offensive component stats (damage, attack speed, etc)
public struct FAttackGrowth
{

}

//growth rate of spell component stats (mana, regen, etc)
public struct FSpellGrowth
{

}

public class KLevelComponent : MonoBehaviour
{
    public int level;
    public KBuffableStat experienceGainRate;
    public KBuffableStat experienceRadius;

    public FDefenseGrowth defenseGrowth;
    public FAttackGrowth attackGrowth;
    public FSpellGrowth spellGrowth;

    public void LevelUp()
    {

    }

    public void SetLevelTo(int val)
    {
        //TODO: set level and de-allocate all skill points to be re-allocated (should be a function anyway)
    }
}
