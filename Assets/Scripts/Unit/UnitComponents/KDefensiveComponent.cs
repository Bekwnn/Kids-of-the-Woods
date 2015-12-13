using System;
using System.IO;
using UnityEngine;

public enum EDamageType
{
    PHYS,
    MAGIC,
    PURE
}

public enum EMaxHPAdjustType
{
    PERCENTSAME,
    MISSINGHPSAME,
    CURRENTHPSAME
}

public struct FDamageInfo
{
    public EDamageType damageType;
    public bool bIsNotDamageInstance;
    public bool bIsNonFatal;
    public float flatDamageAmount;
    public float percMaxHealthAmount;
    public float percCurHealthAmount;
    public float percMisHealthAmount;
    public KUnit source;
}

public struct FHealInfo
{
    public bool bIgnoresHealingReduction;
    public float flatHealAmount;
    public float percMaxHealthAmount;
    public float percCurHealthAmount;
    public float percMisHealthAmount;
    public KUnit source;
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
    public float currentHealth;
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

        currentHealth = maxHealth.modifiedValue;
    }

    public void TakeDamage(FDamageInfo damageInfo)
    {
        //TODO: damage instance stuff triggers
        float damageTotal = 0f;
        damageTotal += damageInfo.percCurHealthAmount * currentHealth;
        damageTotal += damageInfo.flatDamageAmount;
        damageTotal += damageInfo.percMaxHealthAmount * maxHealth.modifiedValue;
        damageTotal += damageInfo.percMisHealthAmount * (maxHealth.modifiedValue - currentHealth);

        if (damageInfo.damageType == EDamageType.PHYS)
        {
            if (armor.modifiedValue >= 0) damageTotal *= 100 / (100 + armor.modifiedValue);
            else damageTotal *= 2f - 100 / (100 - armor.modifiedValue);
        }
        else if (damageInfo.damageType == EDamageType.MAGIC)
        {
            if (magicResist.modifiedValue >= 0) damageTotal *= 100 / (100 + magicResist.modifiedValue);
            else damageTotal *= 2f - 100 / (100 - magicResist.modifiedValue);
        }

        currentHealth = Math.Max(currentHealth - damageTotal, 0f);
        Debug.Log("Current health: " + currentHealth);
        //TODO: death (check bIsFatal)
    }

    public void Heal(FHealInfo healInfo)
    {
        float healTotal = 0f;
        healTotal += healInfo.percCurHealthAmount * currentHealth;
        healTotal += healInfo.flatHealAmount;
        healTotal += healInfo.percMaxHealthAmount * maxHealth.modifiedValue;
        healTotal += healInfo.percMisHealthAmount * (maxHealth.modifiedValue - currentHealth);

        currentHealth = Math.Min(currentHealth + healTotal, maxHealth.modifiedValue);
    }
    
    public void AdjustMaxHealth(EMaxHPAdjustType adjustType)
    {
        //TODO (fucking... how? has to work with KBuffableStat adjusting)
    }

    void Update()
    {
        RegenHealth();

        //TODO remove
        if (Input.GetKeyDown(KeyCode.F))
        {
            FDamageInfo damage = new FDamageInfo();
            damage.damageType = EDamageType.PHYS;
            damage.flatDamageAmount = 20f;
            TakeDamage(damage);
        }
    }

    protected void RegenHealth()
    {
        FHealInfo regen = new FHealInfo();
        regen.flatHealAmount = healthRegen.modifiedValue * Time.deltaTime;
        regen.source = unit;
        Heal(regen);
    }
}
