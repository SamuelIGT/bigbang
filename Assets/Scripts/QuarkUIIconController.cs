using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarkUIIconController : MonoBehaviour {
	private int quarkType = 0;
	private string scrollViewContentTag = "SCROLL_VIEW_CONTENT";
	// Use this for initialization
	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		
	}

	public void notifyButtonWasClicked() {
		Debug.Log("List item clicked!");
		GameObject.FindGameObjectWithTag(scrollViewContentTag).GetComponent<QuarksListController>().removeQuark(this.gameObject.GetInstanceID());
	}

	public void setQuarkType(int quarkType) {
		this.quarkType = quarkType;
	}

	public int getQuarkType() {
		return quarkType;
	}

}
