using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Sprint : MonoBehaviour {
	public Image Bar;
	float stamina = 5, maxStamina =5;
	float walkSpeed, runSpeed;
	NavMeshAgent cm;
	bool isRunning;
	
	
	
	// Use this for initialization
	void Start () {
		cm = gameObject.GetComponent<NavMeshAgent> ();
		walkSpeed = cm.speed;
		runSpeed = walkSpeed * 2;
		InvokeRepeating ("Affichage", 0, 2f);
	}
	void SetRunning(bool isRunning)
	{
		this.isRunning = isRunning;
		cm.speed = isRunning ? runSpeed : walkSpeed;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift))
			SetRunning (true);
		if (Input.GetKeyUp (KeyCode.LeftShift))
			SetRunning (false);
		
		if (isRunning)
		{ 
			stamina -= Time.deltaTime;
			if (stamina < 0)
			{
				stamina = 0;
				SetRunning(false);
			}
		}
		
		else if (stamina < maxStamina)
		{
			stamina += Time.deltaTime;
		}
	}
	void Affichage()
	{
		
		float calc_Stamina = stamina / maxStamina;
		Stamina (calc_Stamina);
	}
	void Stamina(float stamina)
	{ 
		Bar.fillAmount = stamina;
		Debug.Log("Update time :" + Time.deltaTime);
	}

}
