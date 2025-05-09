using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    List<List<int>> waves = new List<List<int>>();
    [SerializeField] List<int> wave1 = new List<int>();
    [SerializeField] List<int> wave2 = new List<int>();
    [SerializeField] List<int> wave3 = new List<int>();
    [SerializeField] float spawnCooldown = 1f;
    [SerializeField] GameObject swarmer;
    [SerializeField] GameObject shooter;
    [SerializeField] GameObject sewerslider;
    [SerializeField] GameObject jeff;
    List<int> activeWave;
    bool spawnStarted = false;
    bool enemiesLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        waves.Add(wave1);
        waves.Add(wave2);
        waves.Add(wave3);
        activeWave = waves[Random.Range(0, waves.Count)];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemiesLeft = false;
        for (int i = 0; i<activeWave.Count; i++)
        {
            if (activeWave[i] != 0)
            {
                enemiesLeft = true;
            }
        }
        if (spawnStarted == false && enemiesLeft == true)
        {
            spawnStarted = true;
            UnityEngine.Debug.Log("Entered");
            Invoke("Spawn", spawnCooldown);
        }
    }
    void Spawn()
    {
        int enemiesToSpawn = 0;
        int enemyType = 0;
        Transform spawnPoint = transform.GetChild(Random.Range(0, transform.childCount));
        while (enemiesToSpawn == 0)
        {
            
            enemyType = Random.Range(0, 3);
            enemiesToSpawn = activeWave[enemyType];
        }
        switch(enemyType)
        {
            case 0:
                Instantiate(swarmer, spawnPoint);
                break;
            case 1:
                Instantiate(shooter, spawnPoint);
                break;
            case 2:
                Instantiate(sewerslider, spawnPoint);
                break;
            case 3:
                Instantiate(jeff, spawnPoint);
                break;
        }
        activeWave[enemyType]--;
        enemiesLeft = false;
        for (int i = 0; i<activeWave.Count; i++)
        {
            if (activeWave[i] != 0)
            {
                enemiesLeft = true;
            }
        }
        Invoke("Spawn", spawnCooldown);
    }
}
