using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeDanoFase4 : MonoBehaviour
{

	private float valorDano;
	private float tempoUltimoDano;
	private SistemaDeDanoFase4 sdPlayer;
	private Personagem personagem;

	// Use this for initialization
	void Start ()
	{
		this.valorDano = 1.0f;
		this.tempoUltimoDano = Time.timeSinceLevelLoad;
		this.personagem = this.gameObject.GetComponent<Personagem> ();
		sdPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<SistemaDeDanoFase4> ();
	}

	void Update ()
	{   
		if (this.tempoUltimoDano > 0 && (Time.timeSinceLevelLoad - this.tempoUltimoDano >= 1.5f)) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
			this.tempoUltimoDano = 0.0f;
			personagem.setStatusRecebendoDano (false);

			// Verifica se as vidas de um personagem chegaram a 0 e elimina o gameobject do personagem.
			verificarDestroyGameObject ();		 
		}
	}

	public void perderVida ()
	{
		if (personagem.getVida () > 0 && personagem.getStatusRecebendoDano () == false) {
			this.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
			personagem.setStatusRecebendoDano (true);
			personagem.setVida (personagem.getVida () - valorDano);
			this.tempoUltimoDano = Time.timeSinceLevelLoad;
		}
	}

	public void verificarDestroyGameObject ()
	{
		if (personagem.getVida () <= 0) {
			if (this.gameObject.tag == "Player") {
				ControllerScene.getInstance ().runEndGameScene ();
			}
			Destroy (this.gameObject);
		}
	}
}
