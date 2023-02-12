using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public bool facingRight = false;
    public float jumpForce = 5.0f;
    public float moveX;
    public Score sc;
    
    public GameObject Game_Over_canvas;
    public GameObject World_1_1_canvas;
    public GameObject World_1_2_canvas;
    public GameObject win_game_canvas;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    public int maxHealth = 2;
    public int health { get { return currentHealth; } }
   public int currentHealth;
  public bool powered_uped = false;


    public bool temp_ack = false;

    Animator anime;
    
    Rigidbody2D rb;

    Vector2 Scale;

    Shoot shoot;

     AudioSource audioSource;
      public AudioClip throwSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        shoot = GetComponent<Shoot>();

        audioSource = GetComponent<AudioSource>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
            anime.SetFloat("walking", Mathf.Abs(moveX));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            anime.SetBool("On_Ground", false);
            PlaySound(throwSound);
        }

          if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if ( currentHealth == 0)
        {
            Game_Over_canvas.SetActive(true);
        }

        if (currentHealth == 2)
        {
            maxHealth = 2;
            powered_uped = false;
        }


        if (temp_ack == true)
        {
            attactk();
            
            temp_ack = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(collision.gameObject.CompareTag("Enemy"))
        {
          
            attactk();
           
        }

        

        if(collision.gameObject.CompareTag("Ground"))
        {
          
          anime.SetBool("On_Ground", true);
           
        }

        if(collision.gameObject.CompareTag("PowerBlock"))
        {
            anime.SetBool("On_Ground", true);
        
        }

    

        
    }

   


    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
           if(powered_uped == false  )
           {
             Scale = transform.localScale;

              Scale.y -= 0.5f;

              transform.localScale = Scale;
              
           }

           if(powered_uped == true && currentHealth == 2)
           {
              
                shoot.turn_off();
                maxHealth = 2;
                powered_uped = false;

           }

           
             
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        
    }

    public void turn_on()
    {
        if (currentHealth ==1 )
        {
        Scale = transform.localScale;

        Scale.y += 0.5f;

        transform.localScale = Scale;
        }      

        powered_uped = true;
        currentHealth = 3;
        maxHealth = 3;
        shoot.Power_Up();
    }


    public void fallDetection1()
    {
        Game_Over_canvas.SetActive(true);
    }

    public void fallDetection2()
    {
        win_game_canvas.SetActive(true);
        Time.timeScale = 0;
    }


    public void attactk()
    {
        ChangeHealth(-1);
    }


     public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}
