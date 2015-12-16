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

    virtual public void OnApplication() { timeRemaining = duration; tickIntervalTracker = buffTickInterval; }

    virtual public void OnBuffTick() { }

    //default behavior on expiration is to destroy the buff component
    virtual public void OnExpiration() { Destroy(this); }

    //default behavior is to call OnExpiration
    virtual public void OnDispelled() { OnExpiration(); }

    virtual public void OnBeingHit(FDamageInfo damageInfo) { }

    virtual public void OnBeingHealed(FHealInfo healInfo) { }

    virtual public void OnAttackSent() { }

    virtual public void OnAttackHit(KUnit other) { }

    virtual public void OnAbilitySent() { }

    virtual public void OnAbilityHit(KUnit other) { }

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
