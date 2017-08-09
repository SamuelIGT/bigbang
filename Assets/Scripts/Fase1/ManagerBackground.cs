﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBackground : MonoBehaviour {
	private const int quantAlas = 3;
	private const int quantElementosAla = 21;
	public GameObject[] backgrounds = new GameObject[quantAlas];
	public GameObject[] molduras = new GameObject[quantAlas];
	private GameObject[] alaBranca = new GameObject[quantElementosAla];
	private GameObject[] alaRoxa = new GameObject[quantElementosAla];
	private GameObject[] alaAzul = new GameObject[quantElementosAla];
	private ModalController modal;
	private double temperaturaAtual;
	private int alavancasAtivadas;

	// Use this for initialization
	void Start () {
		alaBranca = GameObject.FindGameObjectsWithTag ("AlaBranca");
		alaRoxa = GameObject.FindGameObjectsWithTag ("AlaRoxa");
		alaAzul = GameObject.FindGameObjectsWithTag ("AlaAzul");

		//inicializa backgrounds
		backgrounds [0].SetActive (true);
		backgrounds [1].SetActive (false);
		backgrounds [2].SetActive (false);
		//inicializa molduras
		molduras [0].SetActive (true);
		molduras [1].SetActive (false);
		molduras [2].SetActive (false);
		//inicializa paredes, pisos e tetos
		for(int i = 0; i < quantElementosAla; i++){
			alaBranca [i].SetActive (true);
			alaRoxa [i].SetActive (false);
			alaAzul [i].SetActive (false);
		}

		//inicializa textos da UI
		temperaturaAtual = 39;
		alavancasAtivadas = 0;
		modal = GameObject.Find ("Managers").GetComponent<ModalController> ();
		atualizarTextosUI ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void mudarCenario(int idAlavanca){
		if (idAlavanca > 0) {
			//atualiza textos UI
			temperaturaAtual -= 2;
			alavancasAtivadas++;
			atualizarTextosUI ();
			if (idAlavanca < quantAlas) {
				//alterarCorAlavanca (idAlavanca);
				for (int i = 0; i < quantAlas; i++) {
					if (i != idAlavanca) {
						backgrounds [i].SetActive (false);
						molduras [i].SetActive (false);
					}
				}
				backgrounds [idAlavanca].SetActive (true);
				molduras [idAlavanca].SetActive (true);
				alterarCorElementosAla (idAlavanca);	
			}
		}	
	}

	public void alterarCorElementosAla(int idAlavanca){
		if (idAlavanca != quantAlas) {
			for(int i = 0; i < quantElementosAla; i++){
				if (idAlavanca == 1) {
					alaBranca [i].SetActive (false);
					alaRoxa [i].SetActive (true);
					alaAzul [i].SetActive (false);
				} else {
					alaBranca [i].SetActive (false);
					alaRoxa [i].SetActive (false);
					alaAzul [i].SetActive (true);
				}

			}
		}
	}

	public int getQuantAlas(){
		return ManagerBackground.quantAlas;
	}

	public void atualizarTextosUI(){
		this.modal.elementosTextoUI[0].text = "Temperatura: 10 ^ " + temperaturaAtual + "º";
		this.modal.elementosTextoUI[1].text = "Alavancas: " + alavancasAtivadas + "/" + quantAlas;
	}

	public double getTemperaturaAtual(){
		return this.temperaturaAtual;
	}

	public int getAlavancasAtivadas(){
		return this.alavancasAtivadas;
	}

}
