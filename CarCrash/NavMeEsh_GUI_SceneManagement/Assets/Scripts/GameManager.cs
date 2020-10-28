using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    private int currentScore;
    private Vector3 startPosition;
    private Quaternion startRotation;

    public GameObject player;
    public GameObject goal1;
    public GameObject goal2;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        startPosition = player.transform.position;
        startRotation = player.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore()
    {
        currentScore++;
    }
    
    public void decreaseScore()
    {
        if (currentScore>0) //Score can't be negative
            {
                currentScore--;
            }
    }

    public int getScore()
    {
        return currentScore;
    }

    public Vector3 getStartingPosition()
    {
        return startPosition;
    }

    public Quaternion getStartingRotation()
    {
        return startRotation;
    }
}
