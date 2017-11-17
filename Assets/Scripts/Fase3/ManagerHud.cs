using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHud : MonoBehaviour
{

	public GameObject spriteInicioBarra;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void aumentarBarraProgresso (float valor)
	{
		Vector3 escalaAtual = this.spriteInicioBarra.gameObject.transform.localScale;
		this.spriteInicioBarra.gameObject.transform.localScale = new Vector3 (escalaAtual.x + valor, escalaAtual.y, escalaAtual.z);
	}
}
