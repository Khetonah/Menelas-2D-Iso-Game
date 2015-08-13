using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MobNavigation))]
public class MobNavigationEditor : Editor {

	private MobNavigation mn;
	private Vector3 initPos;
	private WayPointPath wp;

	void OnEnable() {
		mn = (MobNavigation)target;
		initPos = mn.transform.position;
		wp = mn.path.GetComponent<WayPointPath>();
	}

	void OnSceneGUI() {
		if (mn.debug) {
			if (mn.movingType == MobNavigation.MovingType.randomCircular) {
			
				float range = mn.range;

				wp.showWaypoints (false);

				Handles.color = new Color ((float)0, (float)1, (float)0, (float)0.1);
				Handles.DrawSolidDisc (initPos, Vector3.up, range);
				Handles.color = Color.red;
				range = 
					Handles.ScaleValueHandle (range,
					                          initPos + new Vector3 (range, 0, 0),
					                         Quaternion.identity,
					                         2,
					                         Handles.CylinderCap,
					                         2);
			} else if (mn.movingType == MobNavigation.MovingType.path) {

				wp.showWaypoints (true);

				for (int i = 1; i < wp.waypoints.Length; i++) {
					Handles.DrawLine (wp.waypoints [i - 1].transform.position, wp.waypoints [i].transform.position);
				}

			}
		}
	}

	void OnDisable() {
		wp.showWaypoints(false);
	}

}
