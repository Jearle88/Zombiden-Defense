using UnityEngine;
using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class WaveSpawner : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    [SerializeField] private float countdown;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField]
    GameObject PrefabToInstantiate;
    public TextMeshProUGUI timerGUI;

    public Wave[] waves;
    public int currentWaveIndex = 0;

    private bool readyToCountDown;
    private void Start()
    {
        currentWaveIndex = 0;
        src.clip = sfx1;
        src.Play();
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            Debug.Log("AHHHHH");
            waves[i].enemiesLeft = waves[i].numEnemies;
        }
    }
    private void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("You survived every wave!");
            timerGUI.text = "You Win!";
            GameObject player = GameObject.Find("Player");
            player.GetComponent<playerdata>().EndLevel();
        }

        if (readyToCountDown)
        {
            timerGUI.text = "Time To Next Wave: " + countdown.ToString();
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
        }

        if (countdown <= 0)
        {
            // Debug.Log("COUNTDOWN");
            timerGUI.text = "Waves: " + (currentWaveIndex+1).ToString() + "/" + waves.Length;
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
            Debug.Log("COUNTDOWN");
        }
        if (currentWaveIndex < waves.Length)
        {
            if (waves[currentWaveIndex].enemiesLeft <= 0) // Add the condition here
            {
                StopAllCoroutines();
                currentWaveIndex++;
                if (currentWaveIndex < waves.Length)
                {
                    readyToCountDown = true;
                }
            }
        }
    }
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
           Debug.Log("wave index"+ currentWaveIndex);
            for (int i = 0; i < waves[currentWaveIndex].numEnemies; i++)
            {
                Debug.Log("WAVVVESSS");
                CreateObject(spawnPoint.transform.position, waves[currentWaveIndex].extraHealth, waves[currentWaveIndex].extraSpeed);
                // Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);
                //waves[currentWaveIndex].enemiesLeft--;
                // enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }

    public void CreateObject(Vector3 position, int addHealth, float addSpeed)
    {
        if (PrefabToInstantiate == null)
        {
            Debug.Log("No prefab to instantiate");
            return;
        }
        GameObject obj = Instantiate(
        PrefabToInstantiate,
        position,
        Quaternion.identity);
        obj.GetComponent<EnemyController>().health += addHealth;
        obj.GetComponent<NavMeshAgent>().speed += addSpeed;
        Debug.Log(obj.transform.position);
    }
}

[System.Serializable]
public class Wave
{
    public int numEnemies;
    public int extraHealth = 0;
    public float extraSpeed = 0.0f;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}