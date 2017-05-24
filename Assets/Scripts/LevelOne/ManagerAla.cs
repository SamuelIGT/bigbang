using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAla : MonoBehaviour {

	private const int quantVortex = 10;
	private GameObject[] objetosVortex;
	public GameObject vortexPrefab;
	public Texture [] texturas = new Texture[3];
	private string [] cores;

	// Use this for initialization

	void Start () {
		objetosVortex = new GameObject[quantVortex];
		cores = new string[3];
		cores[0] = "azul";
		cores[1] = "verde";
		cores[2] = "roxo";
	}

	// Update is called once per frame
	void Update () {

	}

	public void carregarVortex(int idAlavanca){
		
		int colorVortex = Random.Range (0, 3); //azul, verde e roxo
		if (idAlavanca == 1) {
			if (objetosVortex [0] == null && objetosVortex [1] == null) {
				//inicializa vortex 0
				objetosVortex [0] = inicializaVortex(vortexPrefab, 0, new Vector3 (260.0f, -81.0f, 21.0f), texturas [colorVortex], cores [colorVortex]);
				//inicializa vortex 1
				objetosVortex [1] = inicializaVortex(vortexPrefab, 1, new Vector3 (-260.0f, 114.0f, 21.0f), texturas [colorVortex], cores [colorVortex]);
			}
		}
		if (idAlavanca == 2) {
			if (objetosVortex [2] == null && objetosVortex [3] == null) {
				//inicializa vortex 2
				objetosVortex [2] = inicializaVortex(vortexPrefab, 2, new Vector3 (260.0f, 110.0f, 21.0f), texturas [colorVortex], cores [colorVortex]);
				//inicializa vortex 3
				objetosVortex [3] = inicializaVortex(vortexPrefab, 3, new Vector3 (-260.0f, 315.0f, 21.0f), texturas [colorVortex], cores [colorVortex]);
			}	

		}
		if (idAlavanca == 3) {
			if (objetosVortex [4] == null) {
				//inicializa vortex 4
				objetosVortex [4] = inicializaVortex(vortexPrefab, 4, new Vector3 (260.0f, 310.0f, 21.0f), texturas [colorVortex], cores [colorVortex]);
			}
		}
	}

	public Vector3 teletransportarVortex(GameObject vortex){
		int idVortex = vortex.GetComponent<Vortex> ().getId ();
		if (objetosVortex[idVortex + 1] != null && objetosVortex [idVortex + 1].GetComponent<Vortex> ().getCor () == vortex.GetComponent<Vortex> ().getCor ()) {
			return objetosVortex [idVortex + 1].GetComponent<Vortex> ().getPosicao ();
		} else if (objetosVortex [idVortex - 1] != null && objetosVortex [idVortex - 1].GetComponent<Vortex> ().getCor () == vortex.GetComponent<Vortex> ().getCor ()) {
			return objetosVortex [idVortex - 1].GetComponent<Vortex> ().getPosicao ();
		} else {
			return vortex.GetComponent<Vortex> ().getPosicao();
		}
	}

	public GameObject inicializaVortex(GameObject vortexPrefab, int id, Vector3 posicao, Texture textura, string cor){
		GameObject vortex = Instantiate (vortexPrefab) as GameObject;
		vortex.GetComponent<Vortex> ().setId (id);
		vortex.GetComponent<Vortex> ().setPosicao (posicao);
		vortex.GetComponent<Vortex> ().setTextura (textura);
		vortex.GetComponent<Vortex> ().setCor (cor);
		return vortex;
	}
}
