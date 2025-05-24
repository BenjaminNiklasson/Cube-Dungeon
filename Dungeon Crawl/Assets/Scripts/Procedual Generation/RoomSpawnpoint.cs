using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnpoint : MonoBehaviour
{
    Collider2D _doorTrigger;
    string _roomType;
    int _roomRotation;
    ContactFilter2D _filter = new ContactFilter2D();
    [SerializeField] LayerMask layerMask = LayerMask.GetMask();
    Collider2D[] _results = new Collider2D[10];
    enum RoomDoors {posibleDoor, door, wall};
    RoomDoors[] _roomDoors = new RoomDoors[4];

    private void Awake()
    {
        _doorTrigger = gameObject.GetComponentInChildren<BoxCollider2D>();
        _filter.SetLayerMask(layerMask);
        _filter.useLayerMask = true;
        _filter.useTriggers = true;
        ResetRoomDoors();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public string GetType()
    {
        return _roomType;
    }

    public int GetRotation()
    {
        return _roomRotation;
    }

    public void CheckCollisions(int childNumber)
    {
        _results = new Collider2D[10];
        ResetRoomDoors();
        int count = _doorTrigger.OverlapCollider(_filter, _results);

        for (int i = 0; i < count; i++)
        {
            if (Math.Abs(_results[i].transform.position.x - transform.position.x) < Math.Abs(_results[i].transform.position.y - transform.position.y) & _results[i].transform.position.y - transform.position.y > 0)
            {
                CheckCollisionTag(0, i);
            }
            else if (Math.Abs(_results[i].transform.position.x - transform.position.x) > Math.Abs(_results[i].transform.position.y - transform.position.y) & _results[i].transform.position.x - transform.position.x < 0)
            {
                CheckCollisionTag(1, i);
            }
            else if (Math.Abs(_results[i].transform.position.x - transform.position.x) < Math.Abs(_results[i].transform.position.x - transform.position.x) & _results[i].transform.position.y - transform.position.y < 0)
            {
                CheckCollisionTag(2, i);
            }
            else if (Math.Abs(_results[i].transform.position.x - transform.position.x) > Math.Abs(_results[i].transform.position.x - transform.position.x) & _results[i].transform.position.x - transform.position.x > 0)
            {
                CheckCollisionTag(3, i);
            }
        }

        if (_roomDoors[0] == RoomDoors.wall && _roomDoors[1] == RoomDoors.wall && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.posibleDoor)
        {
            _roomType = "_2AdjacentDoorRooms";
            _roomRotation = 180;
            Debug.Log("ifstatement 1");
        }
        else if (_roomDoors[0] == RoomDoors.wall && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.posibleDoor && childNumber == 5)
        {
            int rnd = UnityEngine.Random.Range(1, 11);
            switch (rnd)
            {
                case int n when (n >= 5 && n <= 10):
                    _roomType = "_3DoorsRooms";
                    _roomRotation = 90;
                    break;
                case 4:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 90;
                    break;
                case 3:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 0;
                    break;
                case 2:
                case 1:
                    _roomType = "_2OppositeDoorRooms";
                    _roomRotation = 90;
                    break;
            }
            Debug.Log("ifstatement 2");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.wall && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.posibleDoor && childNumber == 5)
        {
            int rnd = UnityEngine.Random.Range(1, 11);
            switch (rnd)
            {
                case int n when (n >= 5 && n <= 10):
                    _roomType = "_3DoorsRooms";
                    _roomRotation = 180;
                    break;
                case 4:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 180;
                    break;
                case 3:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 90;
                    break;
                case 2:
                case 1:
                    _roomType = "_2OppositeDoorRooms";
                    _roomRotation = 180;
                    break;
            }
            Debug.Log("ifstatement 3");
        }
        else if (_roomDoors[0] == RoomDoors.wall && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.posibleDoor)
        {
            if (UnityEngine.Random.Range(1, 6) > 2)
            {
                _roomType = "_3DoorsRooms";
            }
            else
            {
                _roomType = "_2OppositeDoorRooms";
            }
            _roomRotation = 90;
            Debug.Log("ifstatement 4");
        }
        else if (_roomDoors[0] == RoomDoors.wall && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.wall)
        {
            _roomType = "_2AdjacentDoorRooms";
            _roomRotation = 90;
            Debug.Log("ifstatement 5");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.wall && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.posibleDoor)
        {
            if (UnityEngine.Random.Range(1, 6) > 2)
            {
                _roomType = "_3DoorsRooms";
            }
            else
            {
                _roomType = "_2OppositeDoorRooms";
            }
            _roomRotation = 180;
            Debug.Log("ifstatement 6");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.posibleDoor)
        {
            int rnd = UnityEngine.Random.Range(1, 36);
            switch (rnd)
            {
                case int n when (n >= 21 && n <= 36):
                    _roomType = "_4DoorsRooms";
                    _roomRotation = 0;
                    break;
                case int n when (n >= 18 && n <= 20):
                    _roomType = "_3DoorsRooms";
                    _roomRotation = 0;
                    break;
                case int n when (n >= 15 && n <= 17):
                    _roomType = "_3DoorsRooms";
                    _roomRotation = 90;
                    break;
                case int n when (n >= 12 && n <= 14):
                    _roomType = "_3DoorsRooms";
                    _roomRotation = 180;
                    break;
                case int n when (n >= 9 && n <= 11):
                    _roomType = "_3DoorsRooms";
                    _roomRotation = 270;
                    break;
                case 8:
                case 7:
                    _roomType = "_2OppositeDoorRooms";
                    _roomRotation = 0;
                    break;
                case 6:
                case 5:
                    _roomType = "_2OppositeDoorRooms";
                    _roomRotation = 90;
                    break;
                case 4:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 0;
                    break;
                case 3:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 90;
                    break;
                case 2:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 180;
                    break;
                case 1:
                    _roomType = "_2AdjacentDoorRooms";
                    _roomRotation = 270;
                    break;
            }
            Debug.Log("ifstatement 7");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.wall)
        {
            if (UnityEngine.Random.Range(1, 6) > 2)
            {
                _roomType = "_3DoorsRooms";
            }
            else
            {
                _roomType = "_2OppositeDoorRooms";
            }
            _roomRotation = 0;
            Debug.Log("ifstatement 8");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.wall && _roomDoors[2] == RoomDoors.posibleDoor && _roomDoors[3] == RoomDoors.wall)
        {
            _roomType = "_2OppositeDoorRooms";
            _roomRotation = 0;
            Debug.Log("ifstatement 9");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.wall && _roomDoors[2] == RoomDoors.wall && _roomDoors[3] == RoomDoors.posibleDoor)
        {
            _roomType = "_2AdjacentDoorRooms";
            _roomRotation = 270;
            Debug.Log("ifstatement 10");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.wall && _roomDoors[3] == RoomDoors.posibleDoor)
        {
            if (UnityEngine.Random.Range(1, 6) > 2)
            {
                _roomType = "_3DoorsRooms";
            }
            else
            {
                _roomType = "_2OppositeDoorRooms";
            }
            _roomRotation = 270;
            Debug.Log("ifstatement 11");
        }
        else if (_roomDoors[0] == RoomDoors.wall && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.wall && _roomDoors[3] == RoomDoors.posibleDoor)
        {
            _roomType = "_2OppositeDoorRooms";
            _roomRotation = 270;
            Debug.Log("ifstatement 12");
        }
        else if (_roomDoors[0] == RoomDoors.door && _roomDoors[1] == RoomDoors.door && _roomDoors[2] == RoomDoors.wall && _roomDoors[3] == RoomDoors.wall)
        {
            _roomType = "_2AdjacentDoorRooms";
            _roomRotation = 270;
            Debug.Log("ifstatement 13");
        }
        else
        {
            _roomType = "_4DoorsRooms";
            Debug.Log("ifstatement chrach");
        }
    }

    private void CheckCollisionTag(int position, int colliderNumber)
    {
        if (_results[colliderNumber].CompareTag("Door"))
        {
            _roomDoors[position] = RoomDoors.door;
        }
        else if (_results[colliderNumber].CompareTag("WallTrigger"))
        {
            _roomDoors[position] = RoomDoors.wall;
        }
    }

    private void ResetRoomDoors()
    {
        for (int i = 0; i >= 4; i++)
        {
            _roomDoors[i] = RoomDoors.posibleDoor;
        }
    }
}
