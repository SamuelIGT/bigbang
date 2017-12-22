using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Darkon : MonoBehaviour
{

	public float intervaloAtaque;
	private float contagemIntervalo;
	private float timeSkill;
	private float timeUltimoAtaque;
	public bool atacou;
	public bool atacou2;
	public float distanciaAtaque;
	public GameObject ataque;
	private bool estadoAtivo = true;

	private Animator animator;
    
	private GameObject jogador;
	private int horizontal;
	public float velocidade = 0.05f;
	NavMeshAgent agente;
	// Use this for initialization
	void Start ()
	{
		horizontal = 1;
		jogador = GameObject.FindWithTag ("Player");
		animator = gameObject.GetComponent<Animator> ();
		agente = this.gameObject.GetComponent<NavMeshAgent> ();
		atacou = false;
		atacou2 = false;
		animator.SetBool ("andando", true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (estadoAtivo) {
			float distancia = (this.gameObject.transform.position - jogador.gameObject.transform.position).magnitude;
			float horizontalDist = gameObject.gameObject.transform.position.x - jogador.gameObject.transform.position.x;
			if (distancia < 5.0f) {
				if (jogador.gameObject.GetComponent<MovimentacaoPlayer> ().getAplicandoDash () == false) {
					jogador.transform.position = Vector3.MoveTowards (jogador.transform.position, this.gameObject.transform.position, velocidade);
				}
			} else if (distancia < 20.0f) {
				agente.gameObject.transform.position = Vector3.MoveTowards (this.gameObject.transform.position, jogador.transform.position, velocidade);
           
				if (horizontalDist < 0) {
					transform.eulerAngles = new Vector2 (0, 0);
				} else {
					transform.eulerAngles = new Vector2 (0, 180);
				}
			} else {
				if (Random.Range (1, 1000) == 1) {
					horizontal = horizontal * -1;
				}
				this.gameObject.transform.Translate (Vector2.right * velocidade * horizontal);
			}
			
			if (!atacou && distancia > distanciaAtaque) {
				animator.SetTrigger ("atacou");
				atacou = true;
				Instantiate (ataque, transform.position, transform.rotation);
			} else if (!atacou2 && distancia < distanciaAtaque) {
				animator.SetTrigger ("atacouDois");
				atacou2 = true;
			}

			if (atacou) {
				contagemIntervalo += Time.deltaTime;
				if (contagemIntervalo >= intervaloAtaque) {
					atacou = false;
					contagemIntervalo = 0.0f;
				}
			}

			if (atacou2) {
				contagemIntervalo += Time.deltaTime;
            
				if (contagemIntervalo >= 5f) {
					atacou2 = false;
					contagemIntervalo = 0.0f;
				}
            
			}
		}
	}

	// Retorna um inteiro contendo a direção horizontal do Darkon.
	public int getHorizontal ()
	{
		return this.horizontal;
	}

	void OnCollisionEnter (Collision other)
	{
		if (atacou2 && other.gameObject.tag == "Player") {
			Debug.Log ("atacou3");
			SistemaDeDano SDano = other.gameObject.GetComponent<SistemaDeDano> ();
			SDano.perderVida ();
		}
	}

	public void pararAtaque2 ()
	{
		this.atacou2 = false;
	}

	public void setEstadoAtivo (bool estado)
	{
		this.estadoAtivo = estado;
	}
    
}
