
using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private float countdown = 5f;

    private WaveSpawner waveSpawner;

    // this was a test script used for testing wavespawning
    private void Start()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
    }
    public void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Debug.Log("DESTROY");
            Destroy(gameObject);

            waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
        }
    }
}
