using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentacaoAlltron : MonoBehaviour {

	private bool andando;
	private bool escondido;
	private Animator animator;
	private ManagerAla manager;
	private float limiteDireita;
	private float limiteEsquerda;
	private float velocidade;
	public Transform spritePlayer;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("ManagerAla").GetComponent<ManagerAla> ();
		andando = false;
		escondido = true;
		animator = spritePlayer.GetComponent<Animator> ();
		limiteDireita = 260;
		limiteEsquerda = -260;
		velocidade = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posicaoAtual = this.gameObject.transform.position;
		if (andando) {
			animator.SetBool ("andando", true);
		}
		else{
			animator.SetBool ("andando", false);
		}

		if (escondido == false) {
			if (Input.GetKey(KeyCode.RightArrow)) {
				this.gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);

				if (posicaoAtual.x <= limiteDireita) {
					andando = true;
					this.gameObject.transform.Translate (new Vector3 (velocidade, 0, 0));
				}
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				this.gameObject.transform.rotation = new Quaternion (0, -180, 0, 0);

				if (posicaoAtual.x >= limiteEsquerda) {
					andando = true;
					this.gameObject.transform.Translate (new Vector3 (velocidade, 0, 0));
				}
			} else {
				andando = false;
			}
		}
	}

	void OnTriggerStay(Collider col){
		
		if (col.gameObject.tag == "Vortex") {
			if (Input.GetKeyUp (KeyCode.Space)) {
				
				if (col.gameObject.GetComponent<Vortex> ().getId () == 4) {
					SceneManager.LoadScene ("WinGameScene");
				} else {
					Vector3 posicaoTeletransporte = this.manager.teletransportarVortex (col.gameObject);
					this.gameObject.transform.position = new Vector3 (posicaoTeletransporte.x, posicaoTeletransporte.y - 8.5f, 
						this.gameObject.transform.position.z);	
				}

			}
		}
		if (col.gameObject.tag == "Porta") {
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (escondido) {
					sairPorta ();
				} else {
					entrarPorta ();
				}
			}
		}
	}

	void entrarPorta(){
		if (!escondido) {
			Vector3 posicaoAtual = this.gameObject.transform.position;
			this.gameObject.transform.position = new Vector3 (posicaoAtual.x, posicaoAtual.y, 34.0f);
			escondido = true;
		}
	}

	void sairPorta(){
		if (escondido) {
			Vector3 posicaoAtual = this.gameObject.transform.position;
			this.gameObject.transform.position = new Vector3 (posicaoAtual.x, posicaoAtual.y, 20.0f);
			escondido = false;
		}
	}

	public void setEscondido(bool estado){
		this.escondido = estado;
	}
}