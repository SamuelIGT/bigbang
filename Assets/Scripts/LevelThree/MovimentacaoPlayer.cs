using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovimentacaoPlayer : MonoBehaviour {

	private float framesDash;
	private int horizontal;
	// Use this for initialization
	void Start () {
		horizontal = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow)){
			horizontal = -1;
			this.gameObject.transform.Translate (Vector3.left * Time.deltaTime * 2.0f);			
		}else if(Input.GetKey(KeyCode.RightArrow)){
			horizontal = 1;
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 2.0f);	
		}else if(Input.GetKey(KeyCode.UpArrow)){
			this.gameObject.transform.Translate (Vector3.forward * Time.deltaTime * 2.0f);	
		}else if(Input.GetKey(KeyCode.DownArrow)){
			this.gameObject.transform.Translate (Vector3.back * Time.deltaTime * 2.0f);	
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			framesDash = Time.timeSinceLevelLoad;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			framesDash = Time.timeSinceLevelLoad - framesDash;
			this.dash ();
			framesDash = 0.0f;
		}

	}

	public void dash(){
		//Debug.Log ("dash: " + framesDash);
		float velocidade; 
		if (framesDash < 1.0f) {
			velocidade = 200.0f;
		} else if (framesDash < 3.0f) {
			velocidade = 600.0f;
		} else {
			velocidade = 1000.0f;
		}
		this.gameObject.GetComponent<Rigidbody> ().AddForce (this.gameObject.transform.right * velocidade * horizontal);
	}

}

