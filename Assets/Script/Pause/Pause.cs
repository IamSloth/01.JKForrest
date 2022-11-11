using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject resumeMenu;

    public static bool isPaused;

    public void OnClickPause()
    {
        pauseMenu.gameObject.SetActive(true);
        Debug.Log("PAUSE");
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResultPause()
    {
        pauseMenu.gameObject.SetActive(true);
        resumeMenu.gameObject.SetActive(false);
        Debug.Log("ResultPAUSE");
        isPaused = true;
        Time.timeScale = 0f;
    }


    // Start is called before the first frame update
    void Start()
    {
        //pause = GameObject.Find("PauseMenu");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
