using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Vector2 velocity;
    bool canShoot=  true;
    public Vector2 offset = new Vector2(1.4f,0.1f);
    public float cooldown = 1.0f;
    public float moveX;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove();
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

    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");

        if(moveX < 0.0f)
        {
            velocity.x = -velocity.x;
        }
    }


    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds (cooldown);
        canShoot = true;
    }
}
