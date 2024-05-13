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
    private int inRange;
    private List<GameObject> enemies = new List<GameObject>();
    private int inProcess = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
            StartCoroutine(Targeter());
            Debug.Log(inRange);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (inRange > 0)
            {
                inRange--;
            }
            enemies.Remove(other.gameObject);
        }
    }

    private IEnumerator Targeter()
    {
        inRange++;
        if (inProcess == 0)
        {
            inProcess = 1;
            while (inRange > 0)
            {
                src.clip = sfx1;
                src.Play();
                foreach (GameObject enemy in enemies)
                {
                    if (enemy.GetComponent<EnemyController>().health <= 0)
                    {
                        if (inRange > 0)
                        {
                            inRange--;
                        }
                    }
                    else
                        enemy.GetComponent<EnemyController>().Damage(damage);
                }
                yield return new WaitForSeconds(cooldown);
            }
            inProcess = 0;
        }
    }
}

