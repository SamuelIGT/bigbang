using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoBolaScript : MonoBehaviour {

	int direcao = 0;
	float TTL;
	// Use this for initialization
	void Start () {
		TTL = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad - TTL > 10) {
			Destroy (this.gameObject);
		}
		this.transform.Translate(new Vector3(direcao * 0.1f, 0.0f, 0.0f));
	}

	public void SetDirecao(int direcao){
		this.direcao = direcao;
	}

	public void OnTriggerEnter(Collider col) {
		
		if (col.gameObject.tag == "Player") {
			Debug.Log ("REMOVER vida do jogador");
			Destroy (this.gameObject);
		}
	}
}
