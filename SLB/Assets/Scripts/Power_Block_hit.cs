using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Block_hit : MonoBehaviour
{
    Animator anime_blck;
    
    // Start is called before the first frame update
    void Start()
    {
        anime_blck = GetComponent<Animator>();
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DotTest(transform, Vector2.up)) {
                Hit();
            }
        }
    }

    private void Hit()
    {
        anime_blck.SetBool("Hit", true);
    }

    
}
