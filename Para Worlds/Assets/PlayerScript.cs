using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float jump;
    public float maxSpeed;
    public float dashMaxSpeed;

    private bool canJump;

    public float dashSpeed;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey("d"))
        {
            rb.AddRelativeForce(Vector3.right * speed);
            
        }
        if (Input.GetKey("a"))
        {
            rb.AddRelativeForce(Vector3.left * speed);

        }
        if (Input.GetKeyDown("space"))
        {
            Jump();

        }

        if(rb.velocity.magnitude > maxSpeed)
        {

            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Floor")
        {
            canJump = true;
            Debug.Log("canJump");

        }

    }

    void Jump()
    {
        if(canJump)
        {
            rb.AddRelativeForce(Vector3.up * jump);
            canJump = false;

        }
        
    }

    void Dash()
    {

        rb.AddRelativeForce(Vector3.right * dashSpeed);

    }

}

