using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovimentacaoPlayer : MonoBehaviour {
	public Transform spritePlayer;
	private Animator animator;
	private float framesDash;
	private int horizontal;
    private bool isDash;
	private float move;
	private Rigidbody rb;
	Quaternion rotacao;
	void Start () {
		horizontal = -1;
		animator = spritePlayer.GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void Update () {
		move = 0;
		if(Input.GetKey(KeyCode.LeftArrow)){
			horizontal = 1;
			move = 1;
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);
			this.gameObject.transform.eulerAngles = new Vector2(0, 180);
			//rotacao = Quaternion.Euler (0, 180, 0);
		}else if(Input.GetKey(KeyCode.RightArrow)){
			horizontal = -1;
			move = 1;
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);	
			//rotacao = Quaternion.Euler (0, 0, 0);
			this.gameObject.transform.eulerAngles = new Vector2(0, 0);
		}else if(Input.GetKey(KeyCode.UpArrow)){
			move = 1;
			//Debug.Log (horizontal);
			float test = (horizontal == 1) ? -Time.deltaTime : Time.deltaTime;
			//Debug.Log (test);
			this.gameObject.transform.Translate (Vector3.forward * test * 6.0f);	
		}else if(Input.GetKey(KeyCode.DownArrow)){
			move = 1;
			//Debug.Log (horizontal);
			float test = (horizontal == 1) ? -Time.deltaTime : Time.deltaTime;
			//Debug.Log (test);
			this.gameObject.transform.Translate (Vector3.back * test * 6.0f);	
		}
		//Quaternion.Slerp (transform.rotation, rotacao ,Time.deltaTime);
		animator.SetFloat("movimento", move);
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
			//Debug.Log ("1");
		} else if (framesDash < 3.0f) {
			velocidade = 600.0f;
			//Debug.Log ("2");
		} else {
			velocidade = 1000.0f;
			//Debug.Log ("3");
		}
		rb.AddForce(transform.right * velocidade );
	}
}

