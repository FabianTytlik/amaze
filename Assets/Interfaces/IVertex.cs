using System.Collections.Generic;

public interface IVertex
{
    List<IVertex> AdjecantVertices { get; }
    List<IEdge> Edges { get; }
    int XCoordinate { get; }
    int ZCoordinate { get; }

    void AddAdjecantVertex(IVertex other, IEdge edge = null);
    bool Equals(object obj);
    bool Equals(Vertex other);
    int GetHashCode();
    string ToString();
}