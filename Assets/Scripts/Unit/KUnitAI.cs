using UnityEngine;
using System.Collections;

public class KUnitAI : MonoBehaviour
{
    public KUnit unitManager;
    public NavMeshAgent navAgent;

    public void IssueMoveOrder(Vector3 position)
    {
        //TODO: get the movement component involved
        navAgent.SetDestination(position);
    }

    public void IssueFollowOrder(KUnit unit)
    {
        //TODO
    }

    public void IssueAttackMoveOrder(Vector3 position)
    {
        //TODO
    }

    public void IssueAttackUnitOrder(KUnit unit)
    {
        //TODO
    }
}
