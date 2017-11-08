﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.AI;

public class MovimentacaoPlayer : MonoBehaviour
{

	private Animator animator;
	private float framesDash;
	private int horizontal;
	private float move;
	private bool aplicandoDash;
	private bool acumulandoDash;
	private float velocidadeDash;
	private Vector3 posicaoDestino;
	private float limiteDireita = 38.5f;
	private float limiteEsquerda = -38.5f;

	Quaternion rotacao;

	void Start ()
	{
		horizontal = 1;
		animator = this.gameObject.GetComponent<Animator> ();
		aplicandoDash = false;
		acumulandoDash = false;
	}

	// Update is called once per frame
	void Update ()
	{
		move = 0;
		animator.SetFloat ("movimento", move);

		if (aplicandoDash) {
			dash ();
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				acumulandoDash = true;
				framesDash = Time.timeSinceLevelLoad;
			}
			if (!acumulandoDash) {
				if (Input.GetKey (KeyCode.LeftArrow)) {
					horizontal = -1;
					move = 1;
					this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);
					this.gameObject.transform.eulerAngles = new Vector2 (0, 180);
				} else if (Input.GetKey (KeyCode.RightArrow)) {
					horizontal = 1;
					move = 1;
					this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * 4.0f);	
					this.gameObject.transform.eulerAngles = new Vector2 (0, 0);
				} else if (Input.GetKey (KeyCode.UpArrow)) {
					move = 1;
					float test = verificaHorizontal ();
					this.gameObject.transform.Translate (Vector3.forward * test * 6.0f);	
				} else if (Input.GetKey (KeyCode.DownArrow)) {
					move = 1;
					float test = verificaHorizontal ();
					this.gameObject.transform.Translate (Vector3.back * test * 6.0f);	
				}
				animator.SetFloat ("movimento", move);
			} else {
				if (Input.GetKeyUp (KeyCode.Space)) {
					acumulandoDash = false;
					aplicandoDash = true;
					framesDash = Time.timeSinceLevelLoad - framesDash;
					calcularDestinoDash ();
					this.animator.SetBool ("dash", aplicandoDash);
				}
			}
		}
	}

	public float getVelocidadeDash ()
	{
		return this.velocidadeDash;
	}

	public void dash ()
	{
		this.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position, posicaoDestino, 0.1f);

		if (this.gameObject.transform.position.magnitude.Equals (this.posicaoDestino.magnitude)) {
			this.aplicandoDash = false;
			this.animator.SetBool ("dash", aplicandoDash);
			framesDash = 0.0f;
		}
	}

	public void calcularVelocidadeDash ()
	{
		if (framesDash < 1.0f) {
			this.velocidadeDash = 2.0f;
		} else if (framesDash < 3.0f) {
			this.velocidadeDash = 6.0f;
		} else {
			this.velocidadeDash = 10.0f;
		}
	}

	public void calcularDestinoDash ()
	{
		calcularVelocidadeDash ();
		if (this.transform.position.x + velocidadeDash * horizontal < limiteEsquerda
		    || this.transform.position.x + velocidadeDash * horizontal > limiteDireita) {
			if (horizontal == -1) {
				this.posicaoDestino = new Vector3 (limiteEsquerda, this.gameObject.transform.position.y,
					this.gameObject.transform.position.z);
			} else {
				this.posicaoDestino = new Vector3 (limiteDireita, this.gameObject.transform.position.y,
					this.gameObject.transform.position.z);
			}
		} else {
			this.posicaoDestino = new Vector3 (this.transform.position.x + velocidadeDash * horizontal, this.gameObject.transform.position.y,
				this.gameObject.transform.position.z);
		}
	}

	public float verificaHorizontal ()
	{
		if (this.horizontal == 1) {
			return Time.deltaTime;
		} else {
			return -Time.deltaTime;
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Minion" || other.gameObject.tag == "Inimigo") {
			SistemaDeDano SDano = other.gameObject.GetComponent<SistemaDeDano> ();
			SDano.perdeVida ();
		}
	}
		

}

