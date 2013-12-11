namespace HTMLRenderer
{
    public interface ITable : IElement
    {
        // Properties
        int Rows { get; }
        int Cols { get; }

        // Indexers
        IElement this[int row, int col] { get; set; }
    }
}
