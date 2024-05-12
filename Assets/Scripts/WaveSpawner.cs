using UnityEngine;
using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using System;
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;
    public int currentWaveIndex = 0;

    private bool readyToCountDown;
    private void Start()
    {
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            Debug.Log("AHHHHH");
            waves[i].enemiesLeft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {
        if (currentWaveIndex >= waves.Length)
    {
        Debug.Log("You survived every wave!");
        return;
    }

    if (readyToCountDown)
    {
        countdown -= Time.deltaTime;
    }

    if (countdown <= 0)
    {
       // Debug.Log("COUNTDOWN");
        readyToCountDown = false;

        countdown = waves[currentWaveIndex].timeToNextWave;

        StartCoroutine(SpawnWave());
         Debug.Log("COUNTDOWN");
    }

    if (waves[currentWaveIndex].enemiesLeft == 0) // Add the condition here
    {
        readyToCountDown = true;

        currentWaveIndex++;
    }
    }
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
           Debug.Log("wave index"+ currentWaveIndex);
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                Debug.Log("WAVVVESSS");
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);
                //waves[currentWaveIndex].enemiesLeft--;
                enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }
}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}