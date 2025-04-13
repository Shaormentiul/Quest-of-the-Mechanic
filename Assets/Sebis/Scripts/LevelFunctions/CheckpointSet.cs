using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSet : MonoBehaviour
{
    public CheckPointReset checker;
    [SerializeField] string playerTag = "Player";
    public GameObject activeLevel;
    public int levelIndex;

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag.Equals(playerTag))
        {
            checker.respawnPoint = gameObject.transform;
            if(activeLevel)
            checker.currentLevel = activeLevel;
            else activeLevel = checker.currentLevel;
            checker.prefab = checker.levelPrefabs[levelIndex];
            checker.PREFABBOSS = checker.levelPrefabs[levelIndex];

        }
    }
}
