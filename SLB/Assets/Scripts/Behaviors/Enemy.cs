using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Vector2 direction = Vector2.left;
    public float speed = 2f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pipes"))
        {
            direction = -direction;
        }
        

        if(collision.gameObject.CompareTag("Enemy"))
        {
            direction = -direction;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

          
            if (collision.transform.DotTest(transform, Vector2.down)) 
            {
                Flatten();
            } 
            else 
            {
                player.ChangeHealth(-1);
            }
        }
    }

   

     
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shell")) {
            Hit();
        }
    }

    private void Flatten()
    {
        
        Destroy(gameObject);
    }

    private void Hit()
    {
        
        Destroy(gameObject);
    }


}
