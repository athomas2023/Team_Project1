using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(auto());
    }

   IEnumerator auto()
    {
       
        yield return new WaitForSeconds(1);
       Destroy(gameObject);
        

    }
}
