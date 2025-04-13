using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : Interactable
{
    public GameObject item;
    public Inventory inv;
   protected override void Interact()
   {
        inv.selectedObject = item;

   }
}
