using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachObjectsToThis : MonoBehaviour
{
    public Inventory playerInventory;
    public GameObject attachedItemSlot;
    public GameObject attachedItem;
    public bool isAttached;
    public FanPlatform fanP;
   

    public void AttachSlot(int n)
    {
        attachedItem = Instantiate(playerInventory.selectedObject, attachedItemSlot.transform.position, attachedItemSlot.transform.rotation, attachedItemSlot.transform);
        fanP.fanObject = attachedItem;  
        isAttached = true;
        
    }
}
