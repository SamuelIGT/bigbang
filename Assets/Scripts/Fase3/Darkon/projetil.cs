using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour {

	public float velocidade;
	public int dano;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * velocidade * Time.deltaTime);
	}
		
}
