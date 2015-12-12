using System;
using System.IO;
using UnityEngine;

public enum EDamageType
{
    PHYS,
    MAGIC,
    PURE
}

public struct FDamageInfo
{
    public EDamageType damageType;
    public bool bIsDamageInstance;
    public bool bIsFatal;
    public float flatDamageAmount;
    public float percMaxHealthAmount;
    public float percCurHealthAmount;
    public float percMisHealthAmount;
    public KUnit source;
    public KUnit target;
}

[Serializable]
public class DefensiveComponentInfo
{
    public float maxHealth;
    public float healthRegen;
    public float armor;
    public float magicResist;
}

public class KDefensiveComponent : KUnitComponent
{
    public KBuffableStat maxHealth;
    public KBuffableStat healthRegen;
    public KBuffableStat armor;
    public KBuffableStat magicResist;

    public bool bIsAutoAttackUntargetable;
    public bool bIsAbilityUntargetable;

    public override void Initialize()
    {
        base.Initialize();

        DefensiveComponentInfo info = ReadJson<DefensiveComponentInfo>("defensive");

        //assign values from json info
        maxHealth = new KBuffableStat(info.maxHealth);
        healthRegen = new KBuffableStat(info.healthRegen);
        armor = new KBuffableStat(info.armor);
        magicResist = new KBuffableStat(info.magicResist);
    }

    public void TakeDamage(FDamageInfo damageInfo)
    {
        //TODO
    }

    public void Heal()
    {
        //TODO
    }

    public void AdjustMaxHealth()
    {
        //TODO
    }
}
