using UnityEngine;
using System.Collections;

public class Maze : IMaze
{
    public Maze(int xSize, int zSize, int identifier)
    {
        this.Identifier = identifier;
        this.XSize = xSize;
        this.ZSize = zSize;
        this.CellGrid = CreateCellGrid(this.XSize, this.ZSize);
        this.Tree = CreateTree(this.XSize, this.ZSize);
    }

    public int Identifier { get; }
    public IVertex[,] Tree { get; }
    public ICell[,] CellGrid { get; }
    public int XSize { get; }
    public int ZSize { get; }

    private ICell[,] CreateCellGrid(int xSize, int zSize)
    {
        ICell[,] result = new ICell[xSize, zSize];

        for (int xCoordinate = 0; xCoordinate < xSize; xCoordinate++)
        {
            for (int zCoordinate = 0; zCoordinate < zSize; zCoordinate++)
            {
                result[xCoordinate, zCoordinate] = new Cell(this, xCoordinate, zCoordinate);
            }
        }

        return result;
    }

    private IVertex[,] CreateTree(int xSize, int zSize)
    {
        IVertex[,] result = new IVertex[xSize, zSize];

        for(int xCoordinate = 0; xCoordinate < xSize; xCoordinate++)
        {
            for (int zCoordinate = 0; zCoordinate < zSize; zCoordinate++)
            {
                result[xCoordinate, zCoordinate] = new Vertex(this, xCoordinate, zCoordinate);
            }
        }

        return result;
    }
}
