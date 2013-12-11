namespace HTMLRenderer
{
    public interface IElementFactory
    {
        // Methods
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }
}
