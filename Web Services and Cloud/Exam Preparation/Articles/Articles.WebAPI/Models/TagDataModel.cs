namespace Articles.WebAPI.Models
{
    using System;
    using System.Linq.Expressions;

    using Articles.Models;

    public class TagDataModel
    {
        public static Expression<Func<Tag, TagDataModel>> FromTag
        {
            get
            {
                return t => new TagDataModel
                {
                    ID = t.ID,
                    Name = t.Name
                };
            }
        }

        public int ID { get; set; }

        public string Name { get; set; }
    }
}