using UnityEngine;
using System.Collections;

/// <summary>
/// Orders are queued within KUnitAI and then call functions in the KUnit interface when called upon.
/// </summary>
public abstract class KUnitOrder
{
    protected KUnitAI aiController;

    // set by OrderFinished()
    public bool bOrderCompleted { get; protected set; }

    public abstract void Execute();

    // marks when to consider the order 'complete' for order queueing purposes
    public virtual void OrderFinished()
    {
        bOrderCompleted = true;
    }

    // default behavior is for order to finish instantly
    public virtual void OrderUpdate()
    {
        OrderFinished();
    }
}
