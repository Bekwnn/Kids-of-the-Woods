using UnityEngine;
using System.Collections.Generic;

public class KUnitAI : MonoBehaviour
{
    public KUnit unitManager;
    public NavMeshAgent navAgent;

    protected Queue<KUnitOrder> orderQueue;
    protected bool bWaitingNewOrder;

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
            }

            // if we have an order in queue
            if (orderQueue.Count != 0)
            {
                // and we're waiting for a new order
                if (bWaitingNewOrder)
                {
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
            bWaitingNewOrder = true;
        }
    }

    public void IssueMoveOrder(Vector3 position)
    {
        //TODO in a better way
    }

    public void QueueMoveOrder(Vector3 position)
    {
        KMoveOrder moveOrder = new KMoveOrder(this, position);
        orderQueue.Enqueue(moveOrder);
    }

    public void IssueFollowOrder(KUnit unit)
    {
        //TODO
    }

    public void QueueFollowOrder(KUnit unit)
    {
        KFollowOrder followOrder = new KFollowOrder(this, unit);
        orderQueue.Enqueue(followOrder);
    }

    public void IssueAttackMoveOrder(Vector3 position)
    {
        //TODO
    }

    public void QueueAttackMoveOrder(Vector3 position)
    {
        KAttackMoveOrder attackMoveOrder = new KAttackMoveOrder(this, position);
        orderQueue.Enqueue(attackMoveOrder);
    }

    public void IssueAttackUnitOrder(KUnit unit)
    {
        //TODO
    }

    public void QueueAttackUnitOrder(KUnit unit)
    {
        KAttackUnitOrder attackUnitOrder = new KAttackUnitOrder(this, unit);
        orderQueue.Enqueue(attackUnitOrder);
    }

    public void IssueSpellCastOrder(KAbility spell)
    {
        //TODO
    }

    public void QueueSpellCastOrder(KAbility spell)
    {
        KSpellCastOrder spellOrder = new KSpellCastOrder(this, spell);
        orderQueue.Enqueue(spellOrder);
    }
}
