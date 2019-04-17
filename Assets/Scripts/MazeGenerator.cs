using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour
{
    private PrefabRepository PrefabRepository;
    private int mazeCounter;

    // Start is called before the first frame update
    void Start()
    {

        this.mazeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPrefabRepository(PrefabRepository prefabRepository)
    {
        this.PrefabRepository = prefabRepository;
    }

    public Maze GenerateNewMaze(int xSize, int zSize)
    {
        Maze maze = new Maze(xSize, zSize, mazeCounter);
        mazeCounter++;
        GenerateSpanningTree(maze);
        AddBasicFeatures(maze);
        AddGameObjects(maze);

        return maze;
    }

    private void AddBasicFeatures(IMaze maze)
    {
        foreach (ICell cell in maze.CellGrid)
        {
            cell.AddRoomFeature<IFloor>(new Floor(cell));

            IVertex mappedVertex = maze.Tree[cell.XCoordinate, cell.ZCoordinate];
            foreach (CardinalDirection direction in (CardinalDirection[])Enum.GetValues(typeof(CardinalDirection)))
            {
                if (!mappedVertex.Edges.Where(e => e.Vertices[0].Item1 != mappedVertex && e.Vertices[0].Item2 == direction
                                              || e.Vertices[1].Item1 != mappedVertex && e.Vertices[1].Item2 == direction).Any())
                {
                    cell.AddRoomFeature(new Wall(cell, direction), direction);
                }
            }
            
            //cell.AddRoomFeature<ICeiling>(new Ceiling(cell));
        }
    }

    private void AddGameObjects(IMaze maze)
    {
        foreach (ICell cell in maze.CellGrid)
        {
            foreach(IRoomFeature roomFeature in cell.RoomFeatures)
            {
                if(roomFeature is Floor)
                    roomFeature.GameObject = Instantiate(PrefabRepository.Floor);
                if(roomFeature is Wall)
                    roomFeature.GameObject = Instantiate(PrefabRepository.Wall);
                if (roomFeature is Ceiling)
                    roomFeature.GameObject = Instantiate(PrefabRepository.Ceiling);
            }

        }

    }

    private void GenerateSpanningTree(IMaze maze)
    {
        int startX = Random.Range(0, maze.XSize);
        int startZ = Random.Range(0, maze.ZSize);
        IVertex startVertex = maze.Tree[startX, startZ];
        AddEdgeToNextVertex(startVertex, maze);
    }

    private void AddEdgeToNextVertex(IVertex currentVertex, IMaze maze)
    {
        List<IVertex> neighbours = new List<IVertex>();

        if(currentVertex.XCoordinate - 1 >= 0)
            neighbours.Add(maze.Tree[currentVertex.XCoordinate - 1, currentVertex.ZCoordinate]);

        if (currentVertex.XCoordinate + 1 < maze.XSize)
            neighbours.Add(maze.Tree[currentVertex.XCoordinate + 1, currentVertex.ZCoordinate]);

        if (currentVertex.ZCoordinate - 1 >= 0)
                neighbours.Add(maze.Tree[currentVertex.XCoordinate, currentVertex.ZCoordinate - 1]);

        if (currentVertex.ZCoordinate + 1 < maze.ZSize)
                neighbours.Add(maze.Tree[currentVertex.XCoordinate, currentVertex.ZCoordinate + 1]);


        neighbours.Shuffle();

        foreach(IVertex neighbour in neighbours)
        {
            if (neighbour.Edges.Count == 0)
            {
                currentVertex.AddAdjecantVertex(neighbour);
                AddEdgeToNextVertex(neighbour, maze);
            }
        }
    }
}
