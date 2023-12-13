using UnityEngine;
using System.Collections;
using Interfaces;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;
    public int currentWaveIndex = 0;

    // private bool IsCountBetweenEnemies;
    public bool IsCountBetweenWaves;
    
    private void Start()
    {
        IsCountBetweenWaves = true;
    }
    private void Update()
    {
        if (currentWaveIndex == waves.Length)
            currentWaveIndex = 0;
        
        if (IsCountBetweenWaves)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            IsCountBetweenWaves = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

    }
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                EnemyAbstract enemy = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);

                enemy.transform.SetParent(spawnPoint.transform);

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
        }

        IsCountBetweenWaves = true;
        currentWaveIndex++;
    }
}

[System.Serializable]
public class Wave
{
    public EnemyAbstract[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;
}