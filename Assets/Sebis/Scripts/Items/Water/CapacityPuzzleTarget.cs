using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapacityPuzzleTarget : MonoBehaviour
{
    public float targetCapacity;
    public float targetCapacityMax;
    public bool isObjectOn;
    public WaterBlock water;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<WaterBlock>())
        {
            water = col.gameObject.GetComponent<WaterBlock>();
            isObjectOn = true;
            targetCapacity = water.capacity;
            targetCapacityMax = water.maxCapacity;
        }
    }

    void Update()
    {
        if(water != null)
        {
            water.capacity = targetCapacity;
            water.maxCapacity = targetCapacityMax;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.GetComponent<WaterBlock>())
        {
            water = null;
            isObjectOn = false;
            targetCapacity = 0;
            targetCapacityMax = 0;
        }
    }
}
