using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {


	public void StartGame()
	{
		Application.LoadLevel(1);
	}
		
	public void HowToPlay()
	{
		Application.LoadLevel(3);
	}

	public void Return()
	{
		Application.LoadLevel(0);
	}

	public void Credits()
	{
		Application.LoadLevel(2);
	}

	public void Quit()
	{
		Application.Quit();
	}

}
