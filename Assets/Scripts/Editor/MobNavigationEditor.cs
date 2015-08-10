using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MobNavigation))]
public class MobNavigationEditor : Editor {

	private MobNavigation mn;
	private Vector3 initPos;

	void OnEnable() {
		mn = (MobNavigation)target;
		initPos = mn.transform.position;

	}

	void OnSceneGUI() {
		if (mn.movingType == MobNavigation.MovingType.randomCircular) {

			float range = mn.range;

			Handles.color = new Color ((float)1, (float)0, (float)0, (float)0.1);
			Handles.DrawSolidDisc (initPos, Vector3.up, range);
			Handles.color = Color.red;
			range = 
				Handles.ScaleValueHandle (range,
				                          initPos + new Vector3 (range, 0, 0),
				                         Quaternion.identity,
				                         2,
				                         Handles.CylinderCap,
				                         2);
		}
	}

}
