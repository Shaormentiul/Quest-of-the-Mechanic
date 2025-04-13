using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dbg : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.transform.rotation.eulerAngles);
    }
}
