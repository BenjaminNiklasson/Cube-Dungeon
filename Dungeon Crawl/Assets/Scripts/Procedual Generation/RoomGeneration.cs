using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomGeneration : MonoBehaviour
{
    List<RoomSpawnpoint> _roomSpawnPoints = new List<RoomSpawnpoint>();
    [SerializeField] List<GameObject> _2AdjacentDoorRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _2OppositeDoorRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _3DoorsRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _4DoorsRooms = new List<GameObject>();
    [SerializeField] float spawnDelay = 0.1f;
    bool spawnNow = false;
    int roomNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<transform.childCount; i++)
        {
            _roomSpawnPoints.Add(transform.GetChild(i).GetComponent<RoomSpawnpoint>());
        }
        Invoke("StartSpawning", spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSpawning()
    {
        string _roomType = _roomSpawnPoints[roomNumber].GetType();
        GameObject roomToSpawn = null;
        switch (_roomType)
        {
            case "_2AdjacentDoorRooms":
                roomToSpawn = _2AdjacentDoorRooms[UnityEngine.Random.Range(0, _2AdjacentDoorRooms.Count)];
                break;
            case "_2OppositeDoorRooms":
                roomToSpawn = _2OppositeDoorRooms[UnityEngine.Random.Range(0, _2OppositeDoorRooms.Count)];
                break;
            case "_3DoorsRooms":
                roomToSpawn = _3DoorsRooms[UnityEngine.Random.Range(0, _3DoorsRooms.Count)];
                break;
            case "_4DoorsRooms":
                roomToSpawn = _4DoorsRooms[UnityEngine.Random.Range(0, _4DoorsRooms.Count)];
                break;
        }
        Quaternion roomRotation = transform.rotation;
        roomRotation.z = roomRotation.z + _roomSpawnPoints[roomNumber].GetRotation();
        Instantiate(roomToSpawn, _roomSpawnPoints[roomNumber].GetPosition(), roomRotation);
        roomNumber++;
        if (roomNumber <= transform.childCount)
        {
            Invoke("StartSpawning", spawnDelay);
        }
    } 
}
