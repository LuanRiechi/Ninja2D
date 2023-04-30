using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenuInicial : MonoBehaviour
{
    public GameObject painelMenuInicial;
    public GameObject painelControles;

    public void iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void abrirControles()
    {
        painelMenuInicial.SetActive(false);
        painelControles.SetActive(true);
    }

    public void fecharControles()
    {
        painelMenuInicial.SetActive(true);
        painelControles.SetActive(false);
    }

    public void sair()
    {
        Debug.Log("saindo do jogo");
        Application.Quit();
    }
}
