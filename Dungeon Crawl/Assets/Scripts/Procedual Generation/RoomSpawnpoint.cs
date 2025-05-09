using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnpoint : MonoBehaviour
{
    List<bool> _roomDoors = new List<bool>();
    Transform _roomPosition;
    int _roomNumber;
    Collider2D _doorTrigger;

    public RoomSpawnpointNumber(int number, Transform position)
    {
        _roomNumber = number;
        _roomPosition = position;
        _doorTrigger = _roomPosition.GetComponent<Collider2D>();
    }

    public string GetType()
    {

    }

    public int GetRotation()
    {

    }
}
