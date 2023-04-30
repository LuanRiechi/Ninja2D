using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptControladorJogo : MonoBehaviour
{
    public GameObject pc;
    public GameObject telaGameOver;

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
}
