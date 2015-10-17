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
        movementSpeed = new KBuffableStat(3.5f);
        turnRate = new KBuffableStat(100f);

        if (navAgent != null)
        {
            navAgent.speed = movementSpeed.modifiedValue;
            navAgent.angularSpeed = turnRate.modifiedValue;
        }
    }
}
