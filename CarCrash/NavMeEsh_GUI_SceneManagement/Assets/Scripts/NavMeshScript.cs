using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{   
    public GameObject destinationObj; //Empty GameObject whose position is the final destination
    private NavMeshAgent carMeshAgent; //NavMeshAgent Component


    // Start is called before the first frame update
    void Start()
    {   
        carMeshAgent = GetComponent<NavMeshAgent>();
        carMeshAgent.SetDestination(destinationObj.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (carMeshAgent.remainingDistance == 0 && carMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Destroy(gameObject);
        }
    }

    public void setDestinationObj(GameObject Obj)
    {
        destinationObj = Obj;
    }
}
