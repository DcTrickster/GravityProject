//Written By Saoirse﻿
//Mostly
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public static int RedLives = 6;
	public static int BlueLives = 6;
	public static int round = 1;
	public static int redScore = 0;
	public static int blueScore = 0;

	public Text Round;
	public Text ScoreRed;
	public Text ScoreBlue;

	public bool redWin = false;
	public bool blueWin = false;

	public Image imgRLife1, imgRLife2, imgRLife3, imgRLife4, imgRLife5, imgRLife6,
				imgBLife1, imgBLife2, imgBLife3, imgBLife4, imgBLife5, imgBLife6;

	public GameObject WinRed;
	public GameObject WinBlue;

	public float restartDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (commence ());
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
	//		WinBlue.SetActive(true);
			if (!blueWin) {
				scoreBlue ();
			}
			if (blueScore > 1 && blueScore > redScore) {
				WinBlue.SetActive (true);
			}
			else {
				Round.text = "Round " + (round + 1).ToString ();
			}
			Invoke ("Restart", 2);
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
		//	WinRed.SetActive(true);
			if (!redWin) {
				scoreRed ();
			}
			if (redScore > 1 && redScore > blueScore) {
				WinRed.SetActive (true);
			}
			else {
				Round.text = "Round " + (round + 1).ToString ();
			}
			Invoke ("Restart", 2);
		}


		if(Respawn.goal1 == true && Respawn.goal2 == false) {
		//	WinRed.SetActive(true);
			if (!redWin) {
				scoreRed ();
			}
			if (redScore > 1 && redScore > blueScore) {
				WinRed.SetActive (true);
			}
			else {
				Round.text = "Round " + (round + 1).ToString ();
			}
			Invoke ("Restart", 2);
		}
		if(Respawn.goal2 == true && Respawn.goal1 == false) {
		//	WinBlue.SetActive(true);
			if (!blueWin) {
				scoreBlue ();
			}
			if (blueScore > 1 && blueScore > redScore) {
				WinBlue.SetActive (true);
			} 
			else {
				Round.text = "Round " + (round + 1).ToString ();
			}
			Invoke ("Restart", 2);
		}

		ScoreRed.text = redScore.ToString ();
		ScoreBlue.text = blueScore.ToString ();

	}

	IEnumerator commence() {
		Round.text = "Round " + round.ToString ();
		yield return new WaitForSeconds (2);
		Round.text = " ";
	}

	void scoreRed() {
		redScore++;	
		redWin = true;
	}

	void scoreBlue() {
		blueScore++;
		blueWin = true;
	}

	void Restart ()
	{
	//	Round.text = " ";
//		int lvl = SceneManager.sceneLoaded;
//		int currentLvl = 0;

		Respawn.goal1 = false;
		Respawn.goal2 = false;
//		if (currentLvl = 2) {
//			SceneManager.LoadScene (0);
//		} 
//		else 
//		{
//			SceneManager.LoadScene (lvl + 1);
//			currentLvl++;
//		}
		SceneManager.LoadScene ("Prototype");
		RedLives = 6;
		BlueLives = 6;

		Respawn.objectiveHeld = false;

		if ((redScore > 1 && redScore > blueScore) || (blueScore > 1 && blueScore > redScore)) {
			redScore = 0;
			blueScore = 0;
			round = 1;
		}
		else {
			round++;
		}
		print ("red:" + redScore + " blue:" + blueScore + " round:" + round);
	}

}
