using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    public bool isObjectInHand;
    public string nameOfObject;
    public GameObject objectInHand;

    



    public void GetInHand(GameObject item, GameObject newparent, GameObject shadowItem)
    {
        objectInHand = item;
        item.transform.SetParent(newparent.transform);
        item.transform.position = newparent.transform.position;
        shadowItem.SetActive(true);
        Debug.Log("lol");
    }

    public void DropFromHand(GameObject shadowItem)
    {
        objectInHand.transform.SetParent(null);
        objectInHand.transform.position = shadowItem.transform.position;
        shadowItem.SetActive(false);
    }
    
    
}
