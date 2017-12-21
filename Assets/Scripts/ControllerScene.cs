using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerScene : MonoBehaviour
{

	private static ControllerScene controllerScene = new ControllerScene ();


	private ControllerScene ()
	{
	
	}

	public static ControllerScene getInstance ()
	{
		return controllerScene;
	}

	public void runCutscene (int idCutscene, string nameNextLevelScene, string textButtonNextLevel)
	{
		PlayerPrefs.SetString ("idCutscene", idCutscene.ToString ());
		PlayerPrefs.SetString ("nextLevelScene", nameNextLevelScene);
		PlayerPrefs.SetString ("textButtonNext", textButtonNextLevel);
		SceneManager.LoadScene ("Cutscene");
	}

	public void runNextLevelScene ()
	{
		string nameNextLevelScene = PlayerPrefs.GetString ("nextLevelScene");
		if (nameNextLevelScene != null) {
			SceneManager.LoadScene (nameNextLevelScene);
		}
	}

	public void runEndGameScene ()
	{
		SceneManager.LoadScene ("EndGameScene");
	}

}
