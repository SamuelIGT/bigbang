using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
	public float intervalo;
	private bool verificador;
	private float contagemIntervalo;
	private Animator animator;
	private GameObject jogador;
	private int horizontal;
	public float velocidade;
	NavMeshAgent agente;
	private SistemaDeDano SDano;
    
	// Use this for initialization
	void Start ()
	{
		horizontal = 1;
		jogador = GameObject.FindWithTag ("Player");
		SDano = jogador.gameObject.GetComponent<SistemaDeDano> ();
		animator = GetComponentInChildren<Animator> ();
		agente = this.gameObject.GetComponent<NavMeshAgent> ();
	}
    
	// Update is called once per frame
	void Update ()
	{
		float distancia = (this.gameObject.transform.position - jogador.gameObject.transform.position).magnitude;
		float horizontalDist = gameObject.gameObject.transform.position.x - jogador.gameObject.transform.position.x;
		if (distancia < 5.0f) {
			if (jogador.gameObject.GetComponent<MovimentacaoPlayer> ().getAplicandoDash () == false) {
				//Debug.Log ("atraindo alltron");
				jogador.transform.position = Vector3.MoveTowards (jogador.transform.position, this.gameObject.transform.position, velocidade);
			}
			if (horizontalDist < 0) {
				transform.eulerAngles = new Vector2 (0, 0);
			} else {
				transform.eulerAngles = new Vector2 (0, 180);
			}
			if (Random.Range (1, 1000) < 5) {
				animator.SetTrigger ("atacou");
				// para o novo ataque do minion
				this.GetComponentInChildren<AreaDanoAtaqueMinion> ().Ataque ();

			}
		} else {
			contagemIntervalo += Time.deltaTime;
			if (contagemIntervalo >= intervalo) {
				if (Random.Range (1, 100) > 50) {
					horizontal = horizontal * -1;
				}
				contagemIntervalo = 0;
				verificador = false;
				if (Random.value < 0.3f) {
					verificador = true;
				}
			} else {
				if (horizontal == 1) {
					transform.eulerAngles = new Vector2 (0, 0);
					this.gameObject.transform.Translate (Vector2.right * velocidade);
				} else { 
					transform.eulerAngles = new Vector2 (0, 180);
					this.gameObject.transform.Translate (Vector2.right * velocidade);
				}
				if (verificador) {
					transform.Translate (Vector3.forward * velocidade);
				}
			}
		}
	}

	// Retorna um inteiro contendo a direção horizontal do Minion.
	public int getHorizontal ()
	{
		return this.horizontal;
	}
}
