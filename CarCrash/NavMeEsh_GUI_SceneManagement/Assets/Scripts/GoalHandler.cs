using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{
    public GameObject otherGoal; 
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player")
            {
                //Turning off current side's collider
                GetComponent<Collider>().enabled = false;

                //Turning on other side's collider
                otherGoal.GetComponent<Collider>().enabled = true;

                //Increasing Score
                gameManager.increaseScore();
                Debug.Log(gameManager.getScore());

            }
    }
}
