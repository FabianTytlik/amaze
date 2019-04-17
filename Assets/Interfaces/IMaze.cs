public interface IMaze
{
    int Identifier { get; }
    IVertex[,] Tree { get; }
    ICell[,] CellGrid { get; }
    int XSize { get; }
    int ZSize { get; }
}