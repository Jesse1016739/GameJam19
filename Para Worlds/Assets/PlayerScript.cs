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

    public float dashTimer;

    private bool isGhost;
    private int howManyJumps;
    private int jumps;

    

    // Start is called before the first frame update
    void Start()
    {
        isGhost = false;

        canJump = true;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dashTimer -= Time.deltaTime;

        if(dashTimer < 0)
        {
            maxSpeed = 20f;
            rb.useGravity = true;
        }



        if (Input.GetKey("d"))
        {
            this.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            rb.AddRelativeForce(Vector3.forward * speed);           
        }
        if (Input.GetKey("a"))
        {
            rb.AddRelativeForce(Vector3.forward * speed);
            this.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
        }



        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
        if (Input.GetKeyDown("q"))
        {
            Dash();
        }

        if (rb.velocity.magnitude > maxSpeed)
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
            jumps = 0;
        }

    }

    void Jump()
    {
        if (isGhost == false)
        {
            howManyJumps = 2;
        }
        if (isGhost == true)
        {
            howManyJumps = 1;
        }
        

        if (canJump)
        {
            rb.AddRelativeForce(Vector3.up * jump);
            jumps++;
        }
        if(howManyJumps <= jumps)
        {

            canJump = false;
        }
    }

    void Dash()
    {
        maxSpeed = dashMaxSpeed;

        
        rb.velocity = (Vector3.forward * dashSpeed);
        rb.useGravity = false;
        dashTimer = .5f;
    }

    void Ghost()
    {
        

    }


}

