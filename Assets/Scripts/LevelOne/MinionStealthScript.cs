using UnityEngine;
using System.Collections;

public class MinionStealthScript : MonoBehaviour {

	public float limiteDireito = -260.0f;
	public float limiteEsquerdo = 260.0f;
	public float alturaPrimeiroAndar = -45.5f;
	public float alturaSegundoAndar = 150.0f;
	public float alturaTerceiroAndar = 350.0f;
	public float alturaQuartoAndar = 550.0f;
	public float alturaQuintoAndar = 750.0f;
	public float alturaSextoAndar = 950.0f;
	public float posiçãoEmZ = 10.0f;
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

	}
}
