using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{   

   public int layer;
    public Door door;


    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == layer)
            door.Open();
    }

   
}
