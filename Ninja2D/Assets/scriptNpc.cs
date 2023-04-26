using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNpc : MonoBehaviour
{
    private Rigidbody2D rbd;
    public GameObject frenteNpc;
    public float velocidade = 5;
    public LayerMask mascara;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(velocidade, 0);

        RaycastHit2D hit;
        hit = Physics2D.Raycast(frenteNpc.transform.position, frenteNpc.transform.right, 0.2f, mascara);

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 6)
            {
                velocidade = velocidade * -1;
                rbd.velocity = new Vector2(velocidade, 0);
                transform.Rotate(new Vector2(0, 180));
            }
            if (hit.collider.gameObject.layer == 8)
            {
                Destroy(hit.collider.gameObject);
            }
            
        }
        
    }
}