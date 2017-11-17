using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{

	public float velocidade;

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.right * velocidade * Time.deltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") {
			SistemaDeDano SDano = other.gameObject.GetComponent<SistemaDeDano> ();
			SDano.perderVida ();
		}
	}
		
}
