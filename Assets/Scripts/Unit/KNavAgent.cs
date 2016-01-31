using UnityEngine;
using System.Collections;

/// <summary>
/// Custom NavMesh movement component. Meant to replace Unity's NavAgent.
/// </summary>
public class KNavAgent : MonoBehaviour {
	public NavMeshPath path;
	public float moveSpeed;
	public float turnRate; //turnrate is in deg/sec
	public bool stopped; //used by stuns etc to temporarily disable movement
	public float verticalOffset; //offset of the object with the navmesh
	public Vector3 nextPosition { get; protected set; }
	public bool ignoreObstacles; //for flying movement
	public float distToDestination { get; protected set; }
	public float stoppingDistance;
	public int areaMask;
	public bool pathPending;

	void Update()
	{
		float degToRotate = Quaternion.Angle(transform.rotation, destRotation);
		UpdateRotation(degToRotate);
		UpdatePosition(degToRotate);
		UpdatePath();
	}

	void UpdateRotation(float degToRotate)
	{
		Quaternion destRotation = Quaternion.LookRotation(transform.rotation, nextPosition);

		//if we're already facing the direction we're going, exit (is this faster?)
		if (degToRotate < 1f)
			return;

		transform.rotation = Quaternion.RotateTowards(transform.rotation, destRotation, turnRate*Time.deltaTime);
	}

	void UpdatePosition(float degToRotate)
	{
		//if we're not facing the direction we want to go, don't move and only rotate in place.
		if (bIsStopped || degToRotate > 80f)
			return;

		//TODO: collision checking
		// Players move based on their rotation and 
		Vector3 moveDir = (transform.position - nextPosition).normalized;
		transform.position += moveDir * moveSpeed * Vector3.Dot(transform.position, moveDir) * Time.deltaTime;
	}

	void UpdatePath()
	{
		//TODO: check if we've reched a point on the path and start towards next point or mark the path complete
	}

	public bool hasPath()
	{
		return (path != null);
	}

	public bool CalculatePath(Vector3 destination, NavMeshPath p)
	{
		return NavMesh.CalculatePath(transform.position, destination, areaMask, p);
	}

	public bool SetDestination(Vector3 target)
	{
		return CalculatePath(target, path);
	}

	
}
