using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public GameObject Player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private float new_xMin;
    public float Units;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag ("Player");

        new_xMin = transform.position.x -Units;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp (Player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp (Player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
    }

    void Update()
    {

        // Prevent camera from moving left.
        if ( Input.GetKeyDown(KeyCode.RightArrow))
        {
            new_xMin = transform.position.x -Units;
        }

        Camera_Lock();
    }

    private void Camera_Lock()
    {
        if (new_xMin >= xMin )
        {
            xMin = new_xMin;
        }
    }
}
