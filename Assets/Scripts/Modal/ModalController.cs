using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalController : MonoBehaviour {

	public Text[] elementosTextoUI;
	public int fase;
	private ModalPanel modalPanel;
	public GameObject alltron;

	// Use this for initialization
	void Start () {		
		modalPanel = ModalPanel.Instance ();
		editarComportamentoAlltron (fase);
		carregarTextoModal (fase);
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.H)) {
			editarComportamentoAlltron (fase);
			modalPanel.modalPanelObject.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}

	public void carregarTextoModal(int fase){
		switch(fase){
		case 1:
			modalPanel.Choice ("Desative todas as alavancas para esfriar o mundo e permitir a criação das partículas."
			+ " Use as cavernas para se esconder dos Minions.",
				" Cuidado com os Minions do Exército Darkon! Eles podem matar o Alltron apenas encostando nele.");
			break;
		case 3:
			modalPanel.Choice ("Derrote os Minions e o General Darkon para permitir a liberação dos elétrons que estão aprisionados.",
				"Cuidado com os ataques dos Minions e do General Darkon! O Alltron morrerá quando sofrer três ataques.");
			break;
		default:
			modalPanel.Choice ("Desate todas as alavancas para esfriar o mundo e permitir a criação das partículas."
				+ " Use as cavernas para se esconder dos Minions.",
				" Cuidado com os Minions do Exército Darkon! Eles podem matar o Alltron apenas encostando nele.");
			break;
		}

	}

	public void editarComportamentoAlltron(int fase){
		switch(fase){
		case 3:
			
			break;
		default:
			alltron.GetComponent<MovimentacaoAlltron> ().setEscondido (true);	
			break;
		}
	}
}
