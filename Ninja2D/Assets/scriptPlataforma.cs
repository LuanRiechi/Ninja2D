using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlataforma : MonoBehaviour
{
    private float count;
    private Vector2 posInicial;
    public float deslocamento;
    public float altura;
    public float largura;

    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(count) * largura;
        float y = Mathf.Cos(count) * altura;

        transform.position = new Vector2(posInicial.x + x, posInicial.y + y);

        count += deslocamento * Time.deltaTime;

        if (count >= 2 * Mathf.PI)
        {
            //cont = 0; para o contador voltar para o valor 0 hora que passar do valor 2pi.
            count = count - 2 * Mathf.PI;//faz o ajuste fine, pois o cont vai passar o valor de 2Pi, assim ele vai jogar a diferença desse valor e nao vai realocar a plataforma.

        }

    }
}
