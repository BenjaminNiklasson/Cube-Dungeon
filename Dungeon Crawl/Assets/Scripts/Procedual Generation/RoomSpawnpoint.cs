using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawnpoint : MonoBehaviour
{
    List<bool> _roomDoors = new List<bool>();
    int _roomNumber;
    Collider2D _doorTrigger;

    private void Awake()
    {
        _doorTrigger = gameObject.GetComponent<Collider2D>();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public string GetType()
    {

    }

    public int GetRotation()
    {

    }
}
