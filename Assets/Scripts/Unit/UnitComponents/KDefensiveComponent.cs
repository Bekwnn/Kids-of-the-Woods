﻿using System;

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
    public float attackDamage;
    public float attackSpeed;
    public float criticalChance;
    public float criticalDamage;
    public float attackRange;
}

public class KDefensiveComponent : KUnitComponent
{
    public KBuffableStat maxHealth;
    public KBuffableStat healthRegen;
    public KBuffableStat armor;
    public KBuffableStat magicResist;

    public bool bIsAutoAttackUntargetable;
    public bool bIsAbilityUntargetable;

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
