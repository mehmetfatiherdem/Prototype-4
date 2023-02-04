using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerup;

    float spawnRange = 7f;

    int enemyCount;

    int wave = 1;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerup, GenerateSpawnPos(), powerup.transform.rotation);
        SpawnEnemyWave(wave);
        
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            Instantiate(powerup, GenerateSpawnPos(), powerup.transform.rotation);
            SpawnEnemyWave(++wave);
        }    
    }

    void SpawnEnemyWave(int wave)
    {
        for (int i = 0; i<wave; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPos()
    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);

        return new Vector3(x, 0, z);
    }
}
