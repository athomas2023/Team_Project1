using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_detector : MonoBehaviour
{

    public bool fallD = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();


        if (controller != null)
        {

            if(fallD == true)
            {
                controller.fallDetection1();
            }

            if(fallD == false)
            {
               controller.fallDetection2(); 
            }

        }
    }
}
