using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    public bool onOrOff;
    public Animator leverAnim;
    public Door door;

    
    protected override void Interact()
    {




        if(onOrOff)
        {
            door.Open();
            leverAnim.Play("leverAnimation1");
            onOrOff = false;
            
        }
        else
        {
            door.Close();
            leverAnim.Play("leverAnimation2");
            onOrOff = true;
        }
    }
   


}
  