using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerControllerSingle : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;

    public float cooldown = 1.5f;
    public int damage = 1;
    private List<GameObject> enemies = new List<GameObject>();
    private int inProcess = 0;

    public float min = 0;

    private GameObject target;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            StartCoroutine(Targeter());
            Debug.Log(enemies.Count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }

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
                    if (enemy.GetComponent<EnemyController>().timer > min) {
                        min = enemy.GetComponent<EnemyController>().timer;
                        target = enemy;
                    }
                }
                target.GetComponent<EnemyController>().Damage(damage);
                min = 0;
                yield return new WaitForSeconds(cooldown);
            }
            inProcess = 0;
        }
    }
    private void Update()
    {
        foreach(GameObject enemy in enemies.ToList()) {
            if (enemy.GetComponent<EnemyController>().health <= 0)
            {
                enemies.Remove(enemy);
            }
        }
    }
}



