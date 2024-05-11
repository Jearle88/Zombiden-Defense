using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource src;
    public AudioClip sfx1, sfx2;

    public float cooldown = 1.5f;
    public int Dcount = 0;
    public int damage = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            StartCoroutine(Targeter());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cube")
        {
            Dcount = 0;
        }
    }

    private IEnumerator Targeter()
    {
        Dcount = 1;
        while (Dcount == 1)
        {
            src.clip = sfx1;
            src.Play();
            enemy.GetComponent<EnemyController>().Damage(damage);
            yield return new WaitForSeconds(cooldown);
        } 
    }

}

