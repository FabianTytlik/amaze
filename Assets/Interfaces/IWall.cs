using UnityEngine;
using System.Collections;

public interface IWall : IRoomFeature
{
    CardinalDirection Orientation { get; }
    float XOffset { get; }
    float ZOffset { get; }
    float YRotation { get; }
}
