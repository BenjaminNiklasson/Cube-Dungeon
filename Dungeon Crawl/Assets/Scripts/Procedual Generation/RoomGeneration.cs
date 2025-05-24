using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class RoomGeneration : MonoBehaviour
{
    List<RoomSpawnpoint> _roomSpawnPoints = new List<RoomSpawnpoint>();
    [SerializeField] List<GameObject> _2AdjacentDoorRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _2OppositeDoorRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _3DoorsRooms = new List<GameObject>();
    [SerializeField] List<GameObject> _4DoorsRooms = new List<GameObject>();
    [SerializeField] float spawnDelay = 0.1f;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    int roomNumber = 0;
    int exitRoom = 0;
    string _roomType;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<transform.childCount; i++)
        {
            _roomSpawnPoints.Add(transform.GetChild(i).GetComponent<RoomSpawnpoint>());
        }
        exitRoom = UnityEngine.Random.Range(6, transform.childCount);
        Invoke("StartSpawning", spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSpawning()
    {
        _roomSpawnPoints[roomNumber].CheckCollisions(roomNumber);
        _roomType = _roomSpawnPoints[roomNumber].GetType();
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
        Vector3 roomPosition = new Vector3(transform.GetChild(roomNumber).GetChild(0).position.x + offsetX, transform.GetChild(roomNumber).GetChild(0).position.y + offsetY, transform.GetChild(roomNumber).GetChild(0).position.z);
        GameObject SpawnedRoom = Instantiate(roomToSpawn, roomPosition, roomRotation);
        if (roomNumber == exitRoom)
        {
            SpawnedRoom.GetComponentInChildren<ExitSpawn>().iSpawn = true;
        }
        roomNumber++;
        if (roomNumber <= transform.childCount)
        {
            Invoke("StartSpawning", spawnDelay);
        }
    } 
}
