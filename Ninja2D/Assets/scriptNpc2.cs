using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNpc2 : MonoBehaviour
{
    private Rigidbody2D rbd;
    public GameObject frenteNpc;
    public float velocidade = 6;
    public LayerMask mascara;
    private Animator anim;
    public static bool npc2Morrendo = false;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        colisorNpc();
        velocidadeNpc();
    }

    public void velocidadeNpc()
    {
        if (npc2Morrendo)
        {
            anim.SetTrigger("morrendo");
            anim.SetBool("vivo", false);
            rbd.velocity = new Vector2(0, 0);
            Invoke("cancelMorte", 1f);
        }
        else
        {
            rbd.velocity = new Vector2(velocidade, 0);
        }
    }

    private void cancelMorte()
    {
        npc2Morrendo = false;
        anim.SetBool("vivo", true);
    }

    private void rotacao()
    {
        velocidade = velocidade * -1;
        rbd.velocity = new Vector2(velocidade, 0);
        transform.Rotate(new Vector2(0, 180));

    }

    private void CancelarAtacando()
    {
        anim.SetBool("atacando", false);
    }

    public void colisorNpc()
    {
        RaycastHit2D hit;

        if (frenteNpc != null)
        {
            hit = Physics2D.Raycast(frenteNpc.transform.position, frenteNpc.transform.right, 0.1f, mascara);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.layer == 6)
                {
                    rotacao();
                }
                if (hit.collider.gameObject.layer == 8)
                {
                    anim.SetBool("atacando", true);
                    scriptPc.morrendo = true;
                    rbd.velocity = new Vector2(0, 0);
                    Invoke("CancelarAtacando", 0.4f);
                    Destroy(hit.collider.gameObject, 0.5f);
                }

            }
        }

    }
}
