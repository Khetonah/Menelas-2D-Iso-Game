using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(WayPointPath))]
public class WayPointPathEditor : Editor {
	
	private WayPointPath wp;
	
	void OnEnable() {
		wp = (WayPointPath)target;	
	}
	
	void OnSceneGUI() {

		wp.showWaypoints(true);

		for (int i = 1; i < wp.waypoints.Length; i++) {
			Handles.DrawLine(wp.waypoints[i - 1].transform.position, wp.waypoints[i].transform.position);
		}
	}

	void OnDisable() {
		wp.showWaypoints(false);
	}
	
}
