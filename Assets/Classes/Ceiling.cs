using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : RoomFeature, ICeiling
{
    public Ceiling(ICell parentCell, GameObject gameObject)
        : base(parentCell, gameObject)
    {
    }

    public Ceiling(ICell parentCell)
        : base(parentCell)
    {
    }
}
