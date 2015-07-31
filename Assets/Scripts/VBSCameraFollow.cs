using UnityEngine;
using System.Collections;

public class VBSCameraFollow : MonoBehaviour {
	
	public Transform target;
	public float smoothTime = 0.3f;
	
	private Vector3 velocity = Vector3.zero;
	
	void Update () {
		Vector3 goalPos = target.position;
		goalPos.y = transform.position.y;
		goalPos.x = target.position.x - 20f;
		goalPos.z = target.position.z - 20f;
		transform.position = Vector3.SmoothDamp (transform.position, goalPos, ref velocity, smoothTime);
	}
}

