using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
<<<<<<< HEAD:Assets/inimigo.cs

		if (distancia < 20.0f) {
			NavMeshAgent agente = this.gameObject.GetComponent<NavMeshAgent> ();
			agente.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position,
				jogador.transform.position, velocidade);
//			agente.SetDestination (jogador.transform.position);
		} else {
=======
		Debug.Log (distancia);
		if (distancia > 20.0f) {
>>>>>>> baa68e175180ae3a7a9fd38d0479fde638f7a5ed:Assets/Scripts/LevelThree/inimigo.cs
			if(Random.Range (1, 1000) == 1){
				horizontal = horizontal * -1;
			}
			this.gameObject.transform.Translate (Vector3.right * velocidade * horizontal);
		}
		else if (distancia > 5.0f) {
			NavMeshAgent agente = this.gameObject.GetComponent<NavMeshAgent> ();
			agente.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position,
				jogador.transform.position, velocidade);
		} else {
			Debug.Log ("atacar");
			//tocar animação de ataque
			this.gameObject.GetComponent<CapsuleCollider>().radius += 0.25f;
			Debug.Log (this.gameObject.GetComponent<CapsuleCollider> ().radius += 0.5f);	
		}
	}
<<<<<<< HEAD:Assets/inimigo.cs
=======

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			SceneManager.LoadScene ("EndGameScene");
		}
	}
>>>>>>> baa68e175180ae3a7a9fd38d0479fde638f7a5ed:Assets/Scripts/LevelThree/inimigo.cs
}
