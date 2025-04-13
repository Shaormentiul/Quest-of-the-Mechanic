using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromAttachBall : Interactable
{
   public AttachObjectsToThis at;
   public int slotNr;

   protected override void Interact()
   {
      at.AttachSlot(slotNr);
      gameObject.GetComponent<SphereCollider>().enabled = false;

   }
   

}
