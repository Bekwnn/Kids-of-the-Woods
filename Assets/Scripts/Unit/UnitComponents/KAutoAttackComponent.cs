using UnityEngine;
using System;

[Serializable]
public class JAutoAttackComponentInfo
{
    public float attackDamage;
    public float attackSpeed;
    public float criticalChance;
    public float criticalDamage;
    public float attackRange;
}

/// <summary>
/// The KUnit component which keeps track of a unit's auto attacking ability.
/// </summary>
public class KAutoAttackComponent : KUnitComponent
{
    [HideInInspector]
    public KBuffableStat attackDamage;

    [HideInInspector]
    public KBuffableStat attackSpeed;

    [HideInInspector]
    public KBuffableStat criticalChance;

    [HideInInspector]
    public KBuffableStat criticalDamage;

    [HideInInspector]
    public KBuffableStat attackRange;

    public KUnitAnimations animations;

    override public void Initialize()
    {
        base.Initialize();

        JAutoAttackComponentInfo info = ReadJson<JAutoAttackComponentInfo>("attack");

        //assign values from json info
        attackDamage = new KBuffableStat(info.attackDamage);
        attackSpeed = new KBuffableStat(info.attackSpeed);
        criticalChance = new KBuffableStat(info.criticalChance);
        criticalDamage = new KBuffableStat(info.criticalDamage);
        attackRange = new KBuffableStat(info.attackRange);
    }

    /* TODO: attack animations.
     * Heroes have a base attack speed. Something like 0.7 or 0.8 attacks per second.
     * A hero with a base attack speed of 0.7 will have a base attack speed stat of 0.7 (simple, right?)
     * A hero with a base attack speed of 0.7 who gets 100% increased attack speed will have 0.7*2.0 = 1.4 attacks per second.
     * Hero attack animations have an attack point and backswing, both of which range from 0.0 to 1.0.
     * If a hero has 1.0 attack speed (attacks once per second) and an attack point of 0.2 and backswing of 0.3:
     *     Their attack will launch 0.2 seconds after the attack order, and the rest of the attack animation will last until 0.5 seconds after the attack order.
     *     Then they will be idle for 0.5 seconds until the next attack can start.
     * This means the hero could cancel the animation after 0.2 seconds (after their attack has launched) with something like a move order.
     */

    public void TryAttackingTarget(KUnit target)
    {
        if (target == unit) return;
        Debug.Log("Attempting to attack target");
        StartAttack();
    }

    protected void StartAttack()
    {
        //TODO
        animations.StartAttack();
    }

    protected void LaunchAttack()
    {
        //TODO
        Debug.Log("launching attack");
    }
}
