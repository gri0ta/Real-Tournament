using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent onWaveStarted;
    public UnityEvent onWaveEnded;


    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;
    public List<int> enemyCounts;

    [Range(0.1f,5)]public float spawnInterval = 1f;
    [Range(0.1f,10)]public float waveInterval = 10f;
    public int enemiesLeft;
    

    async void Start()
    {
        Random.seed = 0;
        foreach (var count in enemyCounts)//waves
        {
            onWaveStarted.Invoke();
            enemiesLeft = count;
            while (enemiesLeft > 0)//spawninasi enemies
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesLeft--;
            }
            onWaveEnded.Invoke();
        }
    }

    public void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    
}
