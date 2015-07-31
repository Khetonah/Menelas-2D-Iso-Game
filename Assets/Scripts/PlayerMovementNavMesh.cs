using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovementNavMesh : MonoBehaviour {
	private Vector3 targetPosition;

	const int RIGHT_MOUSE_BUTTON = 0;

	NavMeshAgent agent;

	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}



	void Update ()
	{
		if(Input.GetMouseButton(RIGHT_MOUSE_BUTTON))
			SetTargetPosition();

		MovePlayer();
	}


	void SetTargetPosition()
	{
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float point = 0f;

		if (plane.Raycast (ray, out point))
			targetPosition = ray.GetPoint (point);
	}

		void MovePlayer()
		{
			agent.SetDestination(targetPosition);

			Debug.DrawLine(transform.position, targetPosition, Color.red);
		}
	}