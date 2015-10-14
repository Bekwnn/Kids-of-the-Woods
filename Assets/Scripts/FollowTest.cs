using UnityEngine;
using System.Collections;

public class FollowTest : MonoBehaviour
{
    public NavMeshAgent agent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                agent.SetDestination(hit.point);

        }
    }
}
