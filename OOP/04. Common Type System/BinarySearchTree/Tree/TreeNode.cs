namespace BinarySearchTree
{
    using System;
    using System.Text;

    public class TreeNode<T> where T : IComparable
    {
        public TreeNode(T value)
        {
            this.Value = value;
            this.LeftNode = null;
            this.RightNode = null;
            this.ParentNode = null;
        }

        public T Value { get; set; }

        public TreeNode<T> LeftNode { get; set; }

        public TreeNode<T> RightNode { get; set; }

        public TreeNode<T> ParentNode { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.Value.CompareTo(default(T)) != 0)
            {
                result.AppendFormat("Value: {0,-5}  ", this.Value);
                result.AppendFormat("Parent node: {0,-5}  ", this.ParentNode == null ? "null" : this.ParentNode.Value.ToString());
                result.AppendFormat("Left node: {0,-5}  ", this.LeftNode == null ? "null" : this.LeftNode.Value.ToString());
                result.AppendFormat("Right node: {0,-5}", this.RightNode == null ? "null" : this.RightNode.Value.ToString());
            }

            return result.ToString();
        }
    }
}
