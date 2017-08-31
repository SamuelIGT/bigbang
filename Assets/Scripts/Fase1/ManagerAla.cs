using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAla : MonoBehaviour {

	private const int quantVortex = 10;
	private GameObject[] objetosVortex;
	public GameObject vortexPrefab;
	public Texture [] texturas = new Texture[3];
	private string [] cores;
	private bool visibilidadeVortex;

	// Use this for initialization

	void Start () {
		objetosVortex = new GameObject[quantVortex];
		cores = new string[3];
		cores[0] = "azul";
		cores[1] = "verde";
		cores[2] = "roxo";
		visibilidadeVortex = true;
	}

	// Update is called once per frame
	void Update () {
		aleatorizaExistenciaDosVortex ();
	}

	public void carregarVortex(int idAlavanca){
		
		int colorVortex = Random.Range (0, 3); //azul, verde e roxo
		if (idAlavanca == 1) {
			if (objetosVortex [0] == null && objetosVortex [1] == null && objetosVortex[2] == null && objetosVortex[3] == null) {
				//inicializa vortex 0
				inicializaVortex(objetosVortex, vortexPrefab, 0, new Vector3 (240.0f, -81.0f, 21.0f), texturas [colorVortex], cores [colorVortex], "simples");
				//inicializa vortex 1
				inicializaVortex(objetosVortex, vortexPrefab, 1, new Vector3 (-310.0f, 114.0f, 21.0f), texturas [colorVortex], cores [colorVortex], "simples");
				//inicializa vortex que desaparece aleatoriamente (2 e 3)
				colorVortex = Random.Range (0, 3); //azul, verde e roxo
				inicializaVortex(objetosVortex, vortexPrefab, 2, new Vector3 (-80.0f, 114.0f, 21.0f), texturas[colorVortex], cores[colorVortex], "aleatorio");
				inicializaVortex(objetosVortex, vortexPrefab, 3, new Vector3 (20.0f, 114.0f, 21.0f), texturas [colorVortex], cores [colorVortex], "aleatorio");
 			}
		}
		if (idAlavanca == 2) {
			if (objetosVortex [4] == null && objetosVortex [5] == null) {
				//inicializa vortex 4
				inicializaVortex(objetosVortex, vortexPrefab, 4, new Vector3 (260.0f, 114.0f, 21.0f), texturas [colorVortex], cores [colorVortex], "simples");
				//inicializa vortex 5
				inicializaVortex(objetosVortex, vortexPrefab, 5, new Vector3 (-260.0f, 315.0f, 21.0f), texturas [colorVortex], cores [colorVortex], "simples");
			}	

		}
		if (idAlavanca == 3) {
			if (objetosVortex [6] == null) {
				//inicializa vortex 6
				inicializaVortex(objetosVortex, vortexPrefab, 6, new Vector3 (260.0f, 315.0f, 21.0f), texturas [colorVortex], cores [colorVortex], "simples");
			}
		}
	}

	public Vector3 teletransportarVortex(GameObject vortex){
		int idVortex = vortex.GetComponent<Vortex> ().getId ();
		if (objetosVortex[idVortex + 1] != null 
			&& objetosVortex [idVortex + 1].GetComponent<Vortex> ().getCor () == vortex.GetComponent<Vortex> ().getCor ()
			&& objetosVortex [idVortex + 1].GetComponent<Vortex>().getTipo () == vortex.GetComponent<Vortex> ().getTipo()) {
			return objetosVortex [idVortex + 1].GetComponent<Vortex> ().getPosicao ();
		} else if (objetosVortex [idVortex - 1] != null 
			&& objetosVortex [idVortex - 1].GetComponent<Vortex> ().getCor () == vortex.GetComponent<Vortex> ().getCor ()
			&& objetosVortex [idVortex - 1].GetComponent<Vortex>().getTipo () == vortex.GetComponent<Vortex> ().getTipo()) {
			return objetosVortex [idVortex - 1].GetComponent<Vortex> ().getPosicao ();
		} else {
			return vortex.GetComponent<Vortex> ().getPosicao();
		}
	}

	public void inicializaVortex(GameObject[] arrayVortex, GameObject vortexPrefab, int id, Vector3 posicao, Texture textura, string cor, string tipo){
		GameObject vortex = Instantiate (vortexPrefab) as GameObject;
		vortex.GetComponent<Vortex> ().setId (id);
		vortex.GetComponent<Vortex> ().setPosicao (posicao);
		vortex.GetComponent<Vortex> ().setTextura (textura);
		vortex.GetComponent<Vortex> ().setCor (cor);
		vortex.GetComponent<Vortex> ().setTipo (tipo);
		arrayVortex [id] = vortex;
	}

	public void aleatorizaExistenciaDosVortex(){
		if (Random.Range (1, 250) == 1) {
			visibilidadeVortex = !visibilidadeVortex;
			atualizaVisibilidadeVortex (visibilidadeVortex);
		}
	}

	public void atualizaVisibilidadeVortex(bool visibilidade){
		if (objetosVortex [2] != null && objetosVortex [3] != null) {
			objetosVortex [2].SetActive (visibilidade);
			objetosVortex [3].SetActive (visibilidade);
		}

	}
}
