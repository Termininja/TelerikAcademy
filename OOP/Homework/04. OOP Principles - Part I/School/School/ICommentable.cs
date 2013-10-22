using System.Collections.Generic;

namespace School
{
    interface ICommentable
    {
        // Property
        List<string> Comments { get; set; }

        // AddClass
        void AddComment(string comment);
    }
}
