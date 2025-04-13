using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
   public Fan fanObject;
   override protected void Interact()
   {
      if(fanObject.onOrOff)
        fanObject.onOrOff = false;
        else
        {
         fanObject.onOrOff = true;
        }
   }
    
}
