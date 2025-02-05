using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Transform po1, po2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == startPos.position)
        {
            nextPos = po1.position;
        }
        if (transform.position == po1.position)
        {
            nextPos = po2.position;
        }
        if (transform.position == po2.position)
        {
            nextPos = po1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}

/*
  public class MoveObstace : MonoBehaviour
{
    public Transform po1, po2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == startPos.position)
        {
            nextPos = po1.position;
        }
        if (transform.position == po1.position)
        {
            nextPos = po2.position;
        }
        if (transform.position == po2.position)
        {
            nextPos = po1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
 * 
 */