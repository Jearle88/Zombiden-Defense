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
    // [SerializeField]
    // GameObject PrefabToInstantiate; Moved to Waves
    public TextMeshProUGUI timerGUI;

    public Wave[] waves;
    [NonSerialized] public int currentWaveIndex = 0;

    private bool readyToCountDown;
    private void Start()
    {
        // Sets the basis of things that were not already made initialized or ensuring nothing goes wrong
        currentWaveIndex = 0;
        src.clip = sfx1;
        src.Play();
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            Debug.Log("AHHHHH");
            waves[i].enemiesLeft = waves[i].numEnemies;
            Debug.Log(waves[i].enemiesLeft);
        }
    }
    private void Update()
    {
        Debug.Log(currentWaveIndex); 
        // checks if we have completed every round
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("You survived every wave!");
            // timerGUI.text = "You Win!"; was a temporary win screen before we had a win scene
            SceneManager.LoadScene("Win");
        }
        // variable to know when to start counting down for the next wave
        if (readyToCountDown)
        {
            timerGUI.text = "Time To Next Wave: " + countdown.ToString();
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
        }
        // checks to start wave spawning
        if (countdown <= 0)
        {
            // Debug.Log("COUNTDOWN");
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
            Debug.Log("COUNTDOWN");
        }
        // checks to make sure the waveIndex did not magically increase to above waves.Length (mostly stops errors)
        if (currentWaveIndex < waves.Length)
        {
            // checks if there are no more enemies left, stops coroutines (spawning), increments the wave index, and if it is still less than waves.Length, we get ready to countdown
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
        // checks if we are not ready to countdown so we can show wave information
        if (!readyToCountDown)
        {
            timerGUI.text = "Waves: " + (currentWaveIndex + 1).ToString() + "/" + waves.Length + "\nEnemy Count: " + waves[currentWaveIndex].enemiesLeft.ToString() + "/" + waves[currentWaveIndex].numEnemies.ToString();
        }
    }
    private IEnumerator SpawnWave()
    {
        // basically a triple check for the amount of waves being correct
        if (currentWaveIndex < waves.Length)
        {
           Debug.Log("wave index"+ currentWaveIndex);
            // spawns the amount of enemies that we need
            for (int i = 0; i < waves[currentWaveIndex].numEnemies; i++)
            {
                Debug.Log("WAVVVESSS");
                CreateObject(spawnPoint.transform.position, waves[currentWaveIndex].extraHealth, waves[currentWaveIndex].extraSpeed, waves[currentWaveIndex].PrefabToInstantiate);
                // Old implementation of spawning enemies (not using createobject)
                // Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);
                //waves[currentWaveIndex].enemiesLeft--;
                // enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }
    }

    public void CreateObject(Vector3 position, int addHealth, float addSpeed, GameObject PrefabToInstantiate)
    {
        // Slightly modified drag and drop createobject function
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

[Serializable]

// class for wave information
public class Wave
{
    public int numEnemies;
    public int extraHealth = 0;
    public float extraSpeed = 0.0f;
    public float timeToNextEnemy;
    public float timeToNextWave;
    public GameObject PrefabToInstantiate;

    [HideInInspector] public int enemiesLeft;
}