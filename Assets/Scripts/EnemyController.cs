using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public float health = 5;
    public float MoneyDealt = 10;
    public float timer;

    public void Damage(int damage)
    {
        health -= damage;
    }   

    private void Update()
    {
        if (health <= 0)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<playerdata>().currMoney += MoneyDealt;
            GameObject spawner = GameObject.Find("Ground");
            int currentWaveIndex = spawner.GetComponent<WaveSpawner>().currentWaveIndex;
            spawner.GetComponent<WaveSpawner>().waves[currentWaveIndex].enemiesLeft -= 1;
            enemy.SetActive(false);
        }
        timer += Time.deltaTime;
    }

}
