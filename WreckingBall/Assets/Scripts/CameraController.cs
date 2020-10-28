using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   public GameObject baseObject; // l’objet à suivre
    private Vector3 offset; //l'offset initial

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - baseObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = baseObject.transform.position + offset;
    }
}
