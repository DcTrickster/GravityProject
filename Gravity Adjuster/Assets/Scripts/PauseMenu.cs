//Written By Daniel Coleman
using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	public GameObject pauseMenuCanvas;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (isPaused)
		{
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
		}
		else 
		{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown(KeyCode.JoystickButton7))
		{
			isPaused = !isPaused;
		}
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void Quit()
	{
		Application.LoadLevel(0);
	}
}