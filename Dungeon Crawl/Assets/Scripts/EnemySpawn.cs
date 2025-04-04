using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<int> waves = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Transform spawnPoint = transform.GetChild(Random.Range(0, transform.GetChildCount()));

    }
}
