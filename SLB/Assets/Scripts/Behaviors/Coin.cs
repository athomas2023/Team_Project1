using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool ifFlower = false;
    // Start is called before the first frame update
    void Awake()
    {
        Score score = GetComponent<Score>();
        Player player = GetComponent<Player>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        Score score = other.gameObject.GetComponent<Score>();
        Player player = other.gameObject.GetComponent<Player>();

        if (other.gameObject.CompareTag("Player"))
        {
           if( ifFlower == false)
           {
             score.Change_Score(100);
              Destroy(gameObject);
             Debug.Log("add points");
           }

          else if(ifFlower == true)
           {
             player.turn_on();
             score.Change_Score(100);
              Destroy(gameObject);
             Debug.Log("add points");
           }


        }
    }
}
