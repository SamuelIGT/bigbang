using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerVortex : MonoBehaviour {

	private const int size = 14;
	private GameObject[] objetosVortex;
	public GameObject vortexPrefab;
	public Texture vortexAzul;
	public Texture vortexVerde;

	// Use this for initialization

	void Start () {
		objetosVortex = new GameObject[size];
		carregarAla (1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void carregarAla(int idAla){
		if (idAla == 1) {
			//inicializa informacoes do vortex 0
			objetosVortex [0] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [0].GetComponent<Vortex> ().setPosicao (new Vector3 (260.0f, -40.0f, 10.0f));
			objetosVortex [0].GetComponent<MeshRenderer> ().material.mainTexture = vortexAzul;
			objetosVortex [0].GetComponent<Vortex> ().setCor ("azul");
			objetosVortex [0].GetComponent<Vortex> ().setTipo ("interno");
			objetosVortex [0].GetComponent<Vortex> ().setId (0);
			//inicializa informacoes do vortex 1
			objetosVortex [1] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [1].GetComponent<Vortex> ().setPosicao (new Vector3 (-260.0f, 150.0f, 10.0f));
			objetosVortex [1].GetComponent<MeshRenderer> ().material.mainTexture = vortexAzul;
			objetosVortex [1].GetComponent<Vortex> ().setCor ("azul");
			objetosVortex [1].GetComponent<Vortex> ().setTipo ("interno");
			objetosVortex [1].GetComponent<Vortex> ().setId (1);
			//inicializa informacoes do vortex 2
			objetosVortex [2] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [2].GetComponent<Vortex> ().setPosicao (new Vector3 (130.0f, 150.0f, 10.0f));
			objetosVortex [2].GetComponent<MeshRenderer> ().material.mainTexture = vortexVerde;
			objetosVortex [2].GetComponent<Vortex> ().setCor ("verde");
			objetosVortex [2].GetComponent<Vortex> ().setTipo ("interno");
			objetosVortex [2].GetComponent<Vortex> ().setId (2);
			//inicializa informacoes do vortex 3
			objetosVortex [3] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [3].GetComponent<Vortex> ().setPosicao (new Vector3 (-130.0f, 350.0f, 10.0f));
			objetosVortex [3].GetComponent<MeshRenderer> ().material.mainTexture = vortexVerde;
			objetosVortex [3].GetComponent<Vortex> ().setCor ("verde");
			objetosVortex [3].GetComponent<Vortex> ().setTipo ("interno");
			objetosVortex [3].GetComponent<Vortex> ().setId (3);
			//inicializa informacoes do vortex 4
			objetosVortex [4] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [4].GetComponent<Vortex> ().setPosicao (new Vector3 (130.0f, 350.0f, 10.0f));
			objetosVortex [4].GetComponent<MeshRenderer> ().material.mainTexture = vortexAzul;
			objetosVortex [4].GetComponent<Vortex> ().setCor ("azul");
			objetosVortex [4].GetComponent<Vortex> ().setTipo ("interno");
			objetosVortex [4].GetComponent<Vortex> ().setId (4);
		}
	
	}

	public Vector3 teletransportarVortex(GameObject vortex){
		int idVortex = vortex.GetComponent<Vortex> ().getId ();
		if (objetosVortex [idVortex + 1].GetComponent<Vortex> ().getTipo () == vortex.GetComponent<Vortex> ().getTipo ()
		    && objetosVortex [idVortex + 1].GetComponent<Vortex> ().getCor () == vortex.GetComponent<Vortex> ().getCor ()) {
			return objetosVortex [idVortex + 1].GetComponent<Vortex> ().getPosicao ();
		} else if (objetosVortex [idVortex - 1].GetComponent<Vortex> ().getTipo () == vortex.GetComponent<Vortex> ().getTipo ()
		        && objetosVortex [idVortex - 1].GetComponent<Vortex> ().getCor () == vortex.GetComponent<Vortex> ().getCor ()) {
			return objetosVortex [idVortex - 1].GetComponent<Vortex> ().getPosicao ();
		} else {
			return vortex.GetComponent<Vortex> ().getPosicao();
		}
	}
}
