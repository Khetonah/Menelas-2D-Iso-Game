using UnityEngine;
using UnityEditor;

using System.Collections;
using System;

public class MobNavigation : MonoBehaviour {

	public enum MovingType
	{
		randomRange,
		path
	};

	public MovingType movingType;
	public float range = 0;

	private Vector3 origin;
	private NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {

		origin = transform.position;
		navAgent = gameObject.GetComponent<NavMeshAgent>();

	}

	// Update is called once per frame
	void Update () {


		// Check if we've reached the destination
		if (!navAgent.pathPending)
		{
			if (navAgent.remainingDistance <= navAgent.stoppingDistance)
			{
				if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f)
				{
					float angle = UnityEngine.Random.Range ((float) 0.0, (float) (2 * Math.PI));

					if (movingType == MovingType.randomRange) {
						navAgent.SetDestination(new Vector3(origin.x + (float)(Math.Cos(angle) * range) ,origin.y, (float) origin.z + ((float)UnityEngine.Random.Range((float)-Math.Sin(angle), (float)Math.Sin(angle)) * range)));
					}
				}
			}
		}

		//Debug.Log ("Titi = " + Math.Cos (Random.Range(0, 2 * Math.PI)));
		Debug.Log("Range : " + UnityEngine.Random.Range ((float) 0.0, (float) (2 * Math.PI)));


	}
}
