using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeCount : MonoBehaviour
{
    TextMeshProUGUI lifeScore;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        lifeScore = GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealth>().life >= 0)
        {
            lifeScore.text = "LIFE : " + player.GetComponent<PlayerHealth>().life;
        }

    }
}
