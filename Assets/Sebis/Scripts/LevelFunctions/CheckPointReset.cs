using System.Collections;
using UnityEngine;

public class CheckPointReset : MonoBehaviour
{
    public GameObject prefab;
    public GameObject currentLevel;
    public Animator transition;
    public Transform respawnPoint;
    public GameObject PREFABBOSS;
    public GameObject[] levelPrefabs;
    private bool ok = true;

    public void Death(GameObject player)
    {
        if (ok)
            StartCoroutine(Respawn(player));
    }

    IEnumerator Respawn(GameObject player)
    {
        ok = false;
        Debug.Log("Player Died");

        transition.SetTrigger("Revive");
        yield return new WaitForSeconds(1);

        player.transform.position = respawnPoint.position;
        ResetLevel();

        ok = true;
    }

    void ResetLevel()
    {
        Debug.Log("Resetting Level");

        // Assign prefab to be the correct template
        prefab = PREFABBOSS;

        // Instantiate a new level and store the reference
        GameObject newLevel = Instantiate(prefab, currentLevel.transform.position, currentLevel.transform.rotation);

        // Destroy the old level
        Destroy(currentLevel);

        // Update currentLevel to the new instance
        currentLevel = newLevel;
    }
}
