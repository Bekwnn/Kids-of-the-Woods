using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class KUnitTargetedAbility : MonoBehaviour, IAbilityTarget {

    public KUnit targetUnit;

	public Vector3 GetLocation()
    {
        return targetUnit.transform.position;
    }
}
