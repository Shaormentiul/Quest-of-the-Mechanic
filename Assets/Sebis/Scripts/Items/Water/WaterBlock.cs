using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBlock : MonoBehaviour
{
    public float fillAmmount;
    public float fillPercent;
    public float maxFill;
    public float capacity;
    public float maxCapacity;
    public bool capacityBased;

    // Update is called once per frame
    void Update()
    {
        if(capacityBased)
        fillPercent = capacity / maxCapacity  * 100f;
       
        fillAmmount = -maxFill +  2f * maxFill * fillPercent / 100f;
        
        gameObject.GetComponent<Renderer>().material.SetFloat("_Fill", fillAmmount);
    }
}
