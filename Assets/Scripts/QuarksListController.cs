using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuarksListController : MonoBehaviour {
	public GameObject quarkButtonObject;

	private List<GameObject> quarksIcon;
	private List<int> quarksList;
	private int lastIndex;
	public Sprite[] quarksIcons;
	public GameStatusController gameStatusController;
	public QuarkUIButton[] quarkUIController;

	//	public float uiIconPadding = 10f;

	private enum Quarks {
		UP = 0,
		DOWN = 1,
		STRANGE = 2,
		CHARM = 3,
		BOTTOM = 4,
		TOP = 5}
	;

	// Use this for initialization
	void Start() {
		
		quarksIcon = new List<GameObject>();
		quarksList = new List<int>();
		lastIndex = -1;
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void AddQuark(int quarkType) {
		if(CheckCost(quarkType)) {
			gameStatusController.decreaseMoney(quarkUIController[quarkType].cost);

			GameObject go;
			go = Instantiate(quarkButtonObject) as GameObject;
			go.transform.SetParent(transform, false);
			go.GetComponent<Image>().sprite = quarksIcons[quarkType];
			go.GetComponent<QuarkUIIconController>().setQuarkType(quarkType);

			/*if (lastIndex >= 0) {
			//localizar o ultimo
			Vector3 posicaoUltimo = quarksIcon [lastIndex].transform.position;
			//setar posição
			go.transform.position = posicaoUltimo + new Vector3 (uiIconPadding, 0, 0);
		} else {
			go.transform.position = transform.position;
		}*/

			//adicionar na lista
			quarksIcon.Add(go);
			quarksList.Add(quarkType);
			lastIndex++;
		}
	
	}

	private bool CheckCost(int quarkType) {
		if((gameStatusController.GetCurrentMoney() - quarkUIController[quarkType].cost) >= 0) {
			return true;
		} else {
			return false;
		}
	}

	public List<int> GetQuarksList() {
		return quarksList;
	}

	public int ListSize() {
		return quarksList.Count - 1;
	}

	public void removeQuark(int instanceID) {
		for(int i = 0; i <= quarksIcon.Count; i++) {
			Debug.Log(quarksList.Count);
			Debug.Log(i);
			if(quarksIcon[i].GetInstanceID() == instanceID) {
				
				gameStatusController.increaseMoney(quarkUIController[quarksIcon[i].GetComponent<QuarkUIIconController>().getQuarkType()].cost);

				Destroy(quarksIcon[i]);
				quarksIcon.Remove(quarksIcon[i]);
				quarksList.Remove(quarksList[i]);
				Debug.Log("Final: " + quarksList.Count);
				return;
			}
		}
	}

	public void clearList() {
		this.quarksList = new List<int>();
	}

	/*	public void setQuarkUIController(QuarkUIButton quarkUiCtrl) {
		this.quarkUIController = quarkUiCtrl;
	}*/
}
