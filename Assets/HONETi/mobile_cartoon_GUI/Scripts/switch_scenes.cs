using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class switch_scenes : MonoBehaviour {
	
	public string sceneName = "";

	// Use this for initialization
	void Start () {
		Button b = GetComponent<Button> ();
		if (b != null && sceneName != "")
		{
			b.onClick.AddListener(() => {SceneManager.LoadScene(sceneName);});
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
