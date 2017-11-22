using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MovimentacaoPlayer : MonoBehaviour
{

	private Animator animator;
	private float framesDash;
	private int horizontal;
	private float move;
	private bool aplicandoDash;
	private bool acumulandoDash;
	private bool atacando;
	private float tempoUltimoDash;
	private float velocidadeDash;
	private Vector3 posicaoDestino;
	private float limiteDireita = 38.5f;
	private float limiteEsquerda = -38.5f;
	private float velocidadeDirecaoHorizontal = 5.0f;
	private float velocidadeDirecaoVertical = 7.0f;

	Quaternion rotacao;

	void Start ()
	{
		horizontal = 1;
		animator = this.gameObject.GetComponent<Animator> ();
		aplicandoDash = false;
		acumulandoDash = false;
		this.atacando = false;
		this.tempoUltimoDash = Time.timeSinceLevelLoad;
	}

	// Update is called once per frame
	void Update ()
	{
		move = 0;
		animator.SetFloat ("movimento", move);

		if (aplicandoDash == true) {
			//Debug.Log ("antes: " + this.gameObject.transform.position.x + " - " + this.posicaoDestino.x);
			aplicarDash ();
			//Debug.Log ("depois: " + this.gameObject.transform.position.x + " - " + this.posicaoDestino.x);

		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				acumulandoDash = true;
				framesDash = Time.timeSinceLevelLoad;
			}
			if (!acumulandoDash && move == 0) {
				if (Input.GetKey (KeyCode.LeftArrow)) {
					horizontal = -1;
					move = 1;
					this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * velocidadeDirecaoHorizontal);
					this.gameObject.transform.eulerAngles = new Vector2 (0, 180);
				} else if (Input.GetKey (KeyCode.RightArrow)) {
					horizontal = 1;
					move = 1;
					this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * velocidadeDirecaoHorizontal);	
					this.gameObject.transform.eulerAngles = new Vector2 (0, 0);
				} else if (Input.GetKey (KeyCode.UpArrow)) {
					move = 1;
					float test = verificaHorizontal ();
					this.gameObject.transform.Translate (Vector3.forward * test * velocidadeDirecaoVertical);	
				} else if (Input.GetKey (KeyCode.DownArrow)) {
					move = 1;
					float test = verificaHorizontal ();
					this.gameObject.transform.Translate (Vector3.back * test * velocidadeDirecaoVertical);	
				}
				animator.SetFloat ("movimento", move);
			} else {
				if (Input.GetKeyUp (KeyCode.Space)) {
					acumulandoDash = false;
					aplicandoDash = true;
					this.atacando = true;
					framesDash = Time.timeSinceLevelLoad - framesDash;
					calcularDestinoDash ();
					this.animator.SetFloat ("dash", framesDash);
				}
			}
		}
	}

	public void aplicarDash ()
	{
		this.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position, posicaoDestino, 0.1f);
		if (this.gameObject.transform.position.x == this.posicaoDestino.x) {
			pararDash ();
			this.atacando = false;
		}
	}

	public void pararDash ()
	{
		this.aplicandoDash = false;
		framesDash = 0.0f;
		this.animator.SetFloat ("dash", framesDash);
		this.posicaoDestino = new Vector3 ();
		this.tempoUltimoDash = Time.timeSinceLevelLoad;
	}

	public void calcularVelocidadeDash ()
	{
		if (framesDash < 1.0f) {
			this.velocidadeDash = 2.0f;
		} else if (framesDash < 3.0f) {
			this.velocidadeDash = 6.0f;
		} else {
			this.velocidadeDash = 10.0f;
		}
	}

	public void calcularDestinoDash ()
	{
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

	public float verificaHorizontal ()
	{
		if (this.horizontal == 1) {
			return Time.deltaTime;
		} else {
			return -Time.deltaTime;
		}
	}

	public float getVelocidadeDash ()
	{
		return this.velocidadeDash;
	}

	public bool getAplicandoDash ()
	{
		return this.aplicandoDash;
	}

	public bool getAtacando ()
	{
		return this.atacando;
	}

	// Retorna um inteiro contendo a direção horizontal do Player(Alltron).
	public int getHorizontal ()
	{
		return this.horizontal;
	}

	void OnCollisionEnter (Collision other)
	{	
		pararDash ();
		Debug.Log (this.atacando);
		if (atacando == true && (other.gameObject.tag == "Minion" || other.gameObject.tag == "Inimigo")) {
			SistemaDeDano SDano = other.gameObject.GetComponent<SistemaDeDano> ();
			SDano.perderVida ();
			this.atacando = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		pararDash ();
		if (other.gameObject.tag == "Vortex") {
			SceneManager.LoadScene ("WinGameScene");
		}
	}
}

