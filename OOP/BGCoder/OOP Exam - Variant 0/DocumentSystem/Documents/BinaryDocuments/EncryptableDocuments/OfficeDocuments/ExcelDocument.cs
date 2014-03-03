using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        // Properties
        public long? NumberOfRows { get; protected set; }
        public long? NumberOfColumns { get; protected set; }

        // Methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "rows" || key == "cols")
            {
                if (key == "rows") this.NumberOfRows = long.Parse(value);
                if (key == "cols") this.NumberOfColumns = long.Parse(value);
            }
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
            base.SaveAllProperties(output);
        }
    }
}
