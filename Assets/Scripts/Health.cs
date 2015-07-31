using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	
	public Image Bar;
	public float maxHealth = 100;//maxHealth
	public float currentHealth = 100;//currentHealth
	public float minimumHealth = 0;//minimum Health
	
	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
		InvokeRepeating ("Affichage", 0, 2f);
	}
	
	void Affichage()
	{

		float calc_health = currentHealth / maxHealth;
		SetHealth (calc_health);
	}
	
	// Update is called once per frame
	
	void SetHealth(float myhealth)
	{ 
		Bar.fillAmount = myhealth;
	}
	
}