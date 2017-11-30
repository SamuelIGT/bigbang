using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public void runCutscene (string nameCutscene, string nameNextLevelScene)
	{
		PlayerPrefs.SetString ("nameCutscene", nameCutscene);
		PlayerPrefs.SetString ("nextLevelScene", nameNextLevelScene);
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
