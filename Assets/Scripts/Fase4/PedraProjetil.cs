using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedraProjetil : MonoBehaviour
{

	public float velocidade;
	private int direcaoHorizontal;

	// Use this for initialization
	void Start ()
	{
		direcaoHorizontal = 1;
		Destroy (gameObject, 5f);
	}

	// Update is called once per frame
	void Update ()
	{
		Debug.Log (direcaoHorizontal);
		this.gameObject.transform.Translate (Vector3.right * this.direcaoHorizontal * this.velocidade * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			SistemaDeDanoFase4 SDano = other.gameObject.GetComponent<SistemaDeDanoFase4> ();
			SDano.perderVida ();
		}
	}

	public void setPropriedades (Vector3 posicao, int direcao, Sprite spriteDaPedra)
	{
		this.gameObject.transform.position = posicao;
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteDaPedra;

		if (direcao == 1) {
			this.direcaoHorizontal = -1;
			this.gameObject.transform.RotateAround (this.gameObject.transform.position, new Vector3 (0, 1, 0), 180);
		} else {
			this.direcaoHorizontal = 1;
			this.gameObject.transform.RotateAround (this.gameObject.transform.position, new Vector3 (0, 1, 0), 0);
		}
	}

	public int getDirecaoHorizontal ()
	{
		return this.direcaoHorizontal;
	}

	public void setDirecaoHorizontal (int direcao)
	{
		this.direcaoHorizontal = direcao;
	}

}
