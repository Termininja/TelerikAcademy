namespace BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : ICloneable, IEnumerable<T> where T : IComparable
    {
        public BinarySearchTree()
        {
            this.Nodes = new List<TreeNode<T>>();
        }

        public BinarySearchTree(List<TreeNode<T>> nodes)
        {
            this.Nodes = nodes;
        }

        public List<TreeNode<T>> Nodes { get; set; }

        // Adding new element in the tree
        public void Add(T element)
        {
            if (this.Nodes.Count > 0)
            {
                foreach (var node in this.Nodes)
                {
                    if ((node.Value.CompareTo(default(T)) == 0) &&
                        (node.ParentNode.Value.CompareTo(element) > 0 || node.ParentNode.Value.CompareTo(element) < 0) &&
                        ((node.LeftNode == null || (node.LeftNode != null && element.CompareTo(node.LeftNode.Value) > 0)) &&
                        (node.RightNode == null || (node.RightNode != null && element.CompareTo(node.RightNode.Value) < 0))))
                    {
                        this.Nodes[this.Nodes.IndexOf(node)].Value = element;
                        break;
                    }

                    if (element.CompareTo(node.Value) == 0 ||
                        (node.LeftNode != null && element.CompareTo(node.LeftNode.Value) == 0) ||
                        (node.RightNode != null && element.CompareTo(node.RightNode.Value) == 0))
                    {
                        throw new ArgumentException(String.Format("The element with value={0} is already in the tree!", element));
                    }
                    else if (element.CompareTo(node.Value) < 0 && node.LeftNode == null)
                    {
                        node.LeftNode = new TreeNode<T>(element);
                        node.LeftNode.ParentNode = node;
                        Nodes.Add(node.LeftNode);
                        break;
                    }
                    else if (node.RightNode == null)
                    {
                        node.RightNode = new TreeNode<T>(element);
                        node.RightNode.ParentNode = node;
                        Nodes.Add(node.RightNode);
                        break;
                    }
                }
            }
            else
            {
                Nodes.Add(new TreeNode<T>(element));
            }

        }

        // Searching for some element in the tree
        public TreeNode<T> Search(T element)
        {
            foreach (var node in this.Nodes)
            {
                if (node != null && element.CompareTo(node.Value) == 0)
                {
                    return node;
                }
            }

            return null;
        }

        // Deleting some element in the tree
        public void Delete(T element)
        {
            var node = this.Search(element);
            if (node == null)
            {
                throw new ArgumentNullException(String.Format("The element with value={0} is not in the tree!", element));
            }
            else
            {
                if (node.ParentNode != null)
                {
                    if (node.ParentNode.LeftNode != null && node.ParentNode.LeftNode.Value.CompareTo(node.Value) == 0)
                    {
                        node.ParentNode.LeftNode.Value = default(T);
                    }
                    else if (node.ParentNode.RightNode != null && node.ParentNode.RightNode.Value.CompareTo(node.Value) == 0)
                    {
                        node.ParentNode.RightNode.Value = default(T);
                    }
                }
                if (node.LeftNode != null)
                {
                    node.LeftNode.ParentNode.Value = default(T);
                }
                if (node.RightNode != null)
                {
                    node.RightNode.ParentNode.Value = default(T);
                }

                this.Nodes[this.Nodes.IndexOf(node)].Value = default(T);
            }
        }

        // Operator for equal comparison on two trees
        public static bool operator ==(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
        {
            for (int i = 0; i < tree1.Nodes.Count; i++)
            {
                if (tree1.Nodes[i].Value.CompareTo(tree2.Nodes[i].Value) != 0 ||
                    ((tree1.Nodes[i].ParentNode != null) && (tree2.Nodes[i].ParentNode != null) &&
                    (tree1.Nodes[i].ParentNode.Value.CompareTo(tree2.Nodes[i].ParentNode.Value) != 0)) ||
                    ((tree1.Nodes[i].LeftNode != null) && (tree2.Nodes[i].LeftNode != null) &&
                    (tree1.Nodes[i].LeftNode.Value.CompareTo(tree2.Nodes[i].LeftNode.Value) != 0)) ||
                    ((tree1.Nodes[i].RightNode != null) && (tree2.Nodes[i].RightNode != null) &&
                    (tree1.Nodes[i].RightNode.Value.CompareTo(tree2.Nodes[i].RightNode.Value) != 0)))
                {
                    return false;
                }
            }

            return true;
        }

        // Operator for not equal comparison on two trees
        public static bool operator !=(BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
        {
            var result = tree1 == tree2 ? false : true;

            return result;
        }

        // Overrides the standard method ToString
        public override string ToString()
        {
            var result = String.Empty;
            if (this.Nodes.Count > 0)
            {
                result += "{";
                var list = new List<T>();
                foreach (var node in this.Nodes)
                {
                    if (node.Value.CompareTo(default(T)) != 0)
                    {
                        list.Add(node.Value);
                    }
                }

                list.Sort();
                result += string.Join(", ", list) + "}";

                return result;
            }

            return null;
        }

        // Overrides the standard method Equals
        public override bool Equals(object obj)
        {
            try
            {
                if (this == (BinarySearchTree<T>)obj)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        // Overrides the standard method GetHashCode
        public override int GetHashCode()
        {
            var result = this.Nodes.GetHashCode();
            this.Nodes.ForEach(m => result ^= m.GetHashCode());

            return result;
        }

        // Implements ICloneable for deep copy of the tree
        public object Clone()
        {
            var copy = new BinarySearchTree<T>();
            this.Nodes.ForEach(m => copy.Add(m.Value));

            return copy;
        }

        // Implements IEnumerable<T> to traverse the tree
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
