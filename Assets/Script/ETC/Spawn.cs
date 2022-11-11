using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawn : MonoBehaviour
{

    public GameObject[] prefab;
    public float time;
    public Transform[] point;

    public GameObject pause;

    public int max;
    public int count;

    public int killCount;

    public AudioClip kill1;
    public AudioClip kill2;
    public AudioClip kill3;
    public AudioClip kill4;
    public AudioClip kill5;
    public AudioClip kill6;
    public AudioSource audioSource;

    public TextMeshProUGUI resultText;
    public TextMeshProUGUI lifeText;
    GameObject player;

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    void Create()
    {
        if (killCount == max && count == max)
        {
            Instantiate(prefab[2], point[1]);
            count = count + max + 1;
            return;
        }

        if (count >= max)
        {
            return;
        }

        count++;
        int i = Random.Range(0, point.Length - 1);
        int j = Random.Range(0, prefab.Length - 1);
        Instantiate(prefab[j], point[i]);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Create", time, time);
        player = GameObject.Find("Player");
        pause = GameObject.Find("PauseButton");
    }

    // Update is called once per frame
    float timer = 0;
    bool bTimeDelay = false;
    void Update()
    {

        timer += Time.deltaTime;
        if (killCount == 6 && bTimeDelay == false)
        {
            timer = 0;
            bTimeDelay = true;
            resultText.gameObject.SetActive(true);
            resultText.text = "VICTORY...!";
        }

        else if (killCount == 6 && bTimeDelay == true && timer > 2)
        {
            if (Pause.isPaused == false)
            {
                pause.GetComponent<Pause>().ResultPause();
                killCount = 0;
                bTimeDelay = false;
            }
        }

        if (player.GetComponent<PlayerHealth>().life < 0 && bTimeDelay == false)
        {
            timer = 0;
            resultText.gameObject.SetActive(true);
            lifeText.text = "LIFE : 0";
            resultText.text = "YOU LOSE...";
            bTimeDelay = true;
        }

        else if (player.GetComponent<PlayerHealth>().life < 0 && bTimeDelay == true && timer >= 2f)
        {
            if (Pause.isPaused == false)
            {
                pause.GetComponent<Pause>().ResultPause();
                player.GetComponent<PlayerHealth>().life = 0;
            }
            bTimeDelay = false;
        }
    }
}
