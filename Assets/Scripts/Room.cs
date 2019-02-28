using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    Vector2 position;

    // the GameObjects will be replaced with Envirolment 
    GameObject floor;
    GameObject ceiling;
    GameObject wallN;
    GameObject wallS;
    GameObject wallE;
    GameObject wallW;

    // plus items and stuff

    public Room(int x, int y)
    {
        position = new Vector2(x,y);
        InstantiateRoom();
    }
    
    void InstantiateRoom()
    {
        var position3d = GetPosition3d();

        floor = GameObject.Instantiate(Catalog.floor,position3d,Quaternion.identity);
    //  the ceiling is hidden because we want to see how the maze looks  
    //    ceiling = GameObject.Instantiate(Catalog.ceiling,position3d+Vector3.up*10,Quaternion.identity);
        wallN = GameObject.Instantiate(Catalog.wall,position3d+Vector3.up*5+Vector3.forward*4.8f,Quaternion.identity);
        wallS = GameObject.Instantiate(Catalog.wall,position3d+Vector3.up*5-Vector3.forward*4.8f,Quaternion.identity);
        wallE = GameObject.Instantiate(Catalog.wall,position3d+Vector3.up*5+Vector3.right*4.8f,Quaternion.Euler(0,90,0));
        wallW = GameObject.Instantiate(Catalog.wall,position3d+Vector3.up*5-Vector3.right*4.8f,Quaternion.Euler(0,90,0));
    }

    public Vector3 GetPosition3d()
    {
        return new Vector3(position.x*10,0,position.y*10);
    }
}
