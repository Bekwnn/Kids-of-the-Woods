using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Ability targetting component which targets a set vector location.
/// </summary>
public class KAimedAbility : MonoBehaviour, IAbilityTarget {

    public Vector3 targetLocation;

    public Vector3 GetLocation()
    {
        return targetLocation;
    }
}
