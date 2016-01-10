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
/// Representation of a unit's ability. Contains a reference to a passive and an active, as well as ability casting methods and skill-level data.
/// </summary>
public abstract class KAbility : MonoBehaviour
{
    public KBuff passive;
    public GameObject active;
    public EAbilityCastMethod castMethod;

    public int  abilityLevel;
    public bool bHasActive;
    public bool bActiveNotReady;    // used not just for cooldowns, but also if actives have a requirement to be usable (ex, enemy has to be debuffed with something)

    public float cooldown;
    public float range;

    virtual public void CastActive()
    {
        if (!bHasActive)           Debug.Log("Ability has no active.");
        else if (abilityLevel < 1) Debug.Log("Spell not yet learned.");
    }
}
