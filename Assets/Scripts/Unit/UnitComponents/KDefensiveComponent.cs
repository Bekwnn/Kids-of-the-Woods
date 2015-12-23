using System;
using UnityEngine;

public enum EDamageType
{
    PHYS,
    MAGIC,
    PURE
}

public enum EHealCause
{
    HEAL,
    REGEN,
    DEFAULT
}

public enum EDamageCause
{
    BASICATTACK,
    ABILITY,
    DEFAULT
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
    public EDamageCause damageCause;
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
    public EHealCause healCause;
    public bool bIgnoresHealingReduction;
    public float flatHealAmount;
    public float percMaxHealthAmount;
    public float percCurHealthAmount;
    public float percMisHealthAmount;
    public KUnit source;
}

[Serializable]
public class JDefensiveComponentInfo
{
    public float maxHealth;
    public float healthRegen;
    public float armor;
    public float magicResist;
}

/// <summary>
/// The KUnit component which keeps track of a unit's health and resists. Handles damage and healing.
/// </summary>
public class KDefensiveComponent : KUnitComponent
{
    public float currentHealth;

    [HideInInspector]
    public KBuffableStat maxHealth; //TODO: make protected, create readonly get for base/modified value

    [HideInInspector]
    public KBuffableStat healthRegen;

    [HideInInspector]
    public KBuffableStat armor;

    [HideInInspector]
    public KBuffableStat magicResist;

    public bool bIsAutoAttackUntargetable;
    public bool bIsAbilityUntargetable;

    public override void Initialize()
    {
        base.Initialize();

        JDefensiveComponentInfo info = ReadJson<JDefensiveComponentInfo>("defensive");

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

        if (!damageInfo.bIsNotDamageInstance) unit.CallBeingHitOnAllBuffs(damageInfo);

        currentHealth = Math.Max(currentHealth - damageTotal, 0f);
        Debug.Log("Damage after resists: " + damageTotal + ", hp: " + currentHealth + "/" + maxHealth.modifiedValue);
        //TODO: death (check bIsFatal)
    }

    public void Heal(FHealInfo healInfo)
    {
        float healTotal = 0f;
        healTotal += healInfo.percCurHealthAmount * currentHealth;
        healTotal += healInfo.flatHealAmount;
        healTotal += healInfo.percMaxHealthAmount * maxHealth.modifiedValue;
        healTotal += healInfo.percMisHealthAmount * (maxHealth.modifiedValue - currentHealth);

        unit.CallBeingHealedOnAllBuffs(healInfo);

        // should CallXOnAllBuffs return a bool saying whether or not to abort the action?
        currentHealth = Math.Min(currentHealth + healTotal, maxHealth.modifiedValue);
    }
    
    public void AdjustMaxHealth(KStatModifier mod, EMaxHPAdjustType adjustType)
    {
        float curhp = currentHealth;
        float maxhp = maxHealth.modifiedValue;
        maxHealth.AddModifier(mod);

        switch (adjustType)
        {
            case EMaxHPAdjustType.MISSINGHPSAME:
                currentHealth = Math.Max(maxHealth.modifiedValue - (maxhp - curhp), 1f);
                break;
            case EMaxHPAdjustType.PERCENTSAME:
                currentHealth = maxHealth.modifiedValue * (curhp / maxhp);
                break;
            default:
                //do nothing
                break;
        }
    }

    void Update()
    {
        RegenHealth();

        //TODO remove (testing damage)
        if (Input.GetKeyDown(KeyCode.F))
        {
            FDamageInfo damage = new FDamageInfo();
            damage.damageType = EDamageType.PHYS;
            damage.flatDamageAmount = 20f;
            TakeDamage(damage);
            Debug.Log("hp: " + currentHealth + "/" + maxHealth.modifiedValue);
        }

        //TODO remove (testing adjust hp)
        if (Input.GetKeyDown(KeyCode.D))
        {
            KStatModifier buff = new KStatModifier();
            buff.modType = EStatModType.ADD;
            buff.ModValue = 0.1f; // 10% buff
            AdjustMaxHealth(buff, EMaxHPAdjustType.PERCENTSAME);
            Debug.Log("hp: " + currentHealth + "/" + maxHealth.modifiedValue);
        }

        //TODO remove (testing adjust hp)
        if (Input.GetKeyDown(KeyCode.S))
        {
            KTestBuff buff = unit.ApplyBuff<KTestBuff>();
            buff.duration = 5f;
            buff.buffTickInterval = 1f;
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
