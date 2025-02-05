using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public float speed = 5.0f;
    //private float HorizontalMove;
    //private float Vertivalmove;
    [SerializeField]
    public float speed = 50f;

    public float jump = 1f;


    private Rigidbody RB;

    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //HorizontalMove = Input.GetAxis("Horizontal");
        //Vertivalmove = Input.GetAxis("Vertical");

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        RB.velocity = new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);

        //Vector3 Movement = transform.forward * z + transform.right * x;
        //Movement = Movement.normalized * speed * Time.deltaTime;

        //RB.MovePosition(transform.position + Movement);

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Is Jumping");
        //    RB.AddForce(Vector3.up * jump, ForceMode.Impulse);
        //}

        //if (x < 0 || x > 0)
        //{
        //    RB.velocity = new Vector3(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
        //}


    }

   
}

/*

    void Update()
    {
        // Get input from player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        // Apply movement
        rb.MovePosition(transform.position + movement);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

 */
