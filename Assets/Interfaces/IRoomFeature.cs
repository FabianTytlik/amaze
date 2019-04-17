using UnityEngine;
using System.Collections;

public interface IRoomFeature 
{
    ICell ParentCell { get; }
    GameObject GameObject { get; set; }
    int XCoordinate { get; }
    int ZCoordinate { get; }
    void UpdateGameObject();
}
