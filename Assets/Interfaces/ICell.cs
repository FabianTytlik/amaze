using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ICell
{
    IMaze ParentMaze { get; }
    int XCoordinate { get; set; }
    int ZCoordinate { get; set; }
    List<IRoomFeature> RoomFeatures { get; }
    void AddRoomFeature<T>(T roomFeature) where T : IRoomFeature;
    void AddRoomFeature(IWall wallRoomFeature, CardinalDirection orientation);
    IRoomFeature GetRoomFeature<T>() where T : IRoomFeature;
    IRoomFeature GetRoomFeature(CardinalDirection orientation);
}
