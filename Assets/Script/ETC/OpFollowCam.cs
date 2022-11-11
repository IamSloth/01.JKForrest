using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpFollowCam : MonoBehaviour
{
    Transform n;

    // Start is called before the first frame update
    void Start()
    {
        n = GameObject.Find("Nsheep").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = n.position + new Vector3(0, 4, -12);

        if(Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }
    }
}
