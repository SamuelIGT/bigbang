using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HodMecanica : MonoBehaviour
{
	private Animator animator;
	private Sprite spriteHod;
	private MovimentacaoPlayerFase4 movimentacaoPlayer;
	private ManagerHud managerHud;
	public GameObject pedraPrefab;
	public Sprite[] spritesPedra;

	private float duracaoAnimacaoDesaparecer = 2.0f;
	private float duracaoAnimacaoLancarPedra = 8.0f;
	private float duracaoAnimacaoAtrair = 11.0f;
	private float tempoUltimoDano;
	private float tempoUltimoAtaquePedra;
	private float tempoUltimoAtaqueAtrair;
	private float tempoUltimaInstanciaPedra;
	private float duracaoNovaInstanciaPedra = 1.0f;

	private bool recebendoDano;
	// -1 para posição à direita do Hod e 1 para posição à esquerda.
	private bool ataquePedra;
	private bool ataqueAtrair;
	private int direcaoHorizontal = 1;
	private float posicaoHorizontalDireita = -15.42f;
	private float posicaoHorizontalEsquerda = -42.42f;
	private int quantidadeDano = 0;

	// Use this for initialization
	void Start ()
	{
		animator = this.gameObject.GetComponentInChildren<Animator> ();
		spriteHod = this.gameObject.GetComponentInChildren<SpriteRenderer> ().sprite;
		movimentacaoPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovimentacaoPlayerFase4> ();
		managerHud = GameObject.FindGameObjectWithTag ("ManagerHud").GetComponent<ManagerHud> ();
		recebendoDano = false;
		ataquePedra = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ataquePedra) {
			verificarSpriteAtualDoHod ();		
		}
		if (Time.timeSinceLevelLoad - tempoUltimoAtaquePedra > duracaoAnimacaoLancarPedra) {
			tempoUltimoAtaquePedra = 0.0f;
			ataquePedra = false;
			animator.SetBool ("ataquePedra", ataquePedra);
		}
		if (recebendoDano == true && (Time.timeSinceLevelLoad - tempoUltimoDano > duracaoAnimacaoDesaparecer)) {
			if (!ataquePedra) {
				alterarPosicaoHod ();
				recebendoDano = false;
				animator.SetBool ("recebendoDano", recebendoDano);
				tempoUltimoDano = 0.0f;
			}
		}
		// Verifica a chance de atacar.
		if (Random.Range (1, 100) < 3) {
			// Verifica qual tipo de ataque, 1 para lançar pedra e 2 para atrair.
			if (!ataquePedra) {
				tempoUltimoAtaquePedra = Time.timeSinceLevelLoad;
				ataquePedra = true;
				animator.SetBool ("ataquePedra", ataquePedra);
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
			SceneManager.LoadScene ("WinGameScene");
		}
	}

	public void instanciarPedra ()
	{
		if (Time.timeSinceLevelLoad - tempoUltimaInstanciaPedra > duracaoNovaInstanciaPedra) {
			GameObject pedra = Instantiate (pedraPrefab) as GameObject;
			Vector3 posicaoAtualHod = this.gameObject.transform.position;
			Vector3 posicaoPedra = new Vector3 (posicaoAtualHod.x, 1.2f, posicaoAtualHod.z);
			Sprite spriteDaPedra = aleatorizarSpriteDaPedra ();
			pedra.gameObject.GetComponent<PedraProjetil> ().setPropriedades (posicaoPedra, this.direcaoHorizontal, spriteDaPedra);
			tempoUltimaInstanciaPedra = Time.timeSinceLevelLoad;
		}
	}

	public Sprite aleatorizarSpriteDaPedra ()
	{
		int indexSprite = Random.Range (0, 3);
		return spritesPedra [indexSprite];
	}

	public void verificarSpriteAtualDoHod ()
	{
		spriteHod = this.gameObject.GetComponentInChildren<SpriteRenderer> ().sprite;
		string sprite = spriteHod.ToString ();

		if (sprite.Contains ("continuo")) {
			instanciarPedra ();
		}

	}

}
