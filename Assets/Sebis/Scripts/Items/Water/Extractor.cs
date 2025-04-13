using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
    public FillerButton phil;
    

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<WaterBlock>())
        {
            phil.fillGraphValue += col.gameObject.GetComponent<WaterBlock>().fillPercent ;
            col.gameObject.GetComponent<WaterBlock>().fillPercent = -col.gameObject.GetComponent<WaterBlock>().maxFill;

        }
    }
}
