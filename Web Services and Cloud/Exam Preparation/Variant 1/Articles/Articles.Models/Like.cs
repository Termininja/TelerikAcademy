namespace Articles.Models
{
    using System;

    public class Like
    {
        public int ID { get; set; }

        public string AuthorID { get; set; }
        public virtual ApplicationUser Author { get; set; }

        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }
    }
}