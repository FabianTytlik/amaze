using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : RoomFeature, IWall
{
    private float xOffset;
    private float zOffset;
    private float yRotation;

    public Wall(ICell parentCell, GameObject gameObject, CardinalDirection orientation)
        : base(parentCell, gameObject)
    {
        this.Orientation = orientation;
        CalculateOffset();
    }
    public Wall(ICell parentCell, CardinalDirection orientation)
        : this(parentCell, null, orientation)
    {
    }

    public CardinalDirection Orientation { get; }

    public float XOffset { get => this.xOffset; }
    public float ZOffset { get => this.zOffset; }
    public float YRotation { get => this.yRotation; }

    public override void UpdateGameObject()
    {
        if (this.GameObject != null)
        {
            UpdateXPosition(this.XOffset);
            UpdateZPosition(this.ZOffset);
            UpdateYRotation(this.YRotation);
            UpdateGameObjectName(this.Orientation.ToString());
        }
    }

    private void CalculateOffset()
    {
        this.xOffset = 0;
        this.zOffset = 0;
        this.yRotation = 0;

        switch (this.Orientation)
        {
            case CardinalDirection.North:
                this.zOffset = 4.75F;
                break;
            case CardinalDirection.South:
                this.zOffset = -4.75F;
                break;
            case CardinalDirection.East:
                this.xOffset = 4.75F;
                this.yRotation = 90;
                break;
            case CardinalDirection.West:
                this.xOffset = -4.75F;
                this.yRotation = 90;
                break;
        }
        UpdateGameObject();
    }
}
