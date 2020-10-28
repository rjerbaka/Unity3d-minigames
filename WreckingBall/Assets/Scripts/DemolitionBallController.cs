using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemolitionBallController : MonoBehaviour
{   
    public GameObject ball;

    private int speed = 500; //wrecking ball force speed/power
    private Vector3 ballStartPosition;	
    

    // Start is called before the first frame update
    void Start()
    {
        ballStartPosition = ball.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DemolitionBallMovement();
        
    }

    void DemolitionBallMovement()
    {   
        //Random force generation
        Vector3 forceVect = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        gameObject.GetComponent<Rigidbody>().AddForce(speed * forceVect * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball") //when wrecking ball hits the ball
        {
            ball.transform.position = ballStartPosition; //ball goes back to its start position
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero; //ball's speed set to 0
        }
    }
}
