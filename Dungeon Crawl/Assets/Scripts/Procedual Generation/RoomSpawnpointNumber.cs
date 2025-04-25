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
        string _roomType;
        Transform _roomPosition;
        int _roomNumber;


        public RoomSpawnpointNumber(int number, Transform position, string Type)
        {
            _roomNumber = number;
            _roomPosition = position;
            _roomType = Type;
        }
    }
}
