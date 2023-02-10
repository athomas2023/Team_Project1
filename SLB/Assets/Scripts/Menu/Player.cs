using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public bool facingRight = false;
    public float jumpForce = 5.0f;
    public float moveX;
    
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        }
    }
    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        

        
        if (moveX < 0.0f && facingRight == false)
        {   
            FlipPlayer ();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * moveSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


}
