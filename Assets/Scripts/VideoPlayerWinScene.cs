using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerWinScene : MonoBehaviour
{

	public GameObject panelVideo;
	public GameObject panelButtons;
	public VideoPlayer videoPlayer;

	void Start ()
	{
		panelButtons.SetActive (false);
		videoPlayer.Play ();
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

	public void carregarCenaInicio ()
	{
		SceneManager.LoadScene ("Inicio");
	}
}
