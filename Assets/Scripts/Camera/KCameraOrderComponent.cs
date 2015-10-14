using UnityEngine;
using System.Collections;

/*
 * Component allows camera pawn to issue orders to units and cast spells
 */

public class KCameraOrderComponent : MonoBehaviour
{
    // ref to management component
    public KCameraPawn cameraPawn;
    
    // true if spell is prepped on cursor to cast
    public bool bTryingToCast { get; protected set; }

    void Update()
    {
        if (!bTryingToCast)
        {
            IssueOrderUpdate();
        }
        else
        {
            IssueCastUpdate();
        }
    }

    protected void IssueOrderUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // issue move order or attack order to all selected units
        }
    }

    protected void IssueCastUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast spell at cursor selection
        }
        else if (Input.GetMouseButtonDown(1))
        {
            // cancel spell cast
        }
    }
}
