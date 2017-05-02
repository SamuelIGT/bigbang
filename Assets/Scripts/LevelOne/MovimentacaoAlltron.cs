using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoAlltron : MonoBehaviour {

	private bool andando;
	private Animator animator;
	private GameObject cabeca;
	private ManagerVortex manager;
	private float limiteDireita;
	private float limiteEsquerda;
	private float velocidade;

	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag ("ManagerAla").GetComponent<ManagerVortex> ();
		andando = false;
		animator = GetComponent<Animator> ();
		cabeca = GameObject.Find ("Alltron_fase1_sprite_0");
		limiteDireita = 130;
		limiteEsquerda = -140;
		velocidade = 0.6f;
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

		if (Input.GetKey (KeyCode.RightArrow)) {
			Vector3 posicaoCabeca = cabeca.transform.position;
			cabeca.transform.position = new Vector3(posicaoCabeca.x, posicaoCabeca.y, -1);
			this.gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
	
			if (posicaoAtual.x <= limiteDireita) {
				andando = true;
				this.gameObject.transform.Translate (new Vector3 (velocidade, 0, 0));
			}
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			Vector3 posicaoCabeca = cabeca.transform.position;
			cabeca.transform.position = new Vector3(posicaoCabeca.x, posicaoCabeca.y, -1);
			this.gameObject.transform.rotation = new Quaternion (0, -180, 0, 0);

			if (posicaoAtual.x >= limiteEsquerda) {
				andando = true;
				this.gameObject.transform.Translate (new Vector3 (velocidade, 0, 0));
			}
		} else {
			andando = false;
		}
	}
		
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Vortex") {
			if (Input.GetKeyUp (KeyCode.Space)) {
				Vector3 posicaoTeletransporte = this.manager.teletransportarVortex (col.gameObject);
				this.gameObject.transform.position = new Vector3 (posicaoTeletransporte.x, posicaoTeletransporte.y - 8.5f, 
					this.gameObject.transform.position.z);
			}
		}
	}

}