using UnityEngine;
using System.Collections;

public class MinionStealthScript : MonoBehaviour {

	public float limiteDireito = 4.5f;
	public float limiteEsquerdo = -12f;
	public float alturaPrimeiroAndar = -9.5f;
	public float alturaSegundoAndar = -3.0f;
	public float alturaTerceiroAndar = 2.4f;
	public float posiçãoEmZ = 10.4f;
	float direcaoEVelocidade = 0.05f;//positivo para direita e negativo para esquerda


	void Start () {
		int andar = Random.Range (1, 3);
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
