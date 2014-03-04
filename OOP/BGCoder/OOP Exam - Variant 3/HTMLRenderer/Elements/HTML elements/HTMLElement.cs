using System;
using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLElement : IElement
    {
        // Counstructor
        public HTMLElement(string name, string textContent = null)
        {
            this.Name = name;
            this.TextContent = textContent;
            this.ChildElements = new List<IElement>();
        }

        // Properties
        public string Name { get; private set; }
        public string TextContent { get; set; }
        public IEnumerable<IElement> ChildElements { get; private set; }

        // Methods
        public void AddElement(IElement element)
        {
            ((List<IElement>)this.ChildElements).Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (!string.IsNullOrWhiteSpace(this.Name)) output.AppendFormat("<{0}>", this.Name);
            if (this.TextContent != null && this.TextContent != String.Empty)
            {
                output.Append(this.TextContent.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;"));
            }
            foreach (IElement child in this.ChildElements) output.Append(child);
            if (!string.IsNullOrWhiteSpace(this.Name)) output.AppendFormat("</{0}>", this.Name);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            this.Render(strBuilder);
            return strBuilder.ToString();
        }
    }
}
