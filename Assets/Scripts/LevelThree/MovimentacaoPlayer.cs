using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class MovimentacaoPlayer : MonoBehaviour {

	public Transform spritePlayer;
	private Animator animator;

	private float framesDash;
	private int horizontal;
	private float move;
	private bool aplicandoDash;
	private Rigidbody rb;

	Quaternion rotacao;

	void Start () {
		horizontal = 1;
		animator = spritePlayer.GetComponent<Animator>();
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		move = 0;
		aplicandoDash = false;

		if(Input.GetKey(KeyCode.LeftArrow)){
			horizontal = -1;
			move = 1;
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);
			this.gameObject.transform.eulerAngles = new Vector2(0, 180);
		}else if(Input.GetKey(KeyCode.RightArrow)){
			horizontal = 1;
			move = 1;
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);	
			this.gameObject.transform.eulerAngles = new Vector2(0, 0);
		}else if(Input.GetKey(KeyCode.UpArrow)){
			move = 1;
			float test = verificaHorizontal ();
			this.gameObject.transform.Translate (Vector3.forward * test * 6.0f);	
		}else if(Input.GetKey(KeyCode.DownArrow)){
			move = 1;
			float test = verificaHorizontal ();
			this.gameObject.transform.Translate (Vector3.back * test * 6.0f);	
		}
			
		animator.SetFloat("movimento", move);

		if (Input.GetKeyDown (KeyCode.Space)) {
			framesDash = Time.timeSinceLevelLoad;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			framesDash = Time.timeSinceLevelLoad - framesDash;
			aplicandoDash = true;
			animator.SetBool ("dash", aplicandoDash);	
			this.dash ();
			framesDash = 0.0f;
		}

		animator.SetBool ("dash", aplicandoDash);
	}

	public void dash(){
		Debug.Log ("dash: " + framesDash);
		float velocidade; 
		if (framesDash < 1.0f) {
			velocidade = 2.0f;
			Debug.Log ("1");
		} else if (framesDash < 3.0f) {
			velocidade = 6.0f;
			Debug.Log ("2");
		} else {
			velocidade = 10.0f;
			Debug.Log ("3");
		}
		Debug.Log ("velocidade: " + velocidade);
		this.gameObject.GetComponent<NavMeshAgent>().Move(Vector3.right * velocidade * horizontal);
	}

	public float verificaHorizontal(){
		if (this.horizontal == 1) {
			return Time.deltaTime;
		} else {
			return -Time.deltaTime;
		}
	}

}

