using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    List<List<int>> waves = new List<List<int>>();
    [SerializeField] List<int> wave1 = new List<int>();
    [SerializeField] List<int> wave2 = new List<int>();
    [SerializeField] List<int> wave3 = new List<int>();
    [SerializeField] float spawnCooldown = 1f;
    [SerializeField] GameObject jeff;
    [SerializeField] GameObject Swarmer;
    [SerializeField] GameObject Shooter;
    [SerializeField] GameObject Sewerslider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("Spawn", spawnCooldown);
    }
    void Spawn()
    {
        Transform spawnPoint = transform.GetChild(Random.Range(0, transform.childCount));

        Invoke("Spawn", spawnCooldown);
    }
}
