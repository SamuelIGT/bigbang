using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HodMecanica : MonoBehaviour
{
	private Animator animator;
	private MovimentacaoPlayerFase4 movimentacaoPlayer;
	private float duracaoAnimacaoDesaparecer = 0.25f;
	private float tempoUltimoDano;
	private ManagerHud managerHud;

	private bool recebendoDano;
	// -1 para posição à direita do Hod e 1 para posição à esquerda.
	private int direcaoHorizontal = 1;

	// Use this for initialization
	void Start ()
	{
		animator = this.gameObject.GetComponentInChildren<Animator> ();
		movimentacaoPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovimentacaoPlayerFase4> ();
		managerHud = GameObject.FindGameObjectWithTag ("ManagerHud").GetComponent<ManagerHud> ();
		recebendoDano = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (recebendoDano == true && (Time.timeSinceLevelLoad - tempoUltimoDano > duracaoAnimacaoDesaparecer)) {
			Debug.Log ("acabou animacao");
			alterarPosicaoHod ();
			recebendoDano = false;
			animator.SetBool ("recebendoDano", recebendoDano);
			tempoUltimoDano = 0.0f;
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Player" && movimentacaoPlayer.getAtacando () == true) {
			movimentacaoPlayer.setAtacando (false);
			tempoUltimoDano = Time.timeSinceLevelLoad;
			recebendoDano = true;
			animator.SetBool ("recebendoDano", recebendoDano);
			managerHud.aumentarBarraProgresso (0.01f);
		}			
	}

	public void alterarPosicaoHod ()
	{
		// Inverte a direção horizontal.
		direcaoHorizontal = direcaoHorizontal * -1;
		Debug.Log (direcaoHorizontal);
		// Altera a posicao multiplicando a posição em X pela direção atual. 
		this.gameObject.transform.position = new Vector3 (7.5f * direcaoHorizontal, 1.0f, Random.Range (-3.0f, 3.0f));
	}
}
