using UnityEngine;
using System.Collections;

public class KStatsMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;

    public KBuffableStat movementSpeed;
    public KBuffableStat turnRate;

    public bool bIsFlying;

    void Awake()
    {
        if (navAgent != null)
        {
            navAgent.speed = movementSpeed.ModifiedValue;
            navAgent.angularSpeed = turnRate.ModifiedValue;
        }
    }
}
