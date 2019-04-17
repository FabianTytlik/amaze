using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Edge : IEdge, IEquatable<Edge>
{
    public Edge(IVertex vertex0, IVertex vertex1)
    {
        CardinalDirection vertex0Direction = CalculateRelativeDirection(vertex1, vertex0);
        CardinalDirection vertex1Direction = CalculateRelativeDirection(vertex0, vertex1);
        this.Vertices = new Tuple<IVertex, CardinalDirection>[2] {Tuple.Create(vertex0, vertex0Direction), Tuple.Create(vertex1, vertex1Direction)};
    }
    public Tuple<IVertex, CardinalDirection>[] Vertices { get; }

    public bool Equals(Edge other)
    {
        if (other == null)
            return false;

        for (int i = 0; i < 2; i++)
        {
            if (!this.Vertices.Contains(other.Vertices[i]))
                return false;
        }
        return true;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        if (!(obj is Edge))
            return false;

        return this.Equals((Edge)obj);
    }

    public override int GetHashCode()
    {
        return -1648612642 + EqualityComparer<Tuple<IVertex, CardinalDirection>[]>.Default.GetHashCode(Vertices);
    }

    public override string ToString()
    {
        return string.Format("{0}:({1}), {2}:({3})", this.Vertices[0].Item2, this.Vertices[0].Item1, this.Vertices[1].Item2, this.Vertices[1].Item1);
    }

    private CardinalDirection CalculateRelativeDirection(IVertex fromVertex, IVertex toVertex)
    {
        if (fromVertex.ZCoordinate - toVertex.ZCoordinate == -1)
            return CardinalDirection.North;
        else if (fromVertex.ZCoordinate - toVertex.ZCoordinate == 1)
            return CardinalDirection.South;
        else if (fromVertex.XCoordinate - toVertex.XCoordinate == -1)
            return CardinalDirection.East;
        else if (fromVertex.XCoordinate - toVertex.XCoordinate == 1)
            return CardinalDirection.West;
        else
            throw new Exception(string.Format("Invalid adjecant vertex coordinates:{0}, {1}", fromVertex, toVertex));
    }
}
