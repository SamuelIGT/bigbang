using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaDeDano : MonoBehaviour{

    public float vida;
	private float valorDano;
	private float tempoUltimoDano;
	private float tempoNovoDano;

	// Use this for initialization
	void Start(){
		this.valorDano = 1.0f;
		this.tempoUltimoDano = Time.timeSinceLevelLoad;
		this.tempoNovoDano = 10.0f;
	}

	void Update(){    
		if (this.gameObject.tag == "Player" && this.vida <= 0) {
			SceneManager.LoadScene("EndGameScene");
		}
		if (this.gameObject.tag == "Inimigo" && this.vida <= 0) {
			SceneManager.LoadScene ("WinGameScene");
		}
	}

	public float getVida(){
		return this.vida;
	}

	public void perdeVida(){
		if (verificaPerderVida ()) {
			Debug.Log ("Vida atual: " + this.vida);
			this.vida = this.vida - valorDano;
			Debug.Log ("Vida depois do dano: " + vida);
			Debug.Log ("-- Dano causado: " + valorDano + " --");		
		}
    }

	public bool verificaPerderVida(){
		if (Time.timeSinceLevelLoad - this.tempoUltimoDano > this.tempoNovoDano) {
			this.tempoUltimoDano = Time.timeSinceLevelLoad;
			return true;
		} else {
			return false;
		}
	}

    //UI da vida atualiza em uma função aqui

}