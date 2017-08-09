using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Vortex : MonoBehaviour {
	private int id;
	private string cor;
	private string tipo;

	void Start(){

	}

	void Update(){

	}

	public Vector3 getPosicao(){
		return this.gameObject.transform.position;
	}
	public void setPosicao(Vector3 posicao){
		this.gameObject.transform.position = posicao;
	}
	public string getCor(){
		return this.cor;
	}
	public void setCor(string cor){
		this.cor = cor;
	}
	public string getTipo(){
		return this.tipo;
	}
	public void setTipo(string tipo){
		this.tipo = tipo;
	}
	public Texture getTextura(){
		return this.gameObject.GetComponent<MeshRenderer> ().material.mainTexture;
	}
	public void setTextura(Texture textura){
		this.gameObject.GetComponent<MeshRenderer> ().material.mainTexture = textura;
	}
	public int getId(){
		return this.id;
	}
	public void setId(int id){
		this.id = id;
	}


}
