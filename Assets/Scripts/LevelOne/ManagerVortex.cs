using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerVortex : MonoBehaviour {

	private const int size = 3;
	private GameObject[] objetosVortex;
	public GameObject vortexPrefab;
	public Texture vortexAzul;
	public Texture vortexVerde;
	private GameObject player;

	// Use this for initialization

	void Start () {
		objetosVortex = new GameObject[3];
		player = GameObject.Find ("Alltron");
		carregarAla (1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void carregarAla(int idAla){
		if (idAla == 1) {
			player.transform.position = new Vector3 (-80.0f, -85.5f, 0.0f);
			//inicializa informacoes do vortex 1
			objetosVortex [0] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [0].GetComponent<Vortex> ().setPosicao (new Vector3 (79.5f, -77.0f, 3.5f));
			objetosVortex [0].GetComponent<MeshRenderer> ().material.mainTexture = vortexAzul;
			objetosVortex [0].GetComponent<Vortex> ().setCor ("azul");
			objetosVortex [0].GetComponent<Vortex> ().setTipo ("interno");
			objetosVortex [0].GetComponent<Vortex> ().setId (0);
			//inicializa informacoes do vortex 2
			objetosVortex [1] = Instantiate(vortexPrefab) as GameObject;
			objetosVortex [1].GetComponent<Vortex> ().setPosicao (new Vector3 (-79.5f, -30.0f, 3.5f));
			objetosVortex [1].GetComponent<MeshRenderer> ().material.mainTexture = vortexAzul;
			objetosVortex [1].GetComponent<Vortex> ().setCor ("azul");
			objetosVortex [1].GetComponent<Vortex> ().setTipo ("interno");
			objetosVortex [1].GetComponent<Vortex> ().setId (1);
		}
	
	}

	public Vector3 teletransportarVortex(GameObject vortex){
		for(int i = 0; i < objetosVortex.Length; i++){
			if (objetosVortex [i].GetComponent<Vortex> ().getTipo() == vortex.GetComponent<Vortex> ().getTipo()
				&& objetosVortex [i].GetComponent<Vortex> ().getCor() == vortex.GetComponent<Vortex> ().getCor()
				&& objetosVortex [i].GetComponent<Vortex> ().getId() != vortex.GetComponent<Vortex>().getId()) {
				return objetosVortex [i].GetComponent<Vortex> ().getPosicao ();
			}
		}
		return vortex.GetComponent<Vortex> ().getPosicao();
	}
}
