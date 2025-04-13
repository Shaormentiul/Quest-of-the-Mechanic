using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    public GameObject heldObj;
    private Rigidbody heldObjRB;
    private GameObject activeObjOutline;
    
    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;
    [SerializeField] private LayerMask pickUpLayer;

    private void Update()
    {
       
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    if(hit.collider.CompareTag("PickUpAble"))
                    {
                            activeObjOutline = hit.transform.gameObject;
                        Collider[] hitColliders = Physics.OverlapSphere(activeObjOutline.transform.position, 5.0f);
                        foreach(var hitCollider in hitColliders)
                            if(hitCollider.transform.gameObject != activeObjOutline && hitCollider.transform.gameObject.GetComponent<Outline>())
                                hitCollider.transform.gameObject.GetComponent<Outline>().enabled = false;
                        var outline = hit.transform.gameObject.GetComponent<Outline>();
                        outline.enabled = true;
                        outline.OutlineMode = Outline.Mode.OutlineAll;
                        outline.OutlineColor = Color.green;
                        outline.OutlineWidth = 3f;
                        if(Input.GetMouseButtonDown(0))
                        {
                                PickupObject(hit.transform.gameObject);
                                Debug.Log(hit.transform.gameObject.name);
                        }
                    }
                   
                }
                else
                {
                    if(activeObjOutline)
                    activeObjOutline.GetComponent<Outline>().enabled = false;
                    activeObjOutline = null;
                }
            }
           
        

         if(heldObj != null)
            {     
                MoveObject();
            }

        if(heldObj != null && Input.GetMouseButtonDown(1))
            {
                DropObject();
            }
       
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }
    

    void PickupObject(GameObject pickObj)  
    {
        if(pickObj.GetComponent<Rigidbody>())
        {
            
            heldObj = pickObj;
            var outline = heldObj.transform.gameObject.GetComponent<Outline>();
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.black;
            outline.OutlineWidth = 3f;
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void DropObject()  
    {
            var outline = heldObj.GetComponent<Outline>();
            outline.enabled = false;

          
            heldObjRB.useGravity = true;
            heldObjRB.drag = 1;
            heldObjRB.constraints = RigidbodyConstraints.None;
            if(heldObj.GetComponent<ParentForDrop>())
            heldObj.transform.parent = heldObj.GetComponent<ParentForDrop>().parentObj.transform;
            else heldObj.transform.parent = null;
            heldObj = null;
            Debug.Log("idk");
        
    }

    

    
}
