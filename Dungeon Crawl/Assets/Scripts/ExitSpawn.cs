using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSpawn : MonoBehaviour
{
    public bool iSpawn = false;
    public string prefabName = "ExitSpawn";
    public Vector3 spawnPosition = Vector3.zero;
    [SerializeField] GameObject exitSpawn;

    void Start()
    {
        
    }

    void SpawnPrefab()
    {
        
        if (exitSpawn != null)
        {
            Instantiate(exitSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab not found in Resources folder!");
        }
    }

    void Update()
    {
        if (iSpawn == true)
        {
            SpawnPrefab();
        }
    }
    
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player")) // Check the incoming object
    //    {
    //        Debug.Log("Player entered the area!");
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    //    }
    //}
    

}
