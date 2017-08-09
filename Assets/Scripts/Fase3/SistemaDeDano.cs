using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaDeDano : MonoBehaviour
{

    private int vida = 100;

    public void perdeVida(int dano)
    {
        vida = vida - dano;
        Debug.Log(">> " + vida + " <<");
        Debug.Log("-- Dano causado: " + dano + " --");
    }

    void Update()
    {
        
        if (vida <= 0) {
            SceneManager.LoadScene("EndGameScene");
        }
    }

    //UI da vida atualiza em uma função aqui

}