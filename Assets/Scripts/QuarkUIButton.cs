using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuarkUIButton : MonoBehaviour, IPointerEnterHandler {

	public Text descriptionText;
	public Text costText;
	public Text titleText;
	public string description;
	public float cost;
	public string title;
	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void OnPointerEnter(PointerEventData eventData) {
		descriptionText.text = description;
		titleText.text = title;
		costText.text = cost + " $";
	}
		

}
