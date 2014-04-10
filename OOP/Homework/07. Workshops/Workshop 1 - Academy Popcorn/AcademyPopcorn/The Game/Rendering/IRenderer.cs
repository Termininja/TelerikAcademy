namespace AcademyPopcorn
{
    // Drawer for IRenderable objects
    public interface IRenderer
    {
        // What object will be rendered
        void EnqueueForRendering(IRenderable obj);

        // Render all objects
        void RenderAll();

        // Clear the buffer
        void ClearQueue();
    }
}
