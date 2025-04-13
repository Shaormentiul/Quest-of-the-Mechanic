using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrint : Interactable
{
    public GameObject portal;
    public Inventory inv;
    public int index;



    protected override void Interact()
    {
        inv.blueprint[index] = true;
        portal.SetActive(true);
        this.gameObject.SetActive(false);
    }   
}
