using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TranslateMove : MonoBehaviour
{
    float VerticalMove;
    float HorizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalMove = Input.GetAxis("Vertical");
        HorizontalMove = Input.GetAxis("Horizontal");

        this.gameObject.transform.Translate(HorizontalMove, 0, VerticalMove);

    }
}


/*
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 200.0f;

    void Update()
    {
        // Get input from player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = transform.forward * vertical * moveSpeed * Time.deltaTime;
        Vector3 rotation = transform.up * horizontal * rotationSpeed * Time.deltaTime;

        // Apply movement and rotation
        transform.Translate(movement, Space.World);
        transform.Rotate(rotation);
    }
 */
