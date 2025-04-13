using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityPuzzleSource : MonoBehaviour
{
    public CapacityPuzzleTarget CPT;
    public WaterBlock water;

    void OnTriggerEnter(Collider col)
    {
        water = col.gameObject.GetComponent<WaterBlock>();
    }

    void OnTriggerExit(Collider col)
    {
        water = null;
    }

    public void Transmit()
    {
        if(water != null && CPT.isObjectOn)
        {
            Debug.Log("SSSSS");
            if(CPT.targetCapacity != CPT.targetCapacityMax && water.capacity != 0)
            {
                Debug.Log("BBBBBB");
                if(CPT.targetCapacityMax - CPT.targetCapacity >= water.capacity)
                {
                    CPT.targetCapacity += water.capacity;
                    water.capacity = 0;
                    Debug.Log("More");
                }
            
                else if(CPT.targetCapacityMax - CPT.targetCapacity <= water.capacity)
                {
                    Debug.Log("Less");
                    water.capacity -= CPT.targetCapacityMax - CPT.targetCapacity;
                    CPT.targetCapacity += CPT.targetCapacityMax - CPT.targetCapacity;
                    
                }
            }
           
            
        }
    }
}
