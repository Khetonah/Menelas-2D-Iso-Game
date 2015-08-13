using UnityEngine;
using System.Collections;

public class Aggro : MonoBehaviour {

	public enum AggroSpeedType {
		verySlow,
		slow,
		normal,
		fast,
		veryFast
	};

	public enum State {
		Aggro,
		Neutral,
		Reseting

	};

	public float aggroRange = 0;
	public bool activated = true;
	public bool debug = false;
	public AggroSpeedType aggroSpeed = AggroSpeedType.normal;
	public float maxDistanceFromBase = 0;
	
	private GameObject player;
	private Vector3 origin;
	private NavMeshAgent navAgent;
	private State state = State.Neutral;
	private float initSpeed;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		navAgent = GetComponent<NavMeshAgent> ();
		initSpeed = navAgent.speed;
	}
	
	private float calcDistance(Vector3 posA, Vector3 posB) {
		return Mathf.Sqrt (Mathf.Pow (posA.x - posB.x, 2) + Mathf.Pow (posA.z - posB.z, 2));
	}

	private bool playerInRange() {
		if (calcDistance(player.transform.position, this.transform.position) < aggroRange)
			return true;

		return false;
	}

	public State getMobState() {
		return state;
	}
	
	// Update is called once per frame
	void Update () {

		float speedCoef;

		switch (aggroSpeed) {
		case AggroSpeedType.fast:
			speedCoef = (float)1.25;
			break;
		case AggroSpeedType.normal:
			speedCoef = (float)1.0;
			break;
		case AggroSpeedType.slow:
			speedCoef = (float)0.75;
			break;
		case AggroSpeedType.veryFast:
			speedCoef = (float)1.5;
			break;
		default:
			speedCoef = (float)0.5;
			break;
		}

		navAgent.speed = initSpeed * speedCoef;

		switch (state) {
		case State.Neutral:
			if (playerInRange ()) {
				origin = this.transform.position;
				state = State.Aggro;
			}
			break;
		case State.Aggro:
			navAgent.SetDestination (player.transform.position);

			if((calcDistance(this.transform.position, origin) > maxDistanceFromBase)) {
				navAgent.SetDestination(origin);
				state = State.Reseting;
			}
			break;
		default:
			if (navAgent.remainingDistance <= navAgent.stoppingDistance) {
				if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f) {
					state = State.Neutral;
					navAgent.speed = initSpeed;
				}
			}
			break;
		}


	}
}
