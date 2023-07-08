using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float buttonTime = 0.01f;
    [SerializeField] float jumpAmount = 20f;
    
    Rigidbody rb;

    float jumpTime = 0;
    bool isJumping;
    bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision other) {
        isGrounded = true;
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
        HandleJump();
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

    void HandleJump()
    {
        bool isJumpPressed = Input.GetKey(KeyCode.Space);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            
        }

        if(isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
            isGrounded = false;
            jumpTime += Time.deltaTime;
        }
        
        if(Input.GetKeyUp(KeyCode.Space) || jumpTime > buttonTime)
        {
            isJumping = false;
            rb.AddForce(Vector3.down * 5f * rb.mass);
     
        }

        if(isGrounded)
        {
            jumpTime = 0;
        }

     

    }

}
