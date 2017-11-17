using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaDeDano : MonoBehaviour
{
	private float valorDano;
	private float tempoUltimoDano;
	private SistemaDeDano sdPlayer;
	private SistemaDeDano sdInimigo;
	private InstanciadorDeGameObjects instanciador;
	private Personagem personagem;
	private ManagerHud managerHud;

	// Use this for initialization
	void Start ()
	{
		this.valorDano = 1.0f;
		this.tempoUltimoDano = Time.timeSinceLevelLoad;
		this.personagem = this.gameObject.GetComponent<Personagem> ();
		sdPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<SistemaDeDano> ();
		instanciador = GameObject.FindGameObjectWithTag ("Instanciador").GetComponent<InstanciadorDeGameObjects> ();
		managerHud = GameObject.FindGameObjectWithTag ("ManagerModal").GetComponent<ManagerHud> ();
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

//		if (personagem.getVida () <= 0 && this.gameObject.tag == "Player") {
//			SceneManager.LoadScene ("EndGameScene");
//		}
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

	public void aplicarForcaDano ()
	{
		int direcaoHorizontal = 0;
		if (this.gameObject.tag == "Minion") {
			direcaoHorizontal = this.gameObject.GetComponent<Minion> ().getHorizontal ();
		}
		if (this.gameObject.tag == "Inimigo") {
			direcaoHorizontal = this.gameObject.GetComponent<Darkon> ().getHorizontal ();
		}
		if (this.gameObject.tag == "Player") {
			direcaoHorizontal = this.gameObject.GetComponent<MovimentacaoPlayer> ().getHorizontal ();
		}

		if (direcaoHorizontal != 0) {
			Vector3 posicaoAtual = this.gameObject.transform.position;
			this.gameObject.transform.position = new Vector3 (posicaoAtual.x + 0.5f * direcaoHorizontal, posicaoAtual.y, posicaoAtual.z);
		}
	}

	public void verificarDestroyGameObject ()
	{
		if (personagem.getVida () <= 0) {
			if (this.gameObject.tag == "Player") {
				SceneManager.LoadScene ("EndGameScene");
			}
			if (this.gameObject.tag == "Inimigo") {
				managerHud.aumentarBarraProgresso (0.25f);
				instanciador.habilitarVortex ();
			}
			if (this.gameObject.tag == "Minion") {
				instanciador.incrementarQuantMinionsMortos ();
				managerHud.aumentarBarraProgresso (0.08f);
				instanciador.respawnInimigo ();
			}
			Destroy (this.gameObject);
		}
	}

}