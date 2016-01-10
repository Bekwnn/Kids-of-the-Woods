using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Ability movement component which makes spells instantly travel to and follow their destination.
/// </summary>
public class KInstantTravel : MonoBehaviour, IAbilityMovement
{
    public IAbilityTarget targetComponent;

    void OnEnable()
    {
        if (targetComponent == null) targetComponent = GetComponent<IAbilityTarget>();
    }

    public void MovementUpdate()
    {
        transform.position = targetComponent.GetLocation();
    }
}
