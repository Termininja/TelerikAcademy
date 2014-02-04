using System.Collections.Generic;

namespace School
{
    interface ICommentable
    {
        // Property
        List<string> Comments { get; set; }

        // Method
        void AddComment(string comment);
    }
}
