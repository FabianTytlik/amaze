using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Maze maze;
    int mazeSize = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadCatalog();
        this.maze = new Maze(mazeSize);
    }

    // Update is called once per frame
    void Update()
    {
        maze.MazeUpdate();
    }

    void LoadCatalog()
    {
        Catalog.wall = wall;
        Catalog.floor = floor;
        Catalog.ceiling = ceiling;
    }

    public GameObject wall;
    public GameObject floor;
    public GameObject ceiling;
}
