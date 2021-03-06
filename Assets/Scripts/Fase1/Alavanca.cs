﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour {

	public int id;
	private bool ativada;
	private ManagerBackground managerBackground;
	private ManagerAla managerAla;
	private Animator animator;

	// Use this for initialization
	void Start () {
		ativada = false;
		managerBackground = GameObject.FindGameObjectWithTag ("ManagerBackground").GetComponent<ManagerBackground> ();
		managerAla = GameObject.FindGameObjectWithTag ("ManagerAla").GetComponent<ManagerAla> ();
		animator = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyUp (KeyCode.Space) && !ativada) {
				managerBackground.mudarCenario (this.id);
				managerAla.carregarVortex (this.id);
				animator.SetInteger("qtdAlavancas", managerBackground.getAlavancasAtivadas());
				ativada = true;
				animator.SetBool ("ativada", true);

			}
		}
	}
		
}
