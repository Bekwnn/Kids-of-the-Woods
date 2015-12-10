using UnityEngine;
using System.Collections;

public enum EBuffEvent
{
    BEINGHITBYABILITY,
    BEINGHIT,
    ATTACKSENT,
    ATTACKHIT,
    ABILITYSENT,
    ABILITYHIT,

}

public abstract class KBuff : MonoBehaviour
{
    public float duration;

    abstract public void OnApplication();

    abstract public void OnBuffTick();

    abstract public void OnExpiration();

    //default behavior is to call OnExpiration
    public virtual void OnDispelled() { OnExpiration(); }

    abstract public void OnBeingHitByAbility(KUnit other);

    abstract public void OnBeingHit(KUnit other);

    abstract public void OnAttackSent();

    abstract public void OnAttackHit(KUnit other);

    abstract public void OnAbilitySent();

    abstract public void OnAbilityHit(KUnit other);
}
