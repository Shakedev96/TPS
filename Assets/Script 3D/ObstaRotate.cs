using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaRotate : MonoBehaviour
{
    public Transform centerOfRotation; 
    public float rotationSpeed = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(centerOfRotation.position, Vector3.up, rotationSpeed * Time.deltaTime);

    }
}
