﻿using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class JMovementComponentInfo
{
    public float moveSpeed;
    public float turnRate;
}

/// <summary>
/// Controls navigation and movement of KUnit.
/// </summary>
public class KMovementComponent : KUnitComponent
{
    public KNavAgent navAgent;

    [HideInInspector]
    public KBuffableStat moveSpeed;

    [HideInInspector]
    public KBuffableStat turnRate;

    public bool bMoveDisabled;
    public bool bTurnDisabled;
    public bool bFlyingMovement;

    public override void Initialize()
    {
        base.Initialize();

        JMovementComponentInfo info = ReadJson<JMovementComponentInfo>("movement");

        //assign values from json info
        moveSpeed = new KBuffableStat(info.moveSpeed);
        turnRate = new KBuffableStat(info.turnRate);

        if (navAgent != null)
        {
            navAgent.moveSpeed = moveSpeed.modifiedValue;
            navAgent.turnRate = turnRate.modifiedValue;
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
