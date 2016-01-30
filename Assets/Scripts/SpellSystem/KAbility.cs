using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EAbilityCastMethod
{
    ONPRESS,
    TARGETUNIT,
    AIMED,
    LINEDRAG
};

public class KCastParams
{
	//aliases for the 0 index
	public KUnit targetUnit {
		get {
			return targetUnits[0];
		}
		set {
			if (targetUnits == null) targetUnits = new List<KUnit>();
			targetUnits.Insert(0, value);
		}
	}
	public Vector3 targetLocation {
		get {
			return targetLocations[0];
		}
		set {
			if (targetLocations == null) targetLocations = new List<Vector3>();
			targetLocations.Insert(0, value);
		}
	}
	//holds successive target locations and units
	public List<Vector3> targetLocations;
	public List<KUnit> targetUnits;
}

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

    virtual public void CastActive(KCastParams castParams)
    {
        if (!bHasActive)           Debug.Log("Ability has no active.");
        else if (abilityLevel < 1) Debug.Log("Spell not yet learned.");
    }
}
