using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttachPlatform : MonoBehaviour
{
   public Inventory playerInventory;
   public GameObject attachedItemSlot1;
   public GameObject attachedItemSlot2;

    public void AttachSlot1()
    {
        attachedItemSlot1 = Instantiate(playerInventory.selectedObject, transform.position, transform.rotation, gameObject.transform);
        gameObject.GetComponent<SphereCollider>().enabled = false;
        
    }
   
}
