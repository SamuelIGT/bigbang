﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerScript : MonoBehaviour
{

	public VideoClip[] cutsceneVideos;
	public GameObject panelVideo;
	public GameObject panelButtons;
	public VideoPlayer videoPlayer;
	private Text textButtonNext;

	void Start ()
	{
		textButtonNext = GameObject.FindGameObjectWithTag ("TextButtonNext").GetComponent<Text> (); 
		setTextButtonNext ();

		string currentCutscene = PlayerPrefs.GetString ("idCutscene");
		if (currentCutscene != null && cutsceneVideos != null) {
			int idCutscene = int.Parse (currentCutscene);
			videoPlayer.clip = cutsceneVideos [idCutscene];
			panelButtons.SetActive (false);
			videoPlayer.Play ();
		}
		videoPlayer.loopPointReached += EndReached;
	}

	void EndReached (UnityEngine.Video.VideoPlayer vp)
	{
		panelVideo.SetActive (false);
		panelButtons.SetActive (true);
	}

	public void replay ()
	{
		panelButtons.SetActive (false);
		panelVideo.SetActive (true);
		videoPlayer.Prepare ();
		videoPlayer.Play ();
	}

	public void setTextButtonNext ()
	{
		string textButtonNextLevel = PlayerPrefs.GetString ("textButtonNext");
		if (textButtonNextLevel != null) {
			this.textButtonNext.text = textButtonNextLevel;		
		} else {
			this.textButtonNext.text = "PRÓXIMA FASE";		
		}
	}
}
