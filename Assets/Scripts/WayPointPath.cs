using UnityEngine;
using System.Collections;

public class WayPointPath : MonoBehaviour {

	public GameObject[] waypoints;

	private enum Direction{
		Forward,
		Backward
	}
	private Direction dir;
	private int currentPos = -1;

	// Use this for initialization
	void Start () {
	
	}

	public Vector3 getNextPos() {

		if (currentPos == waypoints.Length - 1)
			dir = Direction.Backward;

		else if (currentPos == 0)
			dir = Direction.Forward;


		if (dir == Direction.Forward)
			++currentPos;
		else
			--currentPos;

		return waypoints[currentPos].transform.position;
	}

	public void showWaypoints(bool show) {
		for (int i = 0; i < waypoints.Length; i++) {
			waypoints[i].gameObject.SetActive(show);
		}
	}

}
