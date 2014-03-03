using System.Collections.Generic;

namespace DocumentSystem
{
    public interface IDocument
    {
        // Properties
        string Name { get; }
        string Content { get; }

        // Methods
        void LoadProperty(string key, string value);
        void SaveAllProperties(IList<KeyValuePair<string, object>> output);
        string ToString();
    }
}
