using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition(){
        float xRand = Random.Range(-spawnRange, spawnRange);
        float zRand = Random.Range(-spawnRange, spawnRange);

        return new(xRand, 0.12F, zRand);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
