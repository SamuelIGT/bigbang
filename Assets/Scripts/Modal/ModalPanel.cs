using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class ModalPanel : MonoBehaviour
{

	public Image iconImage;
	public Button yesButton;
	public Button noButton;
	public Button cancelButton;
	public GameObject modalPanelObject;
	private ModalController modalController;

	private static ModalPanel modalPanel;

	void Start ()
	{
		modalController = GameObject.FindGameObjectWithTag ("ManagerModal").GetComponent<ModalController> (); 
	}

	public static ModalPanel Instance ()
	{
		if (!modalPanel) {
			modalPanel = FindObjectOfType (typeof(ModalPanel)) as ModalPanel;
			if (!modalPanel)
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
		}

		return modalPanel;
	}

	// Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
	public void Choice ()
	{
		modalPanelObject.SetActive (true);

		yesButton.onClick.RemoveAllListeners ();
		//yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener (ClosePanel);

		noButton.onClick.RemoveAllListeners ();
		//noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);

		cancelButton.onClick.RemoveAllListeners ();
		//cancelButton.onClick.AddListener (cancelEvent);
		cancelButton.onClick.AddListener (ClosePanel);

		yesButton.gameObject.SetActive (true);
		noButton.gameObject.SetActive (false);
		cancelButton.gameObject.SetActive (false);
	}

	public void ClosePanel ()
	{
		modalPanelObject.SetActive (false);
		Time.timeScale = 1.0f;
		if (modalController.fase == 1) {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<MovimentacaoAlltron> ().setEscondido (false);
		}
		modalController.mostrarGameObjectFase3 ();
	}
}