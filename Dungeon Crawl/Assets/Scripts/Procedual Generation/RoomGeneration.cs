using Assets.Scripts.Procedual_Generation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomGeneration : MonoBehaviour
{
    [SerializeField] List<RoomSpawnpoint> _roomSpawnPoints = new List<RoomSpawnpoint>();
    [SerializeField] List<GameObject> _2AdjacentDoorRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _2OppositeDoorRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _3DoorsRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _4DoorsRooms = new List<GameObject>();
    float spawnDelay;
    bool spawnNow = false;
    int roomSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartSpawning", spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSpawning()
    {

        string _roomType;
        roomSpawn++;
    } 
}
