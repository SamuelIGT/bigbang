using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHod : MonoBehaviour {
	// Hod tem 3 estados
	// 1 normal onde ele ataca a cada 5 segundos
	// 2 retraindo quando ele recebe dano e diminui de tamanho para fugir
	// 3 teletranporte quando ele muda de lado 
	// 4 expandindo quando volta ao tamanho original
	int estado = 1; // começa normal
	float tempoUltimoTiro;

	//atirar
	public GameObject prefabBola;
	float offset = 2.5f;
	int posicao = -1; //-1 para Hod está à direita do plano e 1 para esquerda do plano


	//posicoes
	//Vector3 direita = new Vector3(8.0f,1.0f,0.0f);
	//Vector3 esquerda = new Vector3(-8.0f,1.0f,0.0f);

	// Use this for initialization
	void Start () {
		tempoUltimoTiro = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		switch(estado){
		case 1: 
			if (Time.timeSinceLevelLoad - tempoUltimoTiro > 5.0f) {
				tempoUltimoTiro = Time.timeSinceLevelLoad;
				this.Atirar ();
			}
			break;
		case 2:
			this.transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
			if (this.transform.localScale.x <= 1.0f) {
				this.estado = 3;
			}
			break;
		case  3:
			if (posicao == -1) {
				this.transform.position = new Vector3 (-7.5f, 1.0f, Random.Range (-3.0f, 3.0f)); //esquerda;
				posicao = 1;
			} else if (posicao == 1) {
				this.transform.position = new Vector3 (7.5f, 1.0f, Random.Range (-3.0f, 3.0f)); //direita;
				posicao = -1;
			}
			this.estado = 4;
			break;
		case 4:
			this.transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
			if (this.transform.localScale.x >= 5.0f) {
				this.estado = 1;
			}
			break;
		}
	}

	void Atirar() {
		GameObject go = Instantiate (prefabBola) as GameObject;
		go.transform.position = this.transform.position + new Vector3 (offset * posicao, 0.0f, 0.0f);
		go.GetComponent<MovimentacaoBolaScript> ().SetDirecao (posicao);
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			this.estado = 2;
		}
	}
}
