using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HodMecanica : MonoBehaviour
{
	private Animator animator;
	private AnimatorClipInfo[] animatorClipInfo;
	private MovimentacaoPlayerFase4 movimentacaoPlayer;
	private float duracaoAnimacaoDesaparecer = 3.0f;
	private float duracaoAnimacaoLancarPedra = 8.0f;
	private float tempoUltimoDano;
	private float tempoUltimoAtaquePedra;
	private ManagerHud managerHud;

	private bool recebendoDano;
	// -1 para posição à direita do Hod e 1 para posição à esquerda.
	private bool ataquePedra;
	private int direcaoHorizontal = 1;
	private float posicaoHorizontalDireita = -15.42f;
	private float posicaoHorizontalEsquerda = -42.42f;
	private int quantidadeDano = 0;

	// Use this for initialization
	void Start ()
	{
		animator = this.gameObject.GetComponentInChildren<Animator> ();
		movimentacaoPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovimentacaoPlayerFase4> ();
		managerHud = GameObject.FindGameObjectWithTag ("ManagerHud").GetComponent<ManagerHud> ();
		recebendoDano = false;
		ataquePedra = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ataquePedra) {
			Debug.Log (animatorClipInfo [0].clip.name);
			//secondsAnimation += animatorClipInfo [0].clip.length;
		}
		if (recebendoDano == true && (Time.timeSinceLevelLoad - tempoUltimoDano > duracaoAnimacaoDesaparecer)) {
			alterarPosicaoHod ();
			recebendoDano = false;
			animator.SetBool ("recebendoDano", recebendoDano);
			tempoUltimoDano = 0.0f;
		} else {
			// Verifica a chance de atacar.
			if (Random.Range (1, 600) == 1) {
				Debug.Log ("pode atacar");
				// Verifica qual tipo de ataque, 1 para lançar pedra e 2 para atrair.
				if (Random.Range (1, 3) == 1) {
					ataquePedra = true;
					animator.SetBool ("ataquePedra", ataquePedra);
					animatorClipInfo = animator.GetCurrentAnimatorClipInfo (0);
					//	tempoUltimoAtaquePedra = 
				} else {
				
				}
			}
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Player" && movimentacaoPlayer.getAtacando () == true) {
			movimentacaoPlayer.setAtacando (false);
			tempoUltimoDano = Time.timeSinceLevelLoad;
			recebendoDano = true;
			animator.SetBool ("recebendoDano", recebendoDano);
			managerHud.aumentarBarraProgresso (0.014f);
			aumentarQuantidadeDano ();
		}			
	}

	public void alterarPosicaoHod ()
	{
		// Inverte a direção horizontal.
		direcaoHorizontal = direcaoHorizontal * -1;

		// Verifica a direção horizontal e altera a posição em X baseando-se nessa direção.
		// Altera também a posição em Z baseando-se em um randomico.
		if (direcaoHorizontal == 1) {
			this.gameObject.transform.position = new Vector3 (posicaoHorizontalDireita, 0.09f, Random.Range (-3.0f, 3.0f));	
		} else {
			this.gameObject.transform.position = new Vector3 (posicaoHorizontalEsquerda, 0.09f, Random.Range (-3.0f, 3.0f));
		}

		// Altera a rotação em 180 graus no eixo Y. 
		this.gameObject.transform.RotateAround (this.transform.position, new Vector3 (0, 1, 0), 180);
	}

	public void aumentarQuantidadeDano ()
	{
		this.quantidadeDano += 1;
		verificarNumeroMaximoDeDano ();
	}

	public void verificarNumeroMaximoDeDano ()
	{
		if (quantidadeDano == 15) {
			Debug.Log ("game win");
			// Chamar última cutscene.
			// Próxima fase é o menu principal
			//ControllerScene.getInstance().runCutscene(
		}
	}

}
