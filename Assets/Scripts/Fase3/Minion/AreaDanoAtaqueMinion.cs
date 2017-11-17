using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDanoAtaqueMinion : MonoBehaviour
{

	float estado = 0;
	// 1 expandir; -1 retrarir; 0= neutro
	float areaMax = 4.0f;
	private MeshRenderer meshRenderer;
	private bool atacando;
	
	// Use this for initialization
	void Start ()
	{
		estado = 0;
		meshRenderer = this.gameObject.GetComponent<MeshRenderer> ();
		meshRenderer.enabled = false;
		this.atacando = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.gameObject.transform.localScale += new Vector3 (0.1f * estado, 0.0f, 0.1f * estado);
		if (this.gameObject.transform.localScale.x > areaMax) {
			estado = -1;
		} else if (this.gameObject.transform.localScale.x <= 1.0f) {
			estado = 0;
			meshRenderer.enabled = false;
			this.atacando = false;
		}
	}

	public void Ataque ()
	{
		if (estado == 0) {
			this.estado = 1;
			this.atacando = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (this.atacando == true && other.gameObject.tag == "Player") {
			meshRenderer.enabled = true;
			SistemaDeDano SDano = other.gameObject.GetComponent<SistemaDeDano> ();
			SDano.perderVida ();
			this.atacando = false;
		}
	}
		
}
