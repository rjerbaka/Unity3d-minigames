using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour
{   
    private const int MAXFRAMES = 200; //max number of frames between two car instantiations
    private const int MINFRAMES = 10; //min number of frames between two car instantiations

    private int frameCounter; //frame counter between two instantiations
    private int generatorRate; //frame number between two instantiations (chosen randomly)

    public Rigidbody carPrefab; //prefab to instantiate

    //empty GameObjects representing start/end car positions in the scene
    public GameObject startPosition1;
    public GameObject startPosition2;
    public GameObject startPosition3;
    public GameObject startPosition4;
    public GameObject endPosition1;
    public GameObject endPosition2;
    public GameObject endPosition3;
    public GameObject endPosition4;

    // Start is called before the first frame update
    void Start()
    {
        frameCounter = 0;
        generatorRate = 103; //number of frames before first car creation
        
    }

    // Update is called once per frame
    void Update()
    {   if (frameCounter >= generatorRate)
        {
            Debug.Log("Car creation");

            if (Random.Range(1,100)%4 == 0)
            {   
                //Instantiate a car in road 1 & set start position
                Rigidbody car1 = Instantiate(carPrefab, startPosition1.transform.position, 
                startPosition1.transform.rotation) as Rigidbody;

                //set end position of newly instantiated car
                car1.GetComponent<NavMeshScript>().setDestinationObj(endPosition1);
            }

            if (Random.Range(1,100)%4 == 1)
            {   
                Rigidbody car2 = Instantiate(carPrefab, startPosition2.transform.position, 
                startPosition2.transform.rotation) as Rigidbody;

                car2.GetComponent<NavMeshScript>().setDestinationObj(endPosition2);
            }
            
            if (Random.Range(1,100)%4 == 2)
            {   
                Rigidbody car3 = Instantiate(carPrefab, startPosition3.transform.position, 
                startPosition3.transform.rotation) as Rigidbody;

                car3.GetComponent<NavMeshScript>().setDestinationObj(endPosition3);
            }

            if (Random.Range(1,100)%4 == 3)
            {   
                Rigidbody car4 = Instantiate(carPrefab, startPosition4.transform.position, 
                startPosition4.transform.rotation) as Rigidbody;

                car4.GetComponent<NavMeshScript>().setDestinationObj(endPosition4);
            }

            frameCounter = 0; //reset frame counter
            generatorRate = Random.Range(MINFRAMES, MAXFRAMES); //new random delay value (by number of frames)

        }


        frameCounter++;
    }
}
