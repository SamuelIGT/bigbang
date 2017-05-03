using UnityEngine;
using System.Collections;

public class MovimentaCamera : MonoBehaviour {

	float deslocamento;
	public float velocidade;
	//public Vector3 posicaoAlta;
	//public Vector3 posicaoBaixa;
	bool subindo = false;
	bool descendo = false;
	GameObject mainCamera;
	// Use this for initialization
	void Start () {
		deslocamento = Time.deltaTime * velocidade;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.W) && !subindo && !descendo) {
			this.subindo = true;

		} else if (Input.GetKeyDown (KeyCode.S) && !subindo && !descendo) {
			this.descendo = true;
		}
		if (subindo) {
			this.SobeCamera ();
		}
		if (descendo) {
			this.DesceCamera ();
		}
	}


	public void SobeCamera() {
//		mainCamera.transform.position = Vector3.MoveTowards (mainCamera.transform.position, posicaoAlta, deslocamento);
//		if (mainCamera.transform.position.Equals (this.posicaoAlta)) {
//			this.subindo = false;
//		}
	}

	public void DesceCamera() {
//		mainCamera.transform.position = Vector3.MoveTowards (mainCamera.transform.position, posicaoBaixa, deslocamento);
//		if (mainCamera.transform.position.Equals (this.posicaoBaixa)) {
//			this.descendo = false;
//		}
	}
}
