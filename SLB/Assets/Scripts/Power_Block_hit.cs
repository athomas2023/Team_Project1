using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Block_hit : MonoBehaviour
{
    Animator anime_blck;
    public GameObject item;
    public Vector2 offset = new Vector2(0f,0.9f);
    public bool Ifhit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anime_blck = GetComponent<Animator>();
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up)) 
            {
                if(Ifhit == false)
                { 
                    Hit();
                }

                if(Ifhit== true)
                {
                    
                }
            }
        }
    }

    private void Hit()
    {
        anime_blck.SetBool("Hit", true);
        Instantiate(item,(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
        Ifhit = true;

    }

    
}
