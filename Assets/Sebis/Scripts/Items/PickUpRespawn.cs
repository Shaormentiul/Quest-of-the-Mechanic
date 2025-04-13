using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRespawn : MonoBehaviour
{
   
    public Vector3 initialPos;
    public Quaternion initialRot;
    void Start()
    {
        initialPos = gameObject.transform.position;
        initialRot = gameObject.transform.rotation;
    }

}
