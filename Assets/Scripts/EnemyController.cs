using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   // public GameObject enemy;
    public float health = 5;
    public float MoneyDealt = 10;
    public float timer;

    // damage function so towers can do damage to enemies
    public void Damage(int damage)
    {
        health -= damage;
    }   

    private void Update()
    {
        // checks if the enemy should die
        if (health <= 0)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<playerdata>().currMoney += MoneyDealt;
            GameObject spawner = GameObject.Find("Ground");
            int currentWaveIndex = spawner.GetComponent<WaveSpawner>().currentWaveIndex;
            spawner.GetComponent<WaveSpawner>().waves[currentWaveIndex].enemiesLeft -= 1;
            gameObject.SetActive(false);
        }
        // information for single target towers to know what the oldest (and presumably farthest enemy is)
        timer += Time.deltaTime;
    }

}
