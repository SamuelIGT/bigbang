using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalController : MonoBehaviour {

	private ModalPanel modalPanel;
	public GameObject alltron;

	// Use this for initialization
	void Start () {
		alltron.GetComponent<MovimentacaoAlltron> ().setEscondido (true);
		modalPanel = ModalPanel.Instance ();
		modalPanel.Choice ("Objetivos desta fase: desativar todas as alavancas para diminuir a temperatura e ganhar a fase."
							+ " Game Over: ao tocar algum inimigo");
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.H)) {
			alltron.GetComponent<MovimentacaoAlltron> ().setEscondido (true);
			modalPanel.modalPanelObject.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}
}
