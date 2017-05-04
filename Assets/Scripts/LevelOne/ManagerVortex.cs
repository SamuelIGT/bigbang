using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerVortex : MonoBehaviour {

	private const int size = 10;
	private GameObject[] objetosVortex;
	public GameObject vortexPrefab;
	public Texture [] texturas = new Texture[3];
	private string [] cores;

	// Use this for initialization

	void Start () {
		objetosVortex = new GameObject[size];
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
			//inicializa vortex 0
			objetosVortex [0] = Instantiate (vortexPrefab) as GameObject;
			objetosVortex [0].GetComponent<Vortex> ().setPosicao (new Vector3 (260.0f, -81.0f, 21.0f));
			objetosVortex [0].GetComponent<Vortex> ().setId (0);
			objetosVortex [0].GetComponent<MeshRenderer> ().material.mainTexture = texturas [colorVortex];
			objetosVortex [0].GetComponent<Vortex> ().setCor (cores [colorVortex]);	

			//inicializa vortex 1
			objetosVortex [1] = Instantiate (vortexPrefab) as GameObject;
			objetosVortex [1].GetComponent<Vortex> ().setPosicao (new Vector3 (-260.0f, 114.0f, 21.0f));
			objetosVortex [1].GetComponent<Vortex> ().setId (1);
			objetosVortex [1].GetComponent<MeshRenderer> ().material.mainTexture = texturas [colorVortex];
			objetosVortex [1].GetComponent<Vortex> ().setCor (cores [colorVortex]);
		}
		if (idAlavanca == 2) {
			//inicializa vortex 2
			objetosVortex [2] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [2].GetComponent<Vortex> ().setPosicao (new Vector3 (260.0f, 110.0f, 21.0f));
			objetosVortex [2].GetComponent<MeshRenderer> ().material.mainTexture = texturas[colorVortex];
			objetosVortex [2].GetComponent<Vortex> ().setCor (cores[colorVortex]);
			objetosVortex [2].GetComponent<Vortex> ().setId (2);
			//inicializa vortex 3
			objetosVortex [3] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [3].GetComponent<Vortex> ().setPosicao (new Vector3 (-260.0f, 315.0f, 21.0f));
			objetosVortex [3].GetComponent<MeshRenderer> ().material.mainTexture = texturas[colorVortex];
			objetosVortex [3].GetComponent<Vortex> ().setCor (cores[colorVortex]);
			objetosVortex [3].GetComponent<Vortex> ().setId (3);
		}
		if (idAlavanca == 3) {
			//inicializa vortex 4
			objetosVortex [4] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [4].GetComponent<Vortex> ().setPosicao (new Vector3 (260.0f, 310.0f, 21.0f));
			objetosVortex [4].GetComponent<MeshRenderer> ().material.mainTexture = texturas[colorVortex];
			objetosVortex [4].GetComponent<Vortex> ().setCor (cores[colorVortex]);
			objetosVortex [4].GetComponent<Vortex> ().setId (4);
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
}
