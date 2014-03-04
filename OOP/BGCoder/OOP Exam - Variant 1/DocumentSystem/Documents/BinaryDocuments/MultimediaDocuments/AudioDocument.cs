using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        // Propetry
        public double? SampleRate { get; protected set; }

        // Methods
        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate") this.SampleRate = double.Parse(value);
            else base.LoadProperty(key, value);
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
            base.SaveAllProperties(output);
        }
    }
}
