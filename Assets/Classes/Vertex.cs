using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Vertex : IVertex, IEquatable<Vertex>
{
    public Vertex(IMaze parentMaze, int xCoordinate, int zCoordinate)
    {
        this.ParentMaze = parentMaze;
        this.Edges = new List<IEdge>();
        this.AdjecantVertices = new List<IVertex>();
        this.XCoordinate = xCoordinate;
        this.ZCoordinate = zCoordinate;
    }

    public IMaze ParentMaze { get; }

    public int XCoordinate { get; }
    public int ZCoordinate { get; }

    public List<IEdge> Edges { get; }
    public List<IVertex> AdjecantVertices { get; }

    public void AddAdjecantVertex(IVertex other, IEdge edge = null)
    {
        if (edge == null)
        {
            edge = new Edge(this, other);
            this.AddEdge(edge);
        }
        else
            this.AddEdge(edge);

        if (!this.AdjecantVertices.Contains(other))
        {
            this.AdjecantVertices.Add(other);
            other.AddAdjecantVertex(this, edge);
        }
    }

    private void AddEdge(IEdge edge)
    {
        if (!this.Edges.Contains(edge))
            this.Edges.Add(edge);
    }

    public bool Equals(Vertex other)
    {
        if (other == null)
            return false;

        if (this.ParentMaze.Identifier != other.ParentMaze.Identifier)
            return false;

        return this.XCoordinate.Equals(other.XCoordinate) && this.ZCoordinate.Equals(other.ZCoordinate);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (!(obj is Vertex))
            return false;

        return this.Equals((Vertex)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = 326618964;
        hashCode = hashCode * -1521134295 + XCoordinate.GetHashCode();
        hashCode = hashCode * -1521134295 + ZCoordinate.GetHashCode();
        return hashCode;
    }

    public override string ToString()
    {
        return string.Format("Vertex X:{0} Z:{1}", this.XCoordinate, this.ZCoordinate);
    }
}
