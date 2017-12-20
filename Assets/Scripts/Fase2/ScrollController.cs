using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour {

	public float scrollValue = 0.25f;
	public Scrollbar horizontalScrollbar;
	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void ScrollRight() {
		horizontalScrollbar.value -= scrollValue;
	}

	public void ScrollLeft() {
		horizontalScrollbar.value += scrollValue;
	}
		
}
