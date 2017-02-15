//Written By Daniel Coleman
using UnityEngine;
using System.Collections;

public class ReturnToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Invoke ("GoToMenu", 15f);
	}

	public void GoToMenu()
	{
		Application.LoadLevel(0);
	}
}
