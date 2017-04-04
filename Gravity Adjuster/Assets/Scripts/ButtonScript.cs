using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


	public void StartGame()
	{
		Application.LoadLevel(1);
	}
		
	public void HowToPlay()
	{
		Application.LoadLevel(4);
	}

	public void Return()
	{
		Application.LoadLevel(0);
	}

	public void Credits()
	{
		Application.LoadLevel(5);
	}

	public void Quit()
	{
		Application.Quit();
	}
		
}
