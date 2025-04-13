using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] string spawnableTag;
    [SerializeField] string pickUpAbleTag;
    public CheckPointReset check;
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag.Equals(playerTag))
        {
            check.Death(col.gameObject);
        }
       
        if(col.gameObject.tag == spawnableTag)
        {
            Destroy(col.gameObject);
            col.gameObject.GetComponent<WhereToSpawn>().spawner.Spawn();
            
        }
        if(col.gameObject.tag == pickUpAbleTag)
        {
            col.gameObject.transform.position = col.gameObject.GetComponent<PickUpRespawn>().initialPos;
            col.gameObject.transform.rotation = col.gameObject.GetComponent<PickUpRespawn>().initialRot;
            col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
        }
    }

    
}
