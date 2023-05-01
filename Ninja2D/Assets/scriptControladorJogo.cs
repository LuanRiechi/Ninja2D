using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptControladorJogo : MonoBehaviour
{
    public GameObject pc;
    public GameObject telaGameOver;
    public GameObject telaFinalFase;

    // Update is called once per frame
    void Update()
    {
        if (pc == null)
        {
            telaGameOver.SetActive(true);
        }
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(1);
    }

    public void menuIniciar()
    {
        SceneManager.LoadScene(0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            telaFinalFase.SetActive(true);
        }
    }
}
