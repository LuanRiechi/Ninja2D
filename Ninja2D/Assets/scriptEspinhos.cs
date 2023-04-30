using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEspinhos : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        scriptPc.morrendo = true;
        Destroy(collision.gameObject, 0.5f);
    }
}
