using Assets.Scripts.Procedual_Generation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    [SerializeField] List<RoomSpawnpointNumber> _roomSpawnPoints = new List<RoomSpawnpointNumber>();
    [SerializeField] Dictionary<string, GameObject> _rooms = new Dictionary<string, GameObject>();
    List<GameObject> _1DoorRooms = new List<GameObject>();
    List<GameObject> _2AdjacentDoorRooms = new List<GameObject>();
    List<GameObject> _2OppositeDoorRooms = new List<GameObject>();
    List<GameObject> _3DoorsRooms = new List<GameObject>();
    List<GameObject> _4DoorsRooms = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        sortRooms();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void sortRooms()
    {
        foreach (var room in _rooms)
        {
            switch (room.Key)
            {
                case "1Door":
                    _1DoorRooms.Add(room.Value);
                    break;
                case "2AdjacentDoors":
                    _2AdjacentDoorRooms.Add(room.Value);
                    break;
                case "2OppositeDoors":
                    _2OppositeDoorRooms.Add(room.Value);
                    break;
                case "3Doors":
                    _3DoorsRooms.Add(room.Value);
                    break;
                case "4Doors":
                    _4DoorsRooms.Add(room.Value);
                    break;
            }
        }
    }
}
