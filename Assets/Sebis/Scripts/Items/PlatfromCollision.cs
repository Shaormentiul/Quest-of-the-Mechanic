using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromCollision : MonoBehaviour
{

    [SerializeField] Transform platform;
    public bool isOnPlatform;

    private void OnTriggerStay(Collider other)
    {
    
        if(other.gameObject.layer == 8 || other.gameObject.layer == 3)
        {
                other.gameObject.transform.parent = platform;
            isOnPlatform = true;
        }
            
            
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        
            other.gameObject.transform.parent = null;
            isOnPlatform = false;
            
        
        
    }

}
