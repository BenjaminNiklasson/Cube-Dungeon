using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    List<List<int>> waves = new List<List<int>>();
    [SerializeField] GameObject jeff;
    [SerializeField] GameObject swarmer;
    [SerializeField] GameObject shooter;
    [SerializeField] GameObject sewerslider;
    [SerializeField] List<int> wave1 = new List<int>();
    [SerializeField] List<int> wave2 = new List<int>();
    [SerializeField] List<int> wave3 = new List<int>();
    [SerializeField] float spawnCooldown = 1f;
    int activeWave;
    bool startedSpawning = false;
    int enemiesLeft;
    void Start()
    {
        waves.Add(wave1);
        waves.Add(wave2);
        waves.Add(wave3);
        activeWave = Random.Range(0, waves.Count);
        for (int i = 0; i < waves[activeWave].Count; i++)
        {
            enemiesLeft = enemiesLeft + waves[activeWave][i];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && startedSpawning == false)
        {
            startedSpawning = true;
            Invoke("Spawn", spawnCooldown);
        }
    }
    void Spawn()
    {
        int enemyToSpawn = 0;
        int enemyType = 0;
        Transform spawnPoint = transform.GetChild(Random.Range(0, transform.childCount));
        while (enemyToSpawn == 0)
        {
            enemyType = Random.Range(0, 3);
            enemyToSpawn = waves[activeWave][enemyType];
        }
        GameObject spawnedEnemy = null;
        switch (enemyType)
        {
            case 0:
                spawnedEnemy = Instantiate(swarmer, spawnPoint);
                waves[activeWave][enemyType]--;
                break;
            case 1:
                spawnedEnemy = Instantiate(sewerslider, spawnPoint);
                waves[activeWave][enemyType]--;
                break;
            case 2:
                spawnedEnemy = Instantiate(shooter, spawnPoint);
                waves[activeWave][enemyType]--;
                break;
            case 3:
                spawnedEnemy = Instantiate(jeff, spawnPoint);
                waves[activeWave][enemyType]--;
                break;
        }
        enemiesLeft--;
        if (enemiesLeft != 0)
        {
            Invoke("Spawn", spawnCooldown);
        }
        else if (enemiesLeft == 0)
        {
            spawnedEnemy.GetComponent<ChestSpawn>().iSpawnTheChest = true;
        }
    }
}