using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  TMPro;

public class SceneSelect : MonoBehaviour
{
    public int selectedSceneIndex;
    public Animator transition;
    public GameObject bila;

    void OnTriggerStay()
    {
        Debug.Log("lol");
        bila.SetActive(true);
        if(Input.GetKey(KeyCode.E))
        {
            
            if(selectedSceneIndex != 0)
            StartCoroutine(LoadLevel(selectedSceneIndex));
            
        }
    }

    void OnTriggerExit()
    {
       bila.SetActive(false);
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);


    }
}
