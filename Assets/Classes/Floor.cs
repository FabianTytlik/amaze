using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : RoomFeature, IFloor
{
    public Floor(ICell parentCell, GameObject gameObject)
        : base(parentCell, gameObject)
    {
    }
    public Floor(ICell parentCell)
        : base(parentCell)
    {
    }
}
