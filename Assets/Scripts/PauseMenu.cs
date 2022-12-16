using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public KeyCode testingKey;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
      

    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
    {
        //Will only open
        //menu.SetActive(true);
        isPaused = !isPaused;


        //Will open menu if closed, closes menu if open
        // menu.SetActive(!menu.activeInHierarchy);
        menu.SetActive(isPaused);


        if (isPaused)
        {
            Time.timeScale = 0f;
            //GameManager.Instance.audio.pitch = 0f;
            
        }
        else
        {
            Time.timeScale = 1f;
            //GameManager.Instance.audio.pitch = 1f;
           
        }
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
}