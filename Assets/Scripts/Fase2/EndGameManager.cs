using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour {
	
	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	void OnTriggerEnter(Collider other) {
		
		if(other.gameObject.tag.Equals("Quark_Up")) {
			GameObject.FindWithTag("GameController").GetComponent<GameStatusController>().increaseProgress(true);
		} else if(other.gameObject.tag.Equals("Quark_Down")) {
			GameObject.FindWithTag("GameController").GetComponent<GameStatusController>().increaseProgress(false);
		}

		GameObject.FindWithTag("GameController").GetComponent<GerenciadorFilaQuarks>().removeQuark(other.gameObject);
		Destroy(other.gameObject.GetComponent<QuarkController>().getHealthBar(), 0.3f);
		Destroy(other.gameObject, 0.3f);
	}
}
