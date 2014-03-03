using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class OfficeDocument : EncryptableDocument
    {
        // Property
        public string Version { get; protected set; }

        // Methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "version") this.Version = value;
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("version", this.Version));
            base.SaveAllProperties(output);
        }
    }
}
