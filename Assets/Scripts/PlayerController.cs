using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public float xRange = 10;
    public float horizontalInput;
    public float moveDistance = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


         if (Input.GetKeyDown(KeyCode.W) && transform.position.z < 10)
        {
            Vector3 newPosition = transform.position + Vector3.forward * moveDistance;
            transform.position = newPosition;
        }
        
       
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z > -10)
        {
            Vector3 newPosition = transform.position + Vector3.back * moveDistance;
            transform.position = newPosition;
        }

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 newPosition = transform.position - Vector3.right * moveDistance;
            transform.position = newPosition;
        }

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 newPosition = transform.position + Vector3.right * moveDistance;
            transform.position = newPosition;
        }
    }
}
