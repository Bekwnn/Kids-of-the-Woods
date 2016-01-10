using UnityEngine;

/// <summary>
/// The class representing status effects. Includes several events 
/// </summary>
public abstract class KBuff : MonoBehaviour //may want to change from inheriting monobehavior in the future once there are buff ui elements and units start having tons of buffs
{
    public KUnit affectedUnit;

    public float duration = 5f;
    protected float timeRemaining;

    public float buffTickInterval = 1f;
    protected float tickIntervalTracker;

    /// <summary>
    /// executes when the buff is first applied
    /// </summary>
    virtual public void OnApplication() { timeRemaining = duration; tickIntervalTracker = buffTickInterval; }

    /// <summary>
    /// Called every so often based on the buffTickInterval
    /// </summary>
    virtual public void OnBuffTick() { }

    /// <summary>
    /// default behavior on expiration is to destroy the buff component
    /// </summary>
    virtual public void OnExpiration() { Destroy(this); }


    /// <summary>
    /// called when the debuff is dispelled rather than expiring as intended. Default behavior is to call OnExpiration()
    /// </summary>
    virtual public void OnDispelled() { OnExpiration(); }

    /// <summary>
    /// called any time the recipient takes an instance of damage (things which don't count as instances don't trigger this)
    /// </summary>
    /// <param name="damageInfo"></param>
    virtual public void OnBeingHit(FDamageInfo damageInfo) { }

    /// <summary>
    /// called any time the buff recipient recieves an instance of healing (either flat heals or regeneration)
    /// </summary>
    /// <param name="healInfo"></param>
    virtual public void OnBeingHealed(FHealInfo healInfo) { }

    /// <summary>
    /// called any time the buff recipient successfully launches an attack
    /// </summary>
    virtual public void OnAttackSent() { }

    /// <summary>
    /// called any time the buff recipient successfully lands an attack
    /// </summary>
    /// <param name="other"></param>
    virtual public void OnAttackHit(KUnit other) { }

    /// <summary>
    /// called any time the recipient successfully casts a spell
    /// </summary>
    virtual public void OnAbilitySent() { }

    /// <summary>
    /// called any time the recipient successfully lands a spell
    /// </summary>
    /// <param name="other"></param>
    virtual public void OnAbilityHit(KUnit other) { }

    /// <summary>
    /// (should be) called every Update()
    /// </summary>
    virtual protected void OnUpdate()
    {
        if (duration > 0f)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0f)
            {
                affectedUnit.RemoveBuff(this, false);
            }
        }

        if (buffTickInterval > 0f)
        {
            tickIntervalTracker -= Time.deltaTime;
            if (tickIntervalTracker < 0f)
            {
                OnBuffTick();
                tickIntervalTracker += buffTickInterval;
            }
        }
    }
}
