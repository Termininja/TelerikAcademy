using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class PDFDocument : EncryptableDocument
    {
        // Property
        public long? NumberOfPages { get; protected set; }

        // Methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "pages") this.NumberOfPages = long.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
            base.SaveAllProperties(output);
        }
    }
}
