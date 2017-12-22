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
		editarComportamentoAlltron ();
		modalPanel.Choice ();
		Time.timeScale = 0.0f;
		esconderGameObjectFase3 ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.H)) {
			editarComportamentoAlltron ();
			modalPanel.modalPanelObject.SetActive (true);
			Time.timeScale = 0.0f;
			esconderGameObjectFase3 ();
		}
	}

	public void editarComportamentoAlltron ()
	{
		if (this.fase == 1) {
			alltron.GetComponent<MovimentacaoAlltron> ().setEscondido (true);	
		}
	}

	public void esconderGameObjectFase3 ()
	{
		GameObject[] minions = GameObject.FindGameObjectsWithTag ("Minion");
		GameObject darkon = GameObject.FindGameObjectWithTag ("Inimigo");

		if (minions != null) {
			for (int i = 0; i < minions.Length; i++) {
				if (this.fase == 1) {
					minions [i].GetComponent<MinionStealthScript> ().setEstadoAtivo (false);
				}
				if (this.fase == 3) {
					minions [i].GetComponent<Minion> ().setEstadoAtivo (false);
				}

			}
		}
		if (darkon != null) {
			darkon.GetComponent<Darkon> ().setEstadoAtivo (false);
		}
	}

	public void mostrarGameObjectFase3 ()
	{
		GameObject[] minions = GameObject.FindGameObjectsWithTag ("Minion");
		GameObject darkon = GameObject.FindGameObjectWithTag ("Inimigo");
	
		if (minions != null) {
			for (int i = 0; i < minions.Length; i++) {
				if (this.fase == 1) {
					minions [i].GetComponent<MinionStealthScript> ().setEstadoAtivo (true);
				}
				if (this.fase == 3) {
					minions [i].GetComponent<Minion> ().setEstadoAtivo (true);
				}
			}
		}
		if (darkon != null) {
			darkon.GetComponent<Darkon> ().setEstadoAtivo (true);
		}
	}
}
