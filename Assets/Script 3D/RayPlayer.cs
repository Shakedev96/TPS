using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPlayer : MonoBehaviour
{
    //public GameObject Player;
    public LayerMask LayerMask;
    [SerializeField]
    float lengthOfRay = 5f;




    // transform.position gives the position of the object upon which the script is applied.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            // raycast will hit wherever the mouse points.

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            //mousePosition.z = Camera.main.nearClipPlane; // Setting the z-coordinate to the near clip plane of the camera
            Vector3 direction = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;//transform.forward // This gets the direction from object to mouse
            //
            //Vector3 direction = new Vector3(0, 0, 1);


            Ray rayOfInfo = new Ray(transform.position, direction);
            if (Physics.Raycast(rayOfInfo, out hit, lengthOfRay, LayerMask))//this case layer 1 not affect by raycast
            {
                print(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);

            }
            Debug.DrawRay(transform.position, direction * lengthOfRay, Color.green);

        }

    }
}
/*
 * assignment for unity
make an obstacle course game where you need to use raycast to destroy obstacles and upon collision with an obstacle game over.
not all obstacles should be destroyed by raycast.


if (Input.GetMouseButtonDown(0))
    {
        RaycastHit hit;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;

        Vector3 direction = Camera.main.transform.forward;
        Ray rayOfInfo = new Ray(transform.position, direction);

        if (Physics.Raycast(rayOfInfo, out hit, lengthOfRay, LayerMask))
        {
            print(hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
        }

        Debug.DrawRay(transform.position, direction * lengthOfRay, Color.green);
    }
*/