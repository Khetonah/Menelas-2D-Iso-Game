using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Aggro))]
public class AggroEditor : Editor {

	private Aggro aggro;
	
	void OnEnable() {
		aggro = (Aggro)target;	
	}
	
	void OnSceneGUI() {
		if (aggro.debug) {
			float range = aggro.aggroRange;

			Handles.color = new Color ((float)1, (float)0, (float)0, (float)0.1);
			Handles.DrawSolidDisc (aggro.transform.position, Vector3.up, range);

			range = 
				Handles.ScaleValueHandle (range,
				                          aggro.transform.position + new Vector3 (range, 0, 0),
				                          Quaternion.identity,
				                          2,
				                          Handles.CylinderCap,
				                          2);
		}
	}
}
