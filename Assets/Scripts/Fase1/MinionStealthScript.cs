﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MinionStealthScript : MonoBehaviour
{

	public float velocidade = 2.0f;
	public bool direcao;
	public float limiteDireita;
	public float limiteEsquerda;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{

		if (direcao) {
			transform.eulerAngles = new Vector2 (0, 0);
		} else {
			transform.eulerAngles = new Vector2 (0, 180);
		}
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);

		Vector3 posicaoAtual = transform.position;

		if (posicaoAtual.x >= limiteDireita || posicaoAtual.x <= limiteEsquerda) {
			direcao = !direcao;
		}
	}

	void OnCollisionEnter (Collision colisor)
	{
		if (colisor.gameObject.tag == "Player") {
			//var player = colisor.gameObject;
			ControllerScene.getInstance ().runEndGameScene ();
		}
	}
}
