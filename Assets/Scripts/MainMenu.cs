using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	// Use this for initialization
	public void NewGame() 
	{
		Application.LoadLevel (startLevel);
	}
	
	// Update is called once per frame
	public void QuitGame() 
	{
		Application.Quit ();
	}
}
