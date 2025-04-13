using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnable;
    public Transform spawnPoint;


    public void Spawn()
    {
        Debug.Log("lol");
        GameObject instantiated = Instantiate(spawnable, spawnPoint.position, spawnPoint.rotation);
        instantiated.GetComponent<WhereToSpawn>().spawner = gameObject.GetComponent<Spawner>();
    }
}
