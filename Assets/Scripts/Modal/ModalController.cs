using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalController : MonoBehaviour {

	public Text temperatura;
	public Text alavancas;
	private ModalPanel modalPanel;
	public GameObject alltron;

	// Use this for initialization
	void Start () {
		this.temperatura.text = "Temperatura: ";
		this.alavancas.text = "Alavancas: ";
		alltron.GetComponent<MovimentacaoAlltron> ().setEscondido (true);
		modalPanel = ModalPanel.Instance ();
		modalPanel.Choice ("Objetivos da fase: desativar todas as alavancas para diminuir a temperatura e ganhar a fase."
							+ "\nGame Over: ao tocar algum inimigo");
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
