using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptFalsaplataforma : MonoBehaviour
{
    public float tempoQueda;
    private TargetJoint2D target;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Invoke("queda", tempoQueda);
        }
    }

    private void queda()
    {
        target.enabled = false;
    }
}
