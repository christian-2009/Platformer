using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2f;
    [SerializeField] float rotationSpeed = 2f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        
        HandleMoving();
        HandleRotation();
    }

    void HandleMoving() 
    {
        if (Input.GetKey(KeyCode.W))
        {
           
            transform.Translate(Vector3.forward * Time.deltaTime * speed );
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed );
        }
    }

    void HandleRotation()
    {   
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * rotationSpeed );
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed );
        }
    }

}
