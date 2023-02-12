using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 velocity;
    public GameObject explosion;
    public GameObject scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        Destroy (this.gameObject, 10);
        rb = GetComponent<Rigidbody2D>();

        Score score = GetComponent<Score>();
        velocity = rb.velocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < velocity.y)
            rb.velocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        rb.velocity = new Vector2 (velocity.x, -velocity.y);

        if(col.contacts [0].normal.x !=0)
        {
            explode();
        }

        if(col.collider.tag == "Enemy")
        {
            
            Destroy (col.gameObject);
            explode();
        }
    }

    void explode()
    {
        Destroy(this.gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);
    }
}
