using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Vector2 velocity;
    public bool facingRight = false;
    bool canShoot=  true;
    public Vector2 offset = new Vector2(1.4f,0.1f);
    public float cooldown = 1.0f;
    public float moveX;
    public GameObject fire_power;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
        fire_power.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown (KeyCode.C) && canShoot)
        {
            GameObject go = (GameObject)           Instantiate(projectile,(Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

            go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);

            StartCoroutine (CanShoot());
        }

        if(facingRight ==  true)
        {
            velocity = -velocity;
        }
        else if(facingRight == true)
        {

        }

    }

    public void Power_Up()
    {
        canShoot = true;
        fire_power.SetActive(true);
    }

    public void turn_off()
    {
        canShoot = false;
        fire_power.SetActive(false);
    }

    


    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds (cooldown);
        canShoot = true;
    }


        void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
