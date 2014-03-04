using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        // Properties
        public string Name { get; protected set; }
        public string Content { get; protected set; }

        // Methods
        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name") this.Name = value;
            if (key == "content") this.Content = value;
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name + "[");
            if (this is IEncryptable && (this as IEncryptable).IsEncrypted)
            {
                result.Append("encrypted");
            }
            else
            {
                List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
                this.SaveAllProperties(properties);
                properties = properties.OrderBy(m => m.Key).ToList();

                for (int i = 0; i < properties.Count; i++)
                {
                    if (properties[i].Value != null)
                    {
                        result.Append(properties[i].Key + "=" + properties[i].Value);
                        result.Append(";");
                    }
                }
                result.Length--;
            }
            result.Append("]");

            return result.ToString();
        }
    }
}
