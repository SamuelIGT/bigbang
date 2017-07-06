using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class inimigo : MonoBehaviour {

	public GameObject jogador;
	private int horizontal;
	private float velocidade = 0.05f;
	// Use this for initialization
	void Start () {
		horizontal = 1;
		jogador = GameObject.FindWithTag ("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float distancia = (this.gameObject.transform.position - jogador.gameObject.transform.position).magnitude;

		if (distancia < 20.0f) {
			NavMeshAgent agente = this.gameObject.GetComponent<NavMeshAgent> ();
			agente.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position,
				jogador.transform.position, velocidade);
//			agente.SetDestination (jogador.transform.position);
		} else {
			if(Random.Range (1, 1000) == 1){
				horizontal = horizontal * -1;
			}
			this.gameObject.transform.Translate (Vector3.right * velocidade * horizontal);
		}
	}
}
