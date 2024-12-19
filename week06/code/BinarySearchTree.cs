using System;

namespace MyApp.Trees
{
    // Binary Search Tree Node Class
    public class BinarySearchTree
    {
        // Properties for the node's data and its left and right children
        public int Data { get; set; }
        public BinarySearchTree? Left { get; private set; }
        public BinarySearchTree? Right { get; private set; }

        // Constructor to initialize the node with data
        public BinarySearchTree(int data)
        {
            this.Data = data;
        }

        // Insert a new value into the Binary Search Tree (unique values only)
        public void Insert(int value)
        {
            if (value < this.Data)
            {
                if (this.Left is null)
                    this.Left = new BinarySearchTree(value);
                else
                    this.Left.Insert(value);
            }
            else if (value > this.Data)
            {
                if (this.Right is null)
                    this.Right = new BinarySearchTree(value);
                else
                    this.Right.Insert(value);
            }
            // If value is equal to Data, do nothing (no duplicates allowed)
        }

        // Check if a value exists in the Binary Search Tree
        public bool Contains(int value)
        {
            if (value == this.Data)
                return true;

            if (value < this.Data)
                return this.Left?.Contains(value) ?? false;

            return this.Right?.Contains(value) ?? false;
        }

        // Get the height of the Binary Search Tree
        public int GetHeight()
        {
            int leftHeight = this.Left?.GetHeight() ?? 0;
            int rightHeight = this.Right?.GetHeight() ?? 0;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        // In-order traversal: Left, Root, Right
        public void TraverseInOrder()
        {
            this.Left?.TraverseInOrder();
            Console.Write(this.Data + " ");
            this.Right?.TraverseInOrder();
        }

        // Pre-order traversal: Root, Left, Right
        public void TraversePreOrder()
        {
            Console.Write(this.Data + " ");
            this.Left?.TraversePreOrder();
            this.Right?.TraversePreOrder();
        }

        // Post-order traversal: Left, Right, Root
        public void TraversePostOrder()
        {
            this.Left?.TraversePostOrder();
            this.Right?.TraversePostOrder();
            Console.Write(this.Data + " ");
        }
    }
}

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the Binary Search Tree with a root value
            MyApp.Trees.BinarySearchTree tree = new MyApp.Trees.BinarySearchTree(10);

            // Insert values into the tree
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(12);
            tree.Insert(18);

            // Check if certain values are contained in the tree
            Console.WriteLine("Contains 7: " + tree.Contains(7));   // True
            Console.WriteLine("Contains 20: " + tree.Contains(20)); // False

            // Get the height of the tree
            Console.WriteLine("Height of the tree: " + tree.GetHeight());

            // In-order traversal (Left, Root, Right)
            Console.WriteLine("In-order traversal:");
            tree.TraverseInOrder(); // Output: 3 5 7 10 12 15 18
            Console.WriteLine();

            // Pre-order traversal (Root, Left, Right)
            Console.WriteLine("Pre-order traversal:");
            tree.TraversePreOrder(); // Output: 10 5 3 7 15 12 18
            Console.WriteLine();

            // Post-order traversal (Left, Right, Root)
            Console.WriteLine("Post-order traversal:");
            tree.TraversePostOrder(); // Output: 3 7 5 12 18 15 10
            Console.WriteLine();
        }
    }
}
