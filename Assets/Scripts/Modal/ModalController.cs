using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalController : MonoBehaviour
{

	public int fase;
	private ModalPanel modalPanel;
	public GameObject alltron;

	// Use this for initialization
	void Start ()
	{		
		modalPanel = ModalPanel.Instance ();
		editarComportamentoAlltron (fase);
		modalPanel.Choice ();
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.H)) {
			editarComportamentoAlltron (fase);
			modalPanel.modalPanelObject.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}

	public void editarComportamentoAlltron (int fase)
	{
		switch (fase) {
		case 3:
			
			break;
		default:
			alltron.GetComponent<MovimentacaoAlltron> ().setEscondido (true);	
			break;
		}
	}
}
