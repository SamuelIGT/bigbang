using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour {
    private SistemaDeDano SDano;
    private GameObject jogador;
    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
        SDano = jogador.GetComponent<SistemaDeDano>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SDano.perdeVida(20);
        }
    }
}
