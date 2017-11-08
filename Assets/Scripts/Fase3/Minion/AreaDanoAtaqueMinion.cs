using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDanoAtaqueMinion : MonoBehaviour
{

	float estado = 0;
	// 1 expandir; -1 retrarir; 0= neutro
	float areaMax = 4.0f;
	// Use this for initialization
	void Start ()
	{
		estado = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.gameObject.transform.localScale += new Vector3 (0.1f * estado, 0.0f, 0.1f * estado);
		if (this.gameObject.transform.localScale.x > areaMax) {
			estado = -1;
		} else if (this.gameObject.transform.localScale.x <= 1.0f) {
			estado = 0;
		}
	}

	public void Ataque ()
	{
		if (estado == 0) {
			this.estado = 1;
		}
	}



}
