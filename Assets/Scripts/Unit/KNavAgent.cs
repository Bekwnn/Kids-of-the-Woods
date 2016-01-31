using UnityEngine;
using System.Collections;

/// <summary>
/// Custom NavMesh movement component. Meant to replace Unity's NavAgent.
/// </summary>
public class KNavAgent : MonoBehaviour {
	public NavMeshPath path;
	public float moveSpeed;
	public float turnRate; //turnrate is in deg/sec
	public bool bIsStopped; //used by stuns etc to temporarily disable movement
	public float verticalOffset; //offset of the object with the navmesh
	public Vector3 nextPosition {
		get {
			if (path != null)
				return path.corners[pathIndex];
			else return Vector3.zero;
		}
	}
//TODO:	public bool ignoreObstacles; //for flying movement
	public float stoppingDistance;
	public int areaMask = NavMesh.AllAreas;
//TODO:	public bool pathPending;
	
	protected int pathIndex;

	void Update()
	{
		if (bIsStopped || path == null) return;

		Quaternion destRotation = Quaternion.LookRotation(nextPosition - transform.position);
		float degToRotate = Quaternion.Angle(transform.rotation, destRotation);

		UpdateRotation(degToRotate, destRotation);
		UpdatePosition(degToRotate);
		UpdatePath();
	}

	void UpdateRotation(float degToRotate, Quaternion destRotation)
	{

		//if we're already facing the direction we're going, exit (is this faster?)
		if (degToRotate < 1f) return;

		transform.rotation = Quaternion.RotateTowards(transform.rotation, destRotation, turnRate*Time.deltaTime);
	}

	void UpdatePosition(float degToRotate)
	{
		//if we're not facing the direction we want to go, don't move and only rotate in place.
		if (degToRotate > 80f)
			return;

		//TODO: collision checking
		// Players move based on their rotation and moveSpeed
		Vector3 moveDir = (nextPosition - transform.position).normalized;
		transform.position += moveDir * moveSpeed * Vector3.Dot(transform.forward, moveDir) * Time.deltaTime;
	}

	void UpdatePath()
	{
		//TODO: check if we've reached a point on the path and start towards next point or mark the path complete
		if (Vector3.Distance(transform.position, nextPosition) < stoppingDistance)
		{
			pathIndex++;
			if (pathIndex >= path.corners.Length)
				path = null;
		}
	}

	public bool HasPath()
	{
		return (path != null);
	}

	public float DistanceToDestination()
	{
		if (path != null && path.corners.Length >= 1)
			return Vector3.Distance(transform.position, path.corners[path.corners.Length-1]);
		else return 0f;
	}

	public bool CalculatePath(Vector3 destination, NavMeshPath p)
	{
		return NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, p);
	}

	public bool SetDestination(Vector3 target)
	{
		path = new NavMeshPath();
		bool success = CalculatePath(target, path);
		if (success)
		{
			pathIndex = 1;
			return success;
		}
		else
		{
			path = null;
			return success;
		}
	}

	public void Stop()
	{
		bIsStopped = true;
	}
	
	public void Resume()
	{
		bIsStopped = false;
	}
}
