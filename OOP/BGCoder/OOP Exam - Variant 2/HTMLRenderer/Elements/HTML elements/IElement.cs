using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
    public interface IElement
    {
        // Properties
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }

        // Methods
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }
}
