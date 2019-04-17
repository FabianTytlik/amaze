using UnityEngine;
using System.Collections;

public class RoomFeature : IRoomFeature
{
    private ICell parentCell;
    private GameObject instanceOfGameObject;

    public RoomFeature(ICell parentCell, GameObject gameObject)
    {
        this.parentCell = parentCell;
        this.GameObject = gameObject;
    }

    public RoomFeature(ICell parentCell)
        : this(parentCell, null)
    {
    }

    public ICell ParentCell { get { return this.parentCell; } }

    public GameObject GameObject
    {
        get
        {
            return this.instanceOfGameObject;
        }
        set
        {
            this.instanceOfGameObject = value;
            UpdateGameObject();
        }
    }

    public int XCoordinate
    {
        get { return this.ParentCell.XCoordinate; }
    }
    
    public int ZCoordinate
    {
        get { return this.ParentCell.ZCoordinate; }
    }

    public virtual void UpdateGameObject()
    {
        if (instanceOfGameObject != null)
        {
            UpdateXPosition();
            UpdateZPosition();
            UpdateGameObjectName();
        }
    }

    protected void UpdateXPosition(float xOffset = 0)
    {
        Vector3 position = this.instanceOfGameObject.transform.position;
        this.instanceOfGameObject.transform.position = new Vector3((this.XCoordinate * 10) + xOffset, position.y, position.z);
    }

    protected void UpdateZPosition(float zOffset = 0)
    {
        Vector3 position = this.instanceOfGameObject.transform.position;
        this.instanceOfGameObject.transform.position = new Vector3(position.x, position.y, (this.ZCoordinate * 10) + zOffset);
    }

    protected void UpdateYRotation(float yRotationOffset)
    {
        Vector3 rotation = this.instanceOfGameObject.transform.rotation.eulerAngles;
        this.instanceOfGameObject.transform.rotation = Quaternion.Euler(rotation.x, rotation.y + yRotationOffset, rotation.z);
    }

    protected void UpdateGameObjectName(params string[] suffixes)
    {
        string name = string.Format("(X:{0}/Z:{1}) {2}", this.XCoordinate, this.ZCoordinate, this.GetType().Name);
        if (suffixes != null)
        {
            foreach (string suffix in suffixes)
                name = string.Format("{0} {1}", name, suffix);
        }

        this.instanceOfGameObject.name = name;
    }
}
