using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Ability movement component which travels at a set speed, turning every frame to face its target.
/// </summary>
public class KProjectileTravel : MonoBehaviour, IAbilityMovement
{
    public IAbilityTarget targetComponent;

    public float projectileSpeed;

    void OnEnable()
    {
        if (targetComponent == null) targetComponent = GetComponent<IAbilityTarget>();
    }

    void Update()
    {
        MovementUpdate();
    }

    public void MovementUpdate()
    {
        transform.LookAt(targetComponent.GetLocation());

        if ( Vector3.Distance(transform.position, targetComponent.GetLocation()) < (transform.forward * projectileSpeed * Time.deltaTime).magnitude)
        {
            transform.position = targetComponent.GetLocation();
        }
        else
        {
            transform.position += transform.forward * projectileSpeed * Time.deltaTime;
        }
    }
}
