﻿using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Handles orders given by the player for a KUnit.
/// </summary>

//TODO input buffering and order interruption/canceling
public class KUnitAI : MonoBehaviour
{
    public KUnit unit;

    public KUnitAnimations animations;

    protected Queue<KUnitOrder> orderQueue;
    protected bool bWaitingNewOrder;

    void Awake()
    {
        orderQueue = new Queue<KUnitOrder>();
        bWaitingNewOrder = true;
    }

    void Update()
    {
        OrderUpdate();
    }

    protected void OrderUpdate()
    {
        // if we have any orders in queue
        if (orderQueue.Count != 0)
        {
            // check if the current order is completed
            if (orderQueue.Peek().bOrderCompleted)
            {
                // if it's completed then dequeue it and mark unit as waiting for new order
                orderQueue.Dequeue();
                bWaitingNewOrder = true;
                Debug.Log("order completed");
            }

            // if we have an order in queue
            if (orderQueue.Count != 0)
            {
                // and we're waiting for a new order
                if (bWaitingNewOrder)
                {
                    Debug.Log("executing new order...");
                    orderQueue.Peek().Execute();
                    bWaitingNewOrder = false;
                }

                // then update order
                orderQueue.Peek().OrderUpdate();
            }


        }

        // when order queue is empty, wait for new order 
        else
        {
            bWaitingNewOrder = true; // TODO perform 'hold position' while waiting for new orders
        }
    }

    public void IssueMoveOrder(Vector3 position)
    {
        orderQueue.Clear();
        bWaitingNewOrder = true;
        animations.CancelAttack();
        QueueMoveOrder(position);
    }

    public void QueueMoveOrder(Vector3 position)
    {
        KMoveOrder moveOrder = new KMoveOrder(this, position);
        orderQueue.Enqueue(moveOrder);
    }

    public void IssueFollowOrder(KUnit unit)
    {
        orderQueue.Clear();
        bWaitingNewOrder = true;
        QueueFollowOrder(unit);
    }

    public void QueueFollowOrder(KUnit unit)
    {
        KFollowOrder followOrder = new KFollowOrder(this, unit);
        orderQueue.Enqueue(followOrder);
    }

    public void IssueAttackMoveOrder(Vector3 position)
    {
        orderQueue.Clear();
        bWaitingNewOrder = true;
        QueueAttackMoveOrder(position);
    }

    public void QueueAttackMoveOrder(Vector3 position)
    {
        KAttackMoveOrder attackMoveOrder = new KAttackMoveOrder(this, position);
        orderQueue.Enqueue(attackMoveOrder);
    }

    public void IssueAttackUnitOrder(KUnit unit)
    {
        orderQueue.Clear();
        bWaitingNewOrder = true;
        QueueAttackUnitOrder(unit);
    }

    public void QueueAttackUnitOrder(KUnit unit)
    {
        KAttackUnitOrder attackUnitOrder = new KAttackUnitOrder(this, unit);
        orderQueue.Enqueue(attackUnitOrder);
    }

    public void IssueAbilityCastOrder(EAbilitySlot abilitySlot, KCastParams castParams)
    {
        orderQueue.Clear();
        bWaitingNewOrder = true;
        QueueAbilityCastOrder(abilitySlot, castParams);
    }

    public void QueueAbilityCastOrder(EAbilitySlot abilitySlot, KCastParams castParams)
    {
        KAbilityCastOrder abilityOrder = new KAbilityCastOrder(this, abilitySlot, castParams);
        orderQueue.Enqueue(abilityOrder);
    }
}
