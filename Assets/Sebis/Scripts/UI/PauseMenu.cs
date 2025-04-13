using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;
    public GameObject pauseMenuUI;
    public GameObject crossHair;
    void Start()
    {

        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           
             
            if(Paused)
            {
              Resume();  
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        crossHair.SetActive(true);
        Time.timeScale = 1f;
        Paused = false;   
        Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false; 
    }

    public void Pause()
    {
        crossHair.SetActive(false);
            pauseMenuUI.SetActive(true);
            Time.timeScale = 1f;
            //FindObjectOfType<AudioManager>().Play("Menu");
            Paused = true;
            
            Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
