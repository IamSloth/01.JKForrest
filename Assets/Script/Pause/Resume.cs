using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject pauseMenu;

    public void OnClickResume()
    {
        pauseMenu.SetActive(false);        
        Pause.isPaused = false;
        Time.timeScale = 1f;
        Debug.Log("Resuem");
        Debug.Log("isPaused =" + Pause.isPaused);
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
