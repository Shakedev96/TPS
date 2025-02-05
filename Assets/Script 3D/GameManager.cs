using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RawImage gameOverImage;
    public GameObject Player;

    public float minYPosition; // Set this value to the minimum y position for falling off.
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minYPosition)
        {
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
/*using UnityEngine;

public class EndGameOnFalling : MonoBehaviour
{
    
    void Update()
    {
       
    }

    
}

 */