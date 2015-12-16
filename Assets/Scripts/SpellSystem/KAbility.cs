using UnityEngine;
using System.Collections;

public enum EAbilityCastMethod
{
    ONPRESS,
    TARGETUNIT,
    AIMED,
    DRAGAIMED
};

/// <summary>
/// Representation of a unit's ability. Contains a reference to a passive and an active, as well as ability casting methods and ability data.
/// </summary>
public abstract class KAbility : MonoBehaviour
{
    public KBuff passive;
    public KAbilityPart active;
    public EAbilityCastMethod castMethod;

    public bool bLearned;
    public bool bHasActive;
    public bool bActiveNotReady;    // used not just for cooldowns, but also if actives have a requirement to be usable (ex, enemy has to be debuffed with something)
    public bool bHasPassive;

    public float cooldown;
    public float range;

    virtual public void CastActive()
    {
        if (!bLearned) Debug.Log("Spell not yet learned.");
        if (!bHasActive) Debug.Log("Ability has no active.");
    }
}
