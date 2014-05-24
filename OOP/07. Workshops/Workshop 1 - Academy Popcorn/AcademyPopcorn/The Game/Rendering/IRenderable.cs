namespace AcademyPopcorn
{
    // The object can be drawed
    public interface IRenderable
    {
        // Where the object is located
        MatrixCoords GetTopLeft();

        // How the object to be rendered 
        char[,] GetImage();
    }
}
