using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int speed = 2;
    public GameObject cubeManager;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
      KeyboardMovements();
    }
    
    void OnCollisionEnter(Collision collideEvent)
      {   if(collideEvent.gameObject.tag == "Cube")
          { 
            Destroy(collideEvent.gameObject);
            cubeManager.GetComponent<CubeGenerator>().decreaseCubeCounter();
          }
      }

    void KeyboardMovements()
    {
      if (Input.GetKey("right"))
      {
        rb.AddForce(Vector3.right * speed);
      }

      if(Input.GetKey("left"))
      {
          rb.AddForce(Vector3.left * speed);
      }

      if (Input.GetKey("up"))
      {
        rb.AddForce(Vector3.forward * speed);
      }

      if(Input.GetKey("down"))
      {
          rb.AddForce(Vector3.back * speed);
      }

      }

}
