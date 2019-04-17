using System;

public interface IEdge
{
    Tuple<IVertex, CardinalDirection>[] Vertices { get; }

    bool Equals(Edge other);
    bool Equals(object obj);
    int GetHashCode();
    string ToString();
}