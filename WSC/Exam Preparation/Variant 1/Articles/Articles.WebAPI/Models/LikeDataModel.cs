namespace Articles.WebAPI.Models
{
    using System;
    using System.Linq.Expressions;

    using Articles.Models;

    public class LikeDataModel
    {
        public static Expression<Func<Like, LikeDataModel>> FromLike
        {
            get
            {
                return l => new LikeDataModel
                {
                    AuthorName = l.Author.UserName,
                    ID = l.ID
                };
            }
        }

        public int ID { get; set; }

        public string AuthorName { get; set; }
    }
}
