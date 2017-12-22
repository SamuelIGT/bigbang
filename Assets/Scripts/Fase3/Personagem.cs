using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

	private float vida;
	private bool statusRecebendoDano;

	// Use this for initialization
	void Start ()
	{
		if (this.gameObject.tag == "Inimigo") {
			setVida (6);
		}
		if (this.gameObject.tag == "Player") {
			setVida (30);
		}
		if (this.gameObject.tag == "Minion") {
			setVida (2);
		}

		this.statusRecebendoDano = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public float getVida ()
	{
		return this.vida;
	}

	public void setVida (float vida)
	{
		this.vida = vida;
	}

	public bool getStatusRecebendoDano ()
	{
		return this.statusRecebendoDano;
	}

	public void setStatusRecebendoDano (bool novoStatus)
	{
		this.statusRecebendoDano = novoStatus;
	}
}
