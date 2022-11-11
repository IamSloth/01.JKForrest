using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public GameObject resume;

    public void Re()
    {
        if (Pause.isPaused == true)
        {
            SceneManager.LoadScene(1);
            resume.GetComponent<Resume>().OnClickResume();
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
