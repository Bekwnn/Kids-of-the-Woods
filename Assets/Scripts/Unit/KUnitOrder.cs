using UnityEngine;
using System.Collections;

/* Orders are queued within KUnitAI and then call functions within KUnitAI when called upon
 */
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
}
