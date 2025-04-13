using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{
    public GameObject pointY;
    void OnTriggerStay(Collider col)
    {
         if(col.gameObject.layer == 7)
            col.gameObject.GetComponent<Rigidbody>().AddForce(0, 0.15f * (pointY.transform.position.y - col.transform.position.y), 0, ForceMode.Impulse);
            Debug.Log( 0.15f * (pointY.transform.position.y - col.transform.position.y));
    }
       
    


   
}
