using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource src;
    public AudioClip sfx1, sfx2;

    public float cooldown = 1.5f;
    public int health = 3;
    public int Dcount = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tower")
        {
            StartCoroutine(Damage());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tower")
        {
            Dcount = 0;
        }
    }

    private IEnumerator Damage()
    {
        Dcount = 1;
        while (Dcount == 1)
        {
            src.clip = sfx1;
            src.Play();
            health--;
            yield return new WaitForSeconds(cooldown);
        } 
    }

    private void Update()
    {
        if (health == 0)
        {
            src.clip = sfx2;
            src.Play();
            enemy.SetActive(false);
        }
    }

}
