using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{

    GameObject player;
    float time;
    bool bInRange;
    bool isTrigger;
    public AudioClip attackSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            bInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            bInRange= false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        isTrigger = false;
    }

    int attackStep = 0;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(isTrigger == false)
        {
            if (bInRange == true && attackStep == 0 && time >= 0.5f)
            {
                time = 0;
                GetComponent<Animator>().SetBool("Attack", true);
                attackStep++;
            }

            else if (bInRange == true && attackStep == 1 && time >= 0.45f)
            {
                time = 0;
                GetComponent<AudioSource>().PlayOneShot(attackSound);
                player.GetComponent<PlayerHealth>().Damage(30);
                attackStep++;
            }

            else if (bInRange == true && attackStep == 2 && time >= 1.0f)
            {
                time = 0;
                GetComponent<Animator>().SetBool("Attack", false);
                attackStep = 0;
            }

            else if (bInRange == false && time >= 1.0f)
            {
                time = 0;
                GetComponent<Animator>().SetBool("Attack", false);
                attackStep = 0;
            }
        }

        if (player.GetComponent<PlayerHealth>().hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("PlayerDeath");
            isTrigger = true;
            GetComponent<NavMeshAgent>().isStopped = true;
        }

        else
        {
            if(isTrigger == true)
            {
                GetComponent<Animator>().SetTrigger("PlayerRespawn");
                isTrigger= false;
            }
            if(GetComponent<EnemyHealth>().hp > 0)
            {
                GetComponent<NavMeshAgent>().isStopped = false;
            }
            
        }
    }
}
