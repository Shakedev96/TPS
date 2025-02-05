using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollision : MonoBehaviour
{
    public RawImage gameOverImage;
    public GameObject Player;

    public float pushForce = 10f;//to push player
    // Start is called before the first frame update
    void Start()
    {
        gameOverImage.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RotatingObstacle"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
                rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
        if (collision.gameObject.CompareTag("MovingObstacle"))
        {
            // End the game (you can implement this according to your specific game logic)
            EndGame();
        }
    }

    void EndGame()
    {
        gameOverImage.gameObject.SetActive(true);
        Debug.Log("Game Over");
        Player.SetActive(false);
    }
}
