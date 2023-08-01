using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public Transform[] spawnPoints;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        foreach (var sp in spawnPoints)
        {
            Instantiate(enemyToSpawn, sp.position, sp.rotation);
        }
    }
}
