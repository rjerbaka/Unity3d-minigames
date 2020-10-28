using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{   
    private Collider attachedObject;
    private Rigidbody attachedRB;
    private RaycastHit hit;
    private float offset;
    public Texture2D cursorDefault;
    public Texture2D cursorHoldable;
    public Texture2D cursorHeld;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        attachedObject = null;
        offset = 0;
        Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {  
        Ray ray = this.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, ray.direction*100, Color.blue);
        holdObject(ray);

    }

    void FixedUpdate()
    {      
    }

    void holdObject(Ray ray)
    {   
        Vector3 offsetVect = new Vector3(1,1,1);
        int layerMask = 1 << 8; // Cast rays only against objects in layer 8 ("Holdable Objects" layer)

        if (Input.GetMouseButtonDown(0) && attachedObject == null)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                attachedObject = hit.collider;
                attachedRB = hit.rigidbody;
                offset = hit.distance; 
                Cursor.SetCursor(cursorHeld, hotSpot, cursorMode);
            }
        }
        else if (Input.GetMouseButton(0) && attachedObject != null)
        {
            offsetVect.Set(1, 1, offset);

            // Rigidbody case //
            if (attachedRB != null)
            {
                attachedRB.isKinematic = true;
                attachedRB.MovePosition(ray.origin + offset * ray.direction);
            }

            // Non-Rigidbody collider case //
            else
            {
                attachedObject.transform.position = ray.origin + offset * ray.direction;
            }

            Cursor.SetCursor(cursorHeld, hotSpot, cursorMode); 
        }
        else if (Input.GetMouseButtonUp(0) && attachedObject != null)
        {
            if (attachedRB != null)
            {
                attachedRB.isKinematic = false;
            }
            
            attachedObject = null;
            Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
        }
        else 
        {   if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Cursor.SetCursor(cursorHoldable, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
            }
        }

    }

}
