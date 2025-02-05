using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject Player;

    private Vector3 Offset;  // Distance between player and cam

    // Start is called before the first frame update
    void Start()
    {
        Offset = transform.position - Player.transform.position;
        
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + Offset;
        
    }
}
//;        //Public variable to store a reference to the player game object


//          //Private variable to store the offset distance between the player and camera

//// Use this for initialization
//void Start()
//{
//    //Calculate and store the offset value by getting the distance between the player's position and camera's position.
//    offset = transform.position - player.transform.position;
//}

//// LateUpdate is called after Update each frame
//void LateUpdate()
//{
//    // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
//    transform.position = player.transform.position + offset;
//}