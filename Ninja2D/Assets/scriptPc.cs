using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPc : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rbd;
    public float velocidade = 5;
    public float pulo = 470;
    private bool chao = false;
    private bool direita = true;
    public GameObject pe;
    public LayerMask mascara;
    public static bool morrendo;
    private float x;
    private RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        morrendo = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        movimentoPc();

        puloPc();


        AnimacaoPC();

        hit = Physics2D.Raycast(pe.transform.position,
                        -pe.transform.up,
                        0.1f,
                        mascara);

        colisorPc(hit);

    }
    public void AnimacaoPC()
    {
        anim.SetFloat("velocidadeX", Mathf.Abs(x));

        anim.SetFloat("velocidadeY", rbd.velocity.y);


        anim.SetBool("chao", chao);

        if (morrendo)
        {
            anim.SetTrigger("morrendo");
        }
    }

    public void movimentoPc()
    {
        x = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y);

        if (direita && x < 0 || !direita && x > 0)
        {
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }

    }

    public void puloPc()
    {
        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rbd.AddForce(new Vector2(0, pulo));
        }

        if (Input.GetKey(KeyCode.Space) && !chao && rbd.velocity.y < -1)
        {

             rbd.gravityScale = 0.5f;
             anim.SetBool("planando", true);
            
        } else
        {
            rbd.gravityScale = 3;
            anim.SetBool("planando", false);
        }
    }

    public void colisorPc(RaycastHit2D hit)
    {

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 6)
            {
                chao = true;
                transform.parent = hit.collider.transform;
            }
            else if (hit.collider.gameObject.layer == 7)
            {
                if (hit.collider.gameObject.tag == "npc")
                {
                    rbd.AddForce(new Vector2(0, pulo), ForceMode2D.Force);
                    scriptNpc.npcMorrendo = true;
                    hit.collider.GetComponent<BoxCollider2D>().enabled = false;
                    hit.collider.GetComponent<CircleCollider2D>().enabled = false;
                    Transform filhonpc1 = hit.collider.transform.GetChild(0);
                    Destroy(filhonpc1.gameObject);
                    Destroy(hit.collider.gameObject, 1);

                } else if (hit.collider.gameObject.tag == "npc2")
                {
                    rbd.AddForce(new Vector2(0, pulo), ForceMode2D.Force);
                    scriptNpc2.npc2Morrendo = true;
                    hit.collider.GetComponent<BoxCollider2D>().enabled = false;
                    hit.collider.GetComponent<CircleCollider2D>().enabled = false;
                    Transform filhonpc2 = hit.collider.transform.GetChild(0);
                    Destroy(filhonpc2.gameObject);
                    Destroy(hit.collider.gameObject, 1);
                }
            }

        }
        else
        {
            chao = false;
            transform.parent = null;
        }
    }
}

