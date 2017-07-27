using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Darkon : MonoBehaviour {

	public float intervaloAtaque;
	private float contagemIntervalo;
    private float timeSkill;
    public bool atacou;
    public bool atacou2;
    public float distanciaAtaque;
	public GameObject ataque;

	private Animator animator;
    
    private GameObject jogador;
	private int horizontal;
	public float velocidade = 0.05f;
	NavMeshAgent agente;
	// Use this for initialization
	void Start () {
		horizontal = 1;
		jogador = GameObject.FindWithTag ("Player");
		animator = GetComponentInChildren<Animator>();
		agente = this.gameObject.GetComponent<NavMeshAgent> ();
        atacou = false;
        atacou2 = false;
        animator.SetBool("andando", true);
    }
	
	// Update is called once per frame
	void Update () {

		float distancia = (this.gameObject.transform.position - jogador.gameObject.transform.position).magnitude;
		float horizontalDist = gameObject.gameObject.transform.position.x - jogador.gameObject.transform.position.x;
        //animator.SetBool("andando", true);
        if (distancia < 20.0f) {

            agente.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, jogador.transform.position, velocidade);
           
			if (horizontalDist < 0) {
				transform.eulerAngles = new Vector2 (0, 0);
			} else {
				transform.eulerAngles = new Vector2 (0, 180);
			}
			//			agente.SetDestination (jogador.transform.position);
		} else {
            
            if (Random.Range (1, 1000) == 1){
				horizontal = horizontal * -1;
			}
			this.gameObject.transform.Translate (Vector2.right * velocidade * horizontal);
		}

        //Debug.Log ("Distancia: "+ distancia + "distanciaAtaque: "+ distanciaAtaque);

        if (!atacou && distancia > distanciaAtaque)
        {
            //animator.SetBool("andando", false);
            animator.SetTrigger("atacou");
            //animator.SetTrigger("atacou");
            atacou = true;
            Debug.Log(animator.enabled);
            Instantiate(ataque, transform.position, transform.rotation);
        }else if (!atacou2 && distancia < distanciaAtaque)
        {
          //  animator.SetBool("andando", false);
            animator.SetTrigger("atacouDois");
            
            atacou2 = true;
          //  Debug.Log("attack2");
        }

		if(atacou) {
          //  animator.SetBool("andando", true);
            // Debug.Log("cont");
            contagemIntervalo += Time.deltaTime;
			if (contagemIntervalo >= intervaloAtaque) {
                atacou = false;
                contagemIntervalo = 0;
			}
		}

        if (atacou2)
        {
           
            //  animator.SetBool("andando", true);
            // Debug.Log("cont");
            contagemIntervalo += Time.deltaTime;
            
            if (contagemIntervalo >= 5f)
            {
                atacou2 = false;
                contagemIntervalo = 0;
            }
            
        }

    }
    
}
