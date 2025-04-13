using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMultiplu : Interactable
{
   public Fan fanObject;
   public Fan fanObject2;
   override protected void Interact()
   {
      if(fanObject.onOrOff)
      {
        fanObject.onOrOff = false;
        fanObject2.onOrOff = false;
      }
       
        else
        {
         fanObject.onOrOff = true;
         fanObject2.onOrOff = true;
        }
   }
    
}
