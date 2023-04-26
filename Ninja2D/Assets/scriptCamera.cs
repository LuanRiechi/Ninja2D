using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject pc;
    public float offset_x = 3;
    public float offset_y = 1;
    private Vector3 posAtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pc != null)
        {
            Vector3 posicaoPc = new Vector3(pc.transform.position.x + offset_x,
                                pc.transform.position.y + offset_y,
                                -10);
            posAtualCamera = posicaoPc;
            transform.position = posicaoPc;
        }
        else
        {
            transform.position = posAtualCamera;
        }
        
    }
}
