using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Minion : MonoBehaviour {
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
    void Start(){
        horizontal = 1;
        jogador = GameObject.FindWithTag("Player");
        SDano = jogador.GetComponent<SistemaDeDano>();
        animator = GetComponentInChildren<Animator>();
        agente = this.gameObject.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update(){
        float distancia = (this.gameObject.transform.position - jogador.gameObject.transform.position).magnitude;
        float horizontalDist = gameObject.gameObject.transform.position.x - jogador.gameObject.transform.position.x;
        //animator.SetBool("andando", true);
        if (distancia < 5.0f){
            agente.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, jogador.transform.position, velocidade);
            if (horizontalDist < 0){
                transform.eulerAngles = new Vector2(0, 0);
            }
            else{
                transform.eulerAngles = new Vector2(0, 180);
            }
            if (Random.Range(1, 1000) < 10){
                animator.SetTrigger("atacou");
            }
        }
        else{
            contagemIntervalo += Time.deltaTime;
            if (contagemIntervalo >= intervalo){
                if (Random.Range(1,100) > 50 ){
                    horizontal = horizontal * -1;
                }
              //  Debug.Log(horizontal);
                contagemIntervalo = 0;
                verificador = false;
                if (Random.value < 0.3f){
                    verificador = true;
                }
            }
            else{
                if (horizontal == 1){
                    transform.eulerAngles = new Vector2(0, 0);
                    this.gameObject.transform.Translate(Vector2.right * velocidade);
                }
                else { 
                    transform.eulerAngles = new Vector2(0, 180);
                    this.gameObject.transform.Translate(Vector2.right * velocidade);
                }
                if (verificador){
                    transform.Translate(Vector3.forward * velocidade);
                }
            }
        }
    }
    //Sistema de dano no player
    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SDano.perdeVida(5);
        }
    }*/
}
