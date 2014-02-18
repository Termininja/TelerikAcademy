/* Task 06*. Define the data binary search tree with operations for
 *           "adding new element", "searching element" and "deleting elements".
 *           It is not necessary to keep the tree balanced.
 *           
 *           Implement the standard methods from System.Object – ToString(), Equals(…),
 *           GetHashCode() and the operators for comparison == and !=. Add and implement
 *           the ICloneable interface for deep copy of the tree.
 *           
 *           Remark: Use two types – class BinarySearchTree (for the tree) and structure
 *           TreeNode (for the tree elements). Implement IEnumerable<T> to traverse the tree.
 */

using System;
using System.Threading;

namespace BinarySearchTree
{
    class Program
    {
        static void Main()
        {
            try
            {
                #region Test1: Creating of nodes
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Test1: Creating of nodes");
                Console.ResetColor();
                Console.Write("Press any key to start the test...");
                Console.ReadKey();

                // Create new empty tree
                BinarySearchTree<int> tree = new BinarySearchTree<int>();
                Console.WriteLine("\n\nA new tree was created...");

                // Add some nodes in the tree
                Thread.Sleep(1500);
                tree.Add(2);
                tree.Add(7);
                tree.Add(1);
                tree.Add(5);
                tree.Add(22);
                tree.Add(-7);
                tree.Add(4);
                Console.WriteLine("{0} nodes were added in the tree.\n", tree.Nodes.Count);

                // Print the tree
                Thread.Sleep(1500);
                Console.Write("The tree: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(tree);
                Console.ResetColor();

                // Print the nodes of the tree
                Thread.Sleep(1500);
                for (int i = 0; i < tree.Nodes.Count; i++)
                {
                    Console.Write("Node{0}: ", i);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("{0}", tree.Nodes[i]);
                    Console.ResetColor();
                    Thread.Sleep(400);
                }
                #endregion

                #region Test2: Searching
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTest2: Searching");
                Console.ResetColor();
                Console.Write("Press any key to start the test...");
                Console.ReadKey();

                // Search for some node in the tree
                Console.WriteLine();
                Search(tree, 2);
                Search(tree, 7);
                Search(tree, 14);
                Search(tree, 22);
                #endregion

                #region Test3: Cloning
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTest3: Cloning");
                Console.ResetColor();
                Console.Write("Press any key to start the test...");
                Console.ReadKey();

                // Cloning of tree
                BinarySearchTree<int> clone = tree.Clone() as BinarySearchTree<int>;
                Console.WriteLine("\n\nA clone was created...");

                // Print the clone
                Thread.Sleep(1500);
                Console.Write("The clone: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(clone);
                Console.ResetColor();

                // Cloning check
                CloningCheck(tree, clone, false);
                #endregion

                #region Test4: Deleting
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTest4: Deleting");
                Console.ResetColor();
                Console.Write("Press any key to start the test...");
                Console.ReadKey();

                // Delete two nodes from the tree
                tree.Delete(2);
                tree.Delete(5);
                Console.WriteLine("\n\nTwo nodes with value 2 and 5 were deleted from the tree.");

                // Print the tree
                Thread.Sleep(1500);
                Console.Write("\nThe tree: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(tree);
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Write("The clone: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(clone);
                Console.ResetColor();

                // Cloning check
                CloningCheck(tree, clone, true);

                // Get HashCode for the tree
                Thread.Sleep(1500);
                Console.WriteLine("\nThe HashCode for the tree: {0}", tree.GetHashCode());

                // Get HashCode for the clone
                Thread.Sleep(1000);
                Console.WriteLine("The HashCode for the clone: {0}\n", clone.GetHashCode());
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Check the cloning on some tree
        private static void CloningCheck(BinarySearchTree<int> tree, BinarySearchTree<int> clone, bool b)
        {
            Thread.Sleep(1500);
            Console.WriteLine("\nCloning check...{0,18}== test{0,8}!= test{0,8}Equal test", " ");
            Console.Write("{0}", (b) ? "The cloning after deletion is: " : "The cloning is: ");
            Thread.Sleep(1500);
            if (tree == clone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (b) Console.Write("{0,10}", "OK");
                else Console.Write("{0,25}", "OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (b) Console.Write("{0,10}", " X");
                else Console.Write("{0,25}", " X");
            }
            Thread.Sleep(1000);
            if (!(tree != clone))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0,15}", "OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0,15}", " X");
            }
            Thread.Sleep(1000);
            if (tree.Equals(clone))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,18}", "OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0,18}", " X");
            }
            Console.ResetColor();
        }

        // Search for some node in the tree
        private static void Search(BinarySearchTree<int> tree, int num)
        {
            Thread.Sleep(1000);
            int value3 = num;
            TreeNode<int> search3 = tree.Search(value3);
            if (search3 != null)
            {
                Console.WriteLine("\nNode with value:{0} was found in the tree.", value3);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0,7}{1}", " ", search3);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("\nNode with value:{0} was not found in the tree.", value3);
                Console.ResetColor();
            }
        }
    }
}