using UnityEngine;
using System;
using System.IO;

[Serializable]
public class AutoAttackComponentInfo
{
    public float attackDamage;
    public float attackSpeed;
    public float criticalChance;
    public float criticalDamage;
    public float attackRange;
}

public class KAutoAttackComponent : KUnitComponent
{
    public KBuffableStat attackDamage;
    public KBuffableStat attackSpeed;
    public KBuffableStat criticalChance;
    public KBuffableStat criticalDamage;
    public KBuffableStat attackRange;

    override public void Initialize()
    {
        base.Initialize();

        AutoAttackComponentInfo info = ReadJson<AutoAttackComponentInfo>("attack");

        //assign values from json info
        attackDamage = new KBuffableStat(info.attackDamage);
        attackSpeed = new KBuffableStat(info.attackSpeed);
        criticalChance = new KBuffableStat(info.criticalChance);
        criticalDamage = new KBuffableStat(info.criticalDamage);
        attackRange = new KBuffableStat(info.attackRange);
    }

    public void TryAttackingTarget(KUnit target)
    {
        Debug.Log("Attempting to attack target");
    }

    protected void StartAttack()
    {
        //TODO
    }

    protected void LaunchAttack()
    {
        //TODO
    }
}
