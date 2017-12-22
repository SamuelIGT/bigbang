using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorDeGameObjects : MonoBehaviour
{

	private int quantidadeMinionsCena;
	private int quantidadeMinionsGerados;
	private int quantidadeMaxMinions;
	private int quantidadeMinionsTotal;
	private int quantidadeMinionsMortos;
	public GameObject inimigoDarkon;
	public GameObject vortex;
	public GameObject prefabMinion;

	// Use this for initialization
	void Start ()
	{
		this.quantidadeMinionsCena = 3;
		this.quantidadeMinionsGerados = 0;
		this.quantidadeMaxMinions = 10;
		this.quantidadeMinionsMortos = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Realiza o respawn dos Minions e controla a visibilidade do Darkon.
	public void respawnInimigo ()
	{
		this.quantidadeMinionsTotal = this.quantidadeMinionsCena + this.quantidadeMinionsGerados;

		// Instancia um novo Minion se a quantidade de Minions gerados na cena for menor do que 10.
		if (quantidadeMinionsTotal < quantidadeMaxMinions) {
			GameObject minion = Instantiate (prefabMinion) as GameObject;
			minion.transform.position = new Vector3 (3.0f, 0.0f, 0.0f);
			incrementarQuantMinionsGerados ();
		} 

		// Torna o Darkon visível se todos os Minions forem derrotados.
		else if (this.quantidadeMinionsMortos == this.quantidadeMaxMinions) {
			inimigoDarkon.gameObject.GetComponent<Personagem> ().setVida (10);
			inimigoDarkon.SetActive (true);
			inimigoDarkon.GetComponent<Darkon> ().setEstadoAtivo (true);
		}
	}

	// Habilita a visibilidade do Vortex.
	public void habilitarVortex ()
	{
		vortex.SetActive (true);
	}

	// Incrementa em 1 a quantidade de Minions que foram instanciados.
	public void incrementarQuantMinionsGerados ()
	{
		this.quantidadeMinionsGerados++;
	}

	// Incrementa em 1 a quantidade de Minions mortos.
	public void incrementarQuantMinionsMortos ()
	{
		this.quantidadeMinionsMortos++;
	}
}
