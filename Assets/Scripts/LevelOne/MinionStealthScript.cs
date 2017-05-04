using UnityEngine;
using System.Collections;

public class MinionStealthScript : MonoBehaviour {

	/*public float limiteDireito = -260.0f;
	public float limiteEsquerdo = 260.0f;
	public float alturaPrimeiroAndar = -35.0f;
	public float alturaSegundoAndar = 150.0f;
	public float alturaTerceiroAndar = 350.0f;
	public float alturaQuartoAndar = 550.0f;
	public float alturaQuintoAndar = 750.0f;
	public float alturaSextoAndar = 950.0f;
	public float posiçãoEmZ = 20.0f;
	float direcaoEVelocidade = 0.1f;//positivo para direita e negativo para esquerda


	void Start () {
		int andar = Random.Range (1, 7);
		switch (andar) {
		case 2:
			this.gameObject.transform.position = new Vector3 (Random.Range (limiteEsquerdo, limiteDireito), alturaSegundoAndar, posiçãoEmZ);
			break;
		case 3:
			this.gameObject.transform.position = new Vector3 (Random.Range (limiteEsquerdo, limiteDireito), alturaTerceiroAndar, posiçãoEmZ);
			break;
		default:
			this.gameObject.transform.position = new Vector3 (Random.Range (limiteEsquerdo, limiteDireito), alturaPrimeiroAndar, posiçãoEmZ);
			break;
		}

	}
		
	void Update () {
		this.gameObject.transform.Translate (new Vector3 (direcaoEVelocidade, 0.0f, 0.0f));
		//teste dos limites para saber se muda de direcao
		if ((this.gameObject.transform.position.x > limiteDireito) ||
			(this.gameObject.transform.position.x < limiteEsquerdo)) {
			this.direcaoEVelocidade = this.direcaoEVelocidade * -1;
		} else {
			// chance de mudar de direcao
			if (Random.Range (0, 500) <= 1) {
				this.direcaoEVelocidade = this.direcaoEVelocidade * -1;
			}
		}

	}*/

	public float velocidade = 2.0f;
	public bool direcao;
	private float duracaoDirecao = 3.0f;
	private float limiteDireita = 260;
	private float limiteEsquerda = -260;
	private float tempoNaDirecao;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (direcao) {
			transform.eulerAngles = new Vector2(0, 0);
		} else {
			transform.eulerAngles = new Vector2(0, 180);
		}
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);


		//tempoNaDirecao += Time.deltaTime;

//		if (tempoNaDirecao >= duracaoDirecao) {
//			tempoNaDirecao = 0;
//			direcao = !direcao;
//			Debug.Log ("entro no tempo");
//		}

		// chance de mudar de direcao
		//if (Random.Range (0, 10000) <= 2) {
		//	Debug.Log ("entro na probabilidade");
		//	direcao = !direcao;
		//}

		Vector3 posicaoAtual = transform.position;

		if (posicaoAtual.x >= limiteDireita || posicaoAtual.x <= limiteEsquerda ) {
			//Debug.Log ("entro no limite");
			direcao = !direcao;
		}
	}

	void OnCollisionEnter(Collision colisor) {
		if (colisor.gameObject.tag == "Player") {
			Debug.Log ("colide");
			var player = colisor.gameObject;
			//Destroy (player);
			Application.LoadLevel("EndGameScene");
			Debug.Log ("destroi");

		}
	}
}
