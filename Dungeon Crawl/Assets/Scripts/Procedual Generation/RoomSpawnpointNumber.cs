using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Procedual_Generation
{
    internal class RoomSpawnpointNumber
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
    }
}
