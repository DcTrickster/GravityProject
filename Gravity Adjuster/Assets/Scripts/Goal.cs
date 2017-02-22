//Written By Saoirse﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public static int RedLives = 6;
	public static int BlueLives = 6;

	public Image imgRLife1, imgRLife2, imgRLife3, imgRLife4, imgRLife5, imgRLife6,
				imgBLife1, imgBLife2, imgBLife3, imgBLife4, imgBLife5, imgBLife6;

	public GameObject WinRed;
	public GameObject WinBlue;

	public float restartDelay = 1f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (RedLives == 5)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = true;
			imgRLife3.enabled = true;
			imgRLife4.enabled = true;
			imgRLife5.enabled = true;
			imgRLife6.enabled = false;
		}

		if (RedLives == 4)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = true;
			imgRLife3.enabled = true;
			imgRLife4.enabled = true;
			imgRLife5.enabled = false;
			imgRLife6.enabled = false;
		}

		if (RedLives == 3)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = true;
			imgRLife3.enabled = true;
			imgRLife4.enabled = false;
			imgRLife5.enabled = false;
			imgRLife6.enabled = false;
		}

		if (RedLives == 2)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = true;
			imgRLife3.enabled = false;
			imgRLife4.enabled = false;
			imgRLife5.enabled = false;
			imgRLife6.enabled = false;
		}

		if (RedLives == 1)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = false;
			imgRLife3.enabled = false;
			imgRLife4.enabled = false;
			imgRLife5.enabled = false;
			imgRLife6.enabled = false;
		}

		if (RedLives == 0)
		{
			imgRLife1.enabled = false;
			imgRLife2.enabled = false;
			imgRLife3.enabled = false;
			imgRLife4.enabled = false;
			imgRLife5.enabled = false;
			imgRLife6.enabled = false;
		}

		if (RedLives < 1) 
		{
			WinBlue.SetActive(true);
		}

		if (BlueLives == 5)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = true;
			imgRLife3.enabled = true;
			imgRLife4.enabled = true;
			imgRLife5.enabled = true;
			imgRLife6.enabled = false;
		}

		if (BlueLives == 4)
		{
			imgBLife1.enabled = true;
			imgBLife2.enabled = true;
			imgBLife3.enabled = true;
			imgBLife4.enabled = true;
			imgBLife5.enabled = false;
			imgBLife6.enabled = false;
		}

		if (BlueLives == 3)
		{
			imgBLife1.enabled = true;
			imgBLife2.enabled = true;
			imgBLife3.enabled = true;
			imgBLife4.enabled = false;
			imgBLife5.enabled = false;
			imgBLife6.enabled = false;
		}

		if (BlueLives == 2)
		{
			imgBLife1.enabled = true;
			imgBLife2.enabled = true;
			imgBLife3.enabled = false;
			imgBLife4.enabled = false;
			imgBLife5.enabled = false;
			imgBLife6.enabled = false;
		}

		if (BlueLives == 1)
		{
			imgBLife1.enabled = true;
			imgBLife2.enabled = false;
			imgBLife3.enabled = false;
			imgBLife4.enabled = false;
			imgBLife5.enabled = false;
			imgBLife6.enabled = false;
		}

		if (BlueLives == 0)
		{
			imgBLife1.enabled = false;
			imgBLife2.enabled = false;
			imgBLife3.enabled = false;
			imgBLife4.enabled = false;
			imgBLife5.enabled = false;
			imgBLife6.enabled = false;
		}


		if (BlueLives < 1) {
			WinRed.SetActive(true);
			Invoke ("Restart", 2);
		}


		if(Respawn.goal1 == true && Respawn.goal2 == false) {
			WinRed.SetActive(true);
		}
		if(Respawn.goal2 == true && Respawn.goal1 == false) {
			WinBlue.SetActive(true);
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene ("Prototype");
		RedLives = 6;
		BlueLives = 6;
	}

}
