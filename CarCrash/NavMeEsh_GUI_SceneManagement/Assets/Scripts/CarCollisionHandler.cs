using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionHandler : MonoBehaviour
{   
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Car Hit " + other.gameObject.name);
        if (other.gameObject.tag == "Player") //if player is hit by car
        {   
            //Decrease Score
            gameManager.decreaseScore();
            Debug.Log(gameManager.getScore());
            
            //Switch goal side if needed
            gameManager.goal1.GetComponent<Collider>().enabled = false;
            gameManager.goal2.GetComponent<Collider>().enabled = true;

            //Teleport player back to starting position
            gameManager.player.SetActive(false);
            gameManager.player.transform.position = gameManager.getStartingPosition();
            gameManager.player.transform.rotation = gameManager.getStartingRotation();
            gameManager.player.SetActive(true);
        }

        // if (other.gameObject.tag == "Car") //if car hits another car
        // {   
        //      Destroy(other.gameObject); //remove the hit car from scene

        // }
    }
}
