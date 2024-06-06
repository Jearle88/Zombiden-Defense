using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;

    public float cooldown = 1.5f;
    public int damage = 1;
    private List<GameObject> enemies = new List<GameObject>();
    private int inProcess = 0;

    [System.NonSerialized] public GameObject player;
    public Behaviour halo;

    // adds enemies to our enemy list when they get within range
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            StartCoroutine(Targeter());
            Debug.Log(enemies.Count);
        }
    }

    // removes enemies for our list
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }

    // Targeter to damage all targets within range
    private IEnumerator Targeter()
    {
        if (inProcess == 0)
        {
            inProcess = 1;
            while (enemies.Count > 0)
            {
                src.clip = sfx1;
                src.Play();
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyController>().Damage(damage);
                }
                yield return new WaitForSeconds(cooldown);
            }
            inProcess = 0;
        }
    }
    
    // checks if the halo toggle is on or off
    private void Start()
    {
        player = GameObject.Find("Player");
        halo.enabled = player.GetComponent<playerdata>().halo_on;
        Debug.Log(player.GetComponent<playerdata>().halo_on.ToString());
    }

    private void Update()
    {
        // check if we have pressed h and if the halo should be enabled (probably could do this in player data and just have the halo always update, but this works fine)
        if (Input.GetKeyDown("h"))
        {
            if (halo.enabled == true)
            {
                player.GetComponent<playerdata>().halo_on = false;
                halo.enabled = player.GetComponent<playerdata>().halo_on;
            }
            else
            {
                player.GetComponent<playerdata>().halo_on = true;
                halo.enabled = player.GetComponent<playerdata>().halo_on;
            }
        }
        // Looks if any enemy is dead and should be removed from the list
        foreach (GameObject enemy in enemies.ToList()) {
            if (enemy.GetComponent<EnemyController>().health <= 0)
            {
                enemies.Remove(enemy);
            }
        }
    }
}


