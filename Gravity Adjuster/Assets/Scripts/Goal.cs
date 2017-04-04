//Written By Saoirse﻿
//Mostly
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	public static int P1Lives = 3;
	public static int P2Lives = 3;
	public static int P3Lives = 3;
	public static int P4Lives = 3;

	public static int RedLives = 6;
	public static int BlueLives = 6;
	public static int round = 1;
	public static int redScore = 0;
	public static int blueScore = 0;

	public Text Round;
	public Text ScoreRed;
	public Text ScoreBlue;
	public Image winRedImg;
	public Image winBlueImg;

	public bool redWin = false;
	public bool blueWin = false;

	public Image imgRLife1, imgRLife2, imgRLife3, imgRLife4, imgRLife5, imgRLife6,
				imgBLife1, imgBLife2, imgBLife3, imgBLife4, imgBLife5, imgBLife6;


	public float restartDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (commence ());

		winRedImg.enabled = false;
		winBlueImg.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (P1Lives == 2)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = true;
			imgRLife3.enabled = false;
		}

		if (P1Lives == 1)
		{
			imgRLife1.enabled = true;
			imgRLife2.enabled = false;
			imgRLife3.enabled = false;
		}

		if (P1Lives == 0)
		{
			imgRLife1.enabled = false;
			imgRLife2.enabled = false;
			imgRLife3.enabled = false;
		}

		if (P2Lives == 2)
		{
			imgRLife4.enabled = true;
			imgRLife5.enabled = true;
			imgRLife6.enabled = false;
		}

		if (P2Lives == 1)
		{
			imgRLife4.enabled = true;
			imgRLife5.enabled = false;
			imgRLife6.enabled = false;
		}

		if (P2Lives == 0)
		{

			imgRLife4.enabled = false;
			imgRLife5.enabled = false;
			imgRLife6.enabled = false;
		}

		if (P3Lives == 2)
		{
			imgBLife4.enabled = true;
			imgBLife5.enabled = true;
			imgBLife6.enabled = false;
		}

		if (P3Lives == 1)
		{
			imgBLife4.enabled = true;
			imgBLife5.enabled = false;
			imgBLife6.enabled = false;
		}

		if (P3Lives == 0)
		{

			imgBLife4.enabled = false;
			imgBLife5.enabled = false;
			imgBLife6.enabled = false;
		}

		if (P4Lives == 2)
		{
			imgRLife1.enabled = false;
			imgRLife2.enabled = true;
			imgRLife3.enabled = true;
		}

		if (P4Lives == 1)
		{
			imgBLife1.enabled = false;
			imgBLife2.enabled = false;
			imgBLife3.enabled = true;
		}

		if (P4Lives == 0)
		{
			imgBLife1.enabled = false;
			imgBLife2.enabled = false;
			imgBLife3.enabled = false;
		}




		if (RedLives < 1) 
		{
	//		WinBlue.SetActive(true);
			if (!blueWin) {
				scoreBlue ();
			}
			if (blueScore > 1 && blueScore > redScore) {
			}
			else {
				Round.text = "Round " + (round + 1).ToString ();
			}
			Invoke ("Restart", 2);
		}

		if (BlueLives == 5)
		{
			imgBLife1.enabled = true;
			imgBLife2.enabled = true;
			imgBLife3.enabled = true;
			imgBLife4.enabled = true;
			imgBLife5.enabled = true;
			imgBLife6.enabled = false;
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
			if (redScore > 1 && redScore > blueScore) 
			{
				winRedImg.enabled = true;

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
				winBlueImg.enabled = true;

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

		Respawn.goal1 = false;
		Respawn.goal2 = false;

	//	SceneManager.LoadScene ("Angles");
		int[] scenes = new int[]{1, 2, 3};
		SceneManager.LoadScene (Random.Range(0, scenes.Length));
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
