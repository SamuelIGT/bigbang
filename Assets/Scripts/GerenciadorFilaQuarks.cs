using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorFilaQuarks : MonoBehaviour {
	public GameObject prefabUp;
	public GameObject prefabDown;
	public GameObject prefabStrange;
	public GameObject prefabCharm;
	public GameObject prefabBottom;
	public GameObject prefabTop;
	public GameObject healthBar;
	public QuarksListController quarksListController;
	public Vector3 distanciaEntreQuarks = Vector3.zero;
	public Vector3 posicaoInicial = Vector3.zero;
	private List<GameObject> listQuarks;

	enum Quarks {
		UP = 0,
		DOWN = 1,
		STRANGE = 2,
		CHARM = 3,
		BOTTOM = 4,
		TOP = 5}
	;





	int ultimoIndice;

	// Use this for initialization
	void Start() {
		listQuarks = new List<GameObject>();
		ultimoIndice = -1;
	}
	
	// Update is called once per frame
	void Update() {
		if(listQuarks.Count == 0) {
			notifyGameIsOver();
		}
		
	}

	public void GerarFila() {
		List <int> lista = quarksListController.GetQuarksList();
		int listSize = quarksListController.ListSize();
		Debug.Log("Tamanho da Lista:" + listSize);

		for(int i = 0; i <= listSize; i++) {
			AddQuark(lista[i]);
		}
	}

	public void AddQuark(int quarkType) {
		GameObject go;
		GameObject healthBarGameObject;
		switch(quarkType) {
			case (int)Quarks.UP: 
				go = Instantiate(prefabUp) as GameObject;
				break;
			case (int)Quarks.DOWN: 
				go = Instantiate(prefabDown) as GameObject;
				break;
			case (int)Quarks.STRANGE: 
				go = Instantiate(prefabStrange) as GameObject;
				break;
			case (int)Quarks.CHARM: 
				go = Instantiate(prefabCharm) as GameObject;
				break;
			case (int)Quarks.BOTTOM: 
				go = Instantiate(prefabBottom) as GameObject;
				break;
			case (int)Quarks.TOP: 
				go = Instantiate(prefabTop) as GameObject;
				break;
			default: 
				go = Instantiate(prefabUp) as GameObject;
				break;
		}

		healthBarGameObject = Instantiate(healthBar) as GameObject; //instantiate the health bar
		healthBarGameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false); //set the health bar as a child of the canvas.
		go.GetComponent<QuarkController>().SetHealthBar(healthBarGameObject);
		//go.transform.SetParent(GameObject.FindGameObjectWithTag("WaveManager").transform, false);
		//posicionando
		if(ultimoIndice >= 0) {
			//localizar o ultimo
			Vector3 posicaoUltimo = listQuarks[ultimoIndice].transform.position;
			//setar posição
			go.transform.position = posicaoUltimo + distanciaEntreQuarks;
		} else {
			go.transform.position = posicaoInicial;
		}

		//adicionar na lista
		listQuarks.Add(go);
		ultimoIndice++;
	}

	private void notifyGameIsOver() {
		gameObject.GetComponent<GameStatusController>().gameOverVerifier();
		//GameObject.FindWithTag("GameController").GetComponent<GameStatusController>().gameOverVerifier();
	}

	public void removeQuark(GameObject quarkGameObject) {
		listQuarks.Remove(quarkGameObject);
	}

	public void Clear() {
		Start();
	}
		
}
