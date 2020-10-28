using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    private int cubeCounter;
    private List<Vector3> cubePositions;
    private Vector3 newCubePosition;
    public GameObject ground;
    public GameObject cubePrefab;

    void Awake()
    {
        cubePositions = new List<Vector3>();
        newCubePosition = new Vector3(0, 0, 0);
    }
    
    void Start()
    {
        cubeCounter = 0;
        
    }

    void Update()
    {
        if (cubeCounter <10)
        {   
            newCubePosition = RandomCubePositionGenerator(cubePositions, cubePrefab);
            GameObject cube = Instantiate(cubePrefab, newCubePosition, Quaternion.identity);
            cubePositions.Add(newCubePosition);
            cubeCounter++;
        }
        
    }

    Vector3 RandomCubePositionGenerator(List<Vector3> otherCubePositions, GameObject cubePrefab)
    {   
        float x1, z1, x2, z2;
        Vector3 extents = cubePrefab.GetComponent<Renderer>().bounds.extents;

        x1 = Random.Range(ground.GetComponent<Renderer>().bounds.min.x + extents.x, ground.GetComponent<Renderer>().bounds.max.x - extents.x);
        z1 = Random.Range(ground.GetComponent<Renderer>().bounds.min.z + extents.z, ground.GetComponent<Renderer>().bounds.max.z - extents.z);
        
        //Checking if new cube overlaps with another existing cube
        foreach (Vector3 position2 in otherCubePositions)
        {
        x2 = position2.x;
        z2 = position2.z;
        
        if ((z1 <  z2 - 2 * extents.z ) || (z1 > z2 + 2 * extents.z ) || (x1 <  x2 - 2 * extents.x ) || (x1 > x2 + 2 * extents.x ))
            {
                continue;
            }
        else //overlap with an existing cube's position
            {
                return RandomCubePositionGenerator(otherCubePositions, cubePrefab);  //generating new random position  
            }
        }
        
        return new Vector3(x1,0.48f,z1);
    }

    public void decreaseCubeCounter()
    {
        cubeCounter--;
    }
}
