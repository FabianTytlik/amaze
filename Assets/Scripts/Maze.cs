using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze 
{
    Player player;
    Room[,] maze;
    int size;

    public Maze(int size)
    {
        this.player = new Player();
        this.size = size;
        this.maze = new Room[size,size];
        GenerateMaze();
    }

    void GenerateMaze()
    {
        for(var i = 0;i<size;++i)
        {
            for(var j = 0;j<size;++j)
            {
                maze[i,j] = new Room(i,j);
            }
        }
    }

    public void MazeUpdate()
    {
        // here happens all the actions
    }
}