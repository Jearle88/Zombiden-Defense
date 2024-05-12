using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private AudioSource src;
    public AudioClip sfx1;

    public float cooldown = 1.5f;
    public int damage = 1;
    private int Dcount;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            src = other.GetComponent<AudioSource>();
            StartCoroutine(Targeter(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Dcount = 0;
        }
    }

    private IEnumerator Targeter(GameObject other)
    {
        Dcount = 1;
        while (Dcount == 1 && (other.GetComponent<EnemyController>().health != 0))
        {
            src.clip = sfx1;
            src.Play();
            other.GetComponent<EnemyController>().Damage(damage);
            yield return new WaitForSeconds(cooldown);
        }
        Dcount = 0;
    }

}

