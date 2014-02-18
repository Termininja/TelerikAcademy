using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    // The tree
    class BinarySearchTree<T> : ICloneable, IEnumerable<T> where T : IComparable
    {
        #region Properties
        public List<TreeNode<T>> Nodes { get; set; }
        #endregion

        #region Constructors
        public BinarySearchTree()
        {
            this.Nodes = new List<TreeNode<T>>();
        }

        public BinarySearchTree(List<TreeNode<T>> nodes)
        {
            this.Nodes = nodes;
        }
        #endregion

        #region Methods
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
                        throw new ArgumentException(String.Format(
                           "The element with value={0} is already in the tree!", element));
                    }
                    else if (element.CompareTo(node.Value) < 0)
                    {
                        if (node.LeftNode == null)
                        {
                            node.LeftNode = new TreeNode<T>(element);
                            node.LeftNode.ParentNode = node;
                            Nodes.Add(node.LeftNode);
                            break;
                        }
                    }
                    else
                    {
                        if (node.RightNode == null)
                        {
                            node.RightNode = new TreeNode<T>(element);
                            node.RightNode.ParentNode = node;
                            Nodes.Add(node.RightNode);
                            break;
                        }
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
                if (node != null && element.CompareTo(node.Value) == 0) return node;
            }
            return null;
        }

        // Deleting some element in the tree
        public void Delete(T element)
        {
            TreeNode<T> node = this.Search(element);
            if (node == null)
            {
                throw new ArgumentNullException(String.Format(
                    "The element with value={0} is not in the tree!", element));
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
                if (node.LeftNode != null) node.LeftNode.ParentNode.Value = default(T);
                if (node.RightNode != null) node.RightNode.ParentNode.Value = default(T);

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
            if (tree1 == tree2) return false;
            return true;
        }

        // Override the standard method ToString
        public override string ToString()
        {
            string result = String.Empty;
            if (this.Nodes.Count > 0)
            {
                result += "{";
                List<T> list = new List<T>();
                foreach (var node in this.Nodes)
                {
                    if (node.Value.CompareTo(default(T)) != 0)
                    {
                        list.Add(node.Value);
                    }
                }
                list.Sort();
                for (int i = 0; i < list.Count; i++)
                {
                    if (i > 0) result += ", ";
                    result += list[i];
                }
                return result + "}";
            }
            return null;
        }

        // Override the standard method Equals
        public override bool Equals(object obj)
        {
            try
            {
                if (this == (BinarySearchTree<T>)obj) return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        // Override the standard method GetHashCode
        public override int GetHashCode()
        {
            int result = this.Nodes.GetHashCode();
            foreach (var node in this.Nodes)
            {
                result ^= node.GetHashCode();
            }
            return result;
        }

        // Implement ICloneable for deep copy of the tree
        public object Clone()
        {
            BinarySearchTree<T> copy = new BinarySearchTree<T>();
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                copy.Add(this.Nodes[i].Value);
            }
            return copy;
        }

        // Implement IEnumerable<T> to traverse the tree
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
