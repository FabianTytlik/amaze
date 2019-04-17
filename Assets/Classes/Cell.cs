using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : ICell
{
    private int xCoordinate;
    private int zCoordinate;
    private List<IRoomFeature> roomFeatures;

    public Cell(IMaze parentMaze, int xCoordinate, int zCoordinate)
    {
        this.ParentMaze = parentMaze;
        this.xCoordinate = xCoordinate;
        this.zCoordinate = zCoordinate;
        this.roomFeatures = new List<IRoomFeature>();
    }

    public IMaze ParentMaze { get; }

    public int XCoordinate
    {
        get { return this.xCoordinate; }
        set
        {
            this.xCoordinate = value;
            foreach (IRoomFeature roomFeature in this.roomFeatures)
                roomFeature.UpdateGameObject();
        }
    }

    public int ZCoordinate
    {
        get { return this.zCoordinate; }
        set
        {
            this.zCoordinate = value;
            foreach (IRoomFeature roomFeature in this.roomFeatures)
                roomFeature.UpdateGameObject();
        }
    }

    public List<IRoomFeature> RoomFeatures { get { return this.roomFeatures; } }

    public void AddRoomFeature<T>(T roomFeature) where T : IRoomFeature
    {
        if(!this.roomFeatures.Where(rf => rf.GetType() == roomFeature.GetType()).Any())
            this.roomFeatures.Add(roomFeature);
    }
    public void AddRoomFeature(IWall wallRoomFeature, CardinalDirection orientation)
    {
        IEnumerable<IWall> walls = this.roomFeatures.Where(rf => rf.GetType() == wallRoomFeature.GetType()).Cast<IWall>();
        if(!walls.Where<IWall>(w => w.Orientation == wallRoomFeature.Orientation).Any())
            this.roomFeatures.Add(wallRoomFeature);
    }

    public IRoomFeature GetRoomFeature<T>() where T : IRoomFeature
    {     
        return this.roomFeatures.Where(rf => typeof(T).IsAssignableFrom(rf.GetType())).FirstOrDefault();
    }

    public IRoomFeature GetRoomFeature(CardinalDirection orientation)
    {
        return this.roomFeatures.Where(rf => typeof(IWall).IsAssignableFrom(rf.GetType())).Cast<IWall>().Where(w => w.Orientation == orientation).FirstOrDefault();
    }
}
