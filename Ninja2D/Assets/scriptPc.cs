using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPc : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rbd;
    public float velocidade = 5;
    public float pulo = 350;
    private bool chao = false;
    private bool direita = true;
    public GameObject pe;
    public LayerMask mascara;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rbd.AddForce(new Vector2(0,pulo));
            anim.SetBool("pulando", true);
        }

        if (direita && x < 0 || !direita && x > 0)
        {
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }

        if (x == 0)
        {
            anim.SetBool("correndo", false);
        }
        else
        {
            anim.SetBool("correndo", true);
        }

        RaycastHit2D hit;
        hit = Physics2D.Raycast(pe.transform.position,
                                -pe.transform.up,
                                0.1f,
                                mascara);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 6)
            {
                chao = true;
                anim.SetBool("pulando", false);
                transform.parent = hit.collider.transform;
            }
            if (hit.collider.gameObject.layer == 7)
            {
                rbd.AddForce(new Vector2(0, pulo));
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            chao = false;
            transform.parent = null;
        }

    }

}
