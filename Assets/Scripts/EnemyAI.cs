using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;

	private Transform myTransform;
	// Use this for initialization
	void Awake () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;

	}

	void Update (){
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
	//Move to target
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}


}
