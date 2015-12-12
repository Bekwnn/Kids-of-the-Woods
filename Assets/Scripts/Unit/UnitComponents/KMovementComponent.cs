using UnityEngine;
using System.Collections;

public class KMovementComponent : KUnitComponent
{
    public NavMeshAgent navAgent;

    public KBuffableStat movementSpeed;
    public KBuffableStat turnRate;

    public bool bMoveDisabled;
    public bool bTurnDisabled;
    public bool bFlyingMovement;

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

    public void MoveToLocation(Vector3 location)
    {
        navAgent.SetDestination(location);
        navAgent.Resume();
    }

    public void StopMoving()
    {
        navAgent.Stop();
    }
}
