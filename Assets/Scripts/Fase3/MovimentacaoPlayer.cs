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
	private bool acumulandoDash;
	private float velocidadeDash;
	private Rigidbody rb;
	private Vector3 posicaoDestino;
	private float limiteDireita = 38.5f;
	private float limiteEsquerda = -38.5f;

	Quaternion rotacao;

	void Start () {
		horizontal = 1;
		animator = spritePlayer.GetComponent<Animator>();
		rb = this.gameObject.GetComponent<Rigidbody> ();
		aplicandoDash = false;
		acumulandoDash = false;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("1dash" + animator.GetBool("dash"));
		move = 0;
		animator.SetFloat ("movimento", move);

		if (aplicandoDash) {
			dash ();
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				acumulandoDash = true;
				framesDash = Time.timeSinceLevelLoad;
			}
			if (!acumulandoDash) {
				if (Input.GetKey (KeyCode.LeftArrow)) {
					horizontal = -1;
					move = 1;
					this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);
					this.gameObject.transform.eulerAngles = new Vector2 (0, 180);
				} else if (Input.GetKey (KeyCode.RightArrow)) {
					horizontal = 1;
					move = 1;
					this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);	
					this.gameObject.transform.eulerAngles = new Vector2 (0, 0);
				} else if (Input.GetKey (KeyCode.UpArrow)) {
					move = 1;
					float test = verificaHorizontal ();
					this.gameObject.transform.Translate (Vector3.forward * test * 6.0f);	
				} else if (Input.GetKey (KeyCode.DownArrow)) {
					move = 1;
					float test = verificaHorizontal ();
					this.gameObject.transform.Translate (Vector3.back * test * 6.0f);	
				}
				animator.SetFloat ("movimento", move);
			} else {
				if (Input.GetKeyUp (KeyCode.Space)) {
					acumulandoDash = false;
					aplicandoDash = true;
					framesDash = Time.timeSinceLevelLoad - framesDash;
					calcularDestinoDash ();
					Debug.Log ("culpado");
					animator.SetBool ("dash", aplicandoDash);
				}
			}
		}
	}

	public float getVelocidadeDash(){
		return this.velocidadeDash;
	}

	public void dash(){
		Vector3 posicaoAtual = this.gameObject.transform.position;
		if (posicaoAtual.x != this.posicaoDestino.x) {
			//Debug.Log ("antes: "  + this.gameObject.transform.position.x + "destino: " + this.posicaoDestino.x);
			this.gameObject.transform.position = Vector3.MoveTowards (posicaoAtual, posicaoDestino, 0.1f);
			//Debug.Log ("depois: "  + this.gameObject.transform.position.x + "destino: " + this.posicaoDestino.x);
		} else {
			this.aplicandoDash = false;
			animator.SetBool ("dash", false);
			framesDash = 0.0f;
			//Debug.Log ("AQUI!! CERTO");
		}
	}

	public void calcularVelocidadeDash(){
		if (framesDash < 1.0f) {
			this.velocidadeDash = 2.0f;
		} else if (framesDash < 3.0f) {
			this.velocidadeDash = 6.0f;
		} else {
			this.velocidadeDash = 10.0f;
		}
	}

	public void calcularDestinoDash(){
		calcularVelocidadeDash ();
		if (this.transform.position.x + velocidadeDash * horizontal < limiteEsquerda
		    || this.transform.position.x + velocidadeDash * horizontal > limiteDireita) {
			if (horizontal == -1) {
				this.posicaoDestino = new Vector3 (limiteEsquerda, this.gameObject.transform.position.y,
					this.gameObject.transform.position.z);
			} else {
				this.posicaoDestino = new Vector3 (limiteDireita, this.gameObject.transform.position.y,
					this.gameObject.transform.position.z);
			}
		} else {
			this.posicaoDestino = new Vector3 (this.transform.position.x + velocidadeDash * horizontal, this.gameObject.transform.position.y,
				this.gameObject.transform.position.z);
		}
	}

	public float verificaHorizontal(){
		if (this.horizontal == 1) {
			return Time.deltaTime;
		} else {
			return -Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Minion" || other.gameObject.tag == "Inimigo") {
//			this.posicaoDestino = this.transform.position;
//			this.aplicandoDash = false;
//			animator.SetBool ("dash", aplicandoDash);
//			framesDash = 0.0f;
//			move = 0;
//			Debug.Log ("dash: " + aplicandoDash + " move: " + move + " acumulandoDash: " + acumulandoDash);
			SistemaDeDano SDano = other.gameObject.GetComponent<SistemaDeDano> ();
			SDano.perdeVida ();
		}
	}

	void OnTriggerEnter(Collider col){
		//Debug.Log ("antes dash: " + aplicandoDash + " move: " + move + " acumulandoDash: " + acumulandoDash);
		//Debug.Log ("antes trigger: "  + this.gameObject.transform.position.x + "destino: " + this.posicaoDestino.x);
		this.posicaoDestino = this.transform.position;
		this.aplicandoDash = false;
		animator.SetBool("dash", false);
		Debug.Log ("2dash" + animator.GetBool("dash"));
		framesDash = 0.0f;
		move = 0;
		//Debug.Log ("depois dash: " + aplicandoDash + " move: " + move + " acumulandoDash: " + acumulandoDash);
		//Debug.Log ("depois: "  + this.gameObject.transform.position.x + "destino: " + this.posicaoDestino.x);
	}

}

