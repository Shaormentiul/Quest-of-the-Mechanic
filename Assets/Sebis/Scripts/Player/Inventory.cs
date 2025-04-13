using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject selectedObject;
    public bool[] blueprint;

    public GameObject blueprint1;
    public GameObject blueprint2;
    public GameObject lacat1;
    public GameObject lacat2;
    public Material material1;
    public Material matAer;
    public Transform ChestiiAer;
    public Transform ChestiiApa;
    public Material material2;

    void Update()
    {
        if(blueprint1)
        {
            if(blueprint[0])
            {
                blueprint1.GetComponent<MeshRenderer>().material = matAer;
                lacat1.SetActive(false);
                foreach(Transform child in ChestiiAer)
                {
                    child.gameObject.GetComponent<MeshRenderer>().material = material2;
                }
            }

               
             if(blueprint[1])
             {
                lacat2.SetActive(false);
                blueprint2.GetComponent<MeshRenderer>().material = material1;
                foreach(Transform child in ChestiiApa)
                {
                    child.gameObject.GetComponent<MeshRenderer>().material = material2;
                }
             }
               
        }
            
    }



}
