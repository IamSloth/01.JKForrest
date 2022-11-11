using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public AudioClip healClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            GetComponent<AudioSource>().PlayOneShot(healClip);
            GetComponent<PlayerHealth>().Healing(100);
            Destroy(other.gameObject);

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
