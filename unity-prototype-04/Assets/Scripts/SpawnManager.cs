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
        float xRand = Random.Range(-spawnRange, spawnRange);
        float zRand = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new(xRand, 0.12F, zRand);

        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
