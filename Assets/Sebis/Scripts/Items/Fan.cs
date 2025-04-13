using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Interactable
{
    public GameObject gust;
    public bool onOrOff;


    void Update()
    {
        if(onOrOff)
        gust.SetActive(true);
        else gust.SetActive(false);
    }



    protected override void Interact()
    {
       
        if(onOrOff)
        {
            onOrOff = false;
            
        }
        
        else onOrOff = true;
    }
}
