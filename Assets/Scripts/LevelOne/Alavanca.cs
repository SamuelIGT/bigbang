using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour {

	public int id;
	private bool ativada;
	private ManagerBackground managerBackground;
	private ManagerAla managerAla;
	private Animation animation;

	// Use this for initialization
	void Start () {
		ativada = false;
		managerBackground = GameObject.FindGameObjectWithTag ("ManagerBackground").GetComponent<ManagerBackground> ();
		managerAla = GameObject.FindGameObjectWithTag ("ManagerAla").GetComponent<ManagerAla> ();
		animation = this.gameObject.GetComponent<Animation> ();
		animation.Play ("ativadaBranco");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyUp (KeyCode.Space) && !ativada) {
				switch(managerBackground.getAlavancasAtivadas()){
				case 1: 
					this.animation.Play ("ativadaRoxa");
					break;
				case 2:
					this.animation.Play ("ativadaAzul");
					break;
				default:
					Debug.Log (managerBackground.getAlavancasAtivadas());
					this.gameObject.GetComponent<Animation> ().Play("ativadaBranco");
					//this.animation.Play ("ativadaBranco");
					break;
				}
					
				ativada = true;
				managerAla.carregarVortex (this.id);
				managerBackground.mudarCenario (this.id);
			}
		}
	}

//	public void alteraCor(){
//		this.animation.
//	}
		
}
