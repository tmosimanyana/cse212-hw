using System;

namespace MyApp.Trees
{
    public class BinarySearchTree
    {
        public int Data { get; set; }
        public BinarySearchTree? Left { get; private set; }
        public BinarySearchTree? Right { get; private set; }

        public BinarySearchTree(int data)
        {
            this.Data = data;
        }

        public BinarySearchTree()
        {
        }

        // Insert Unique Values Only
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
        }

        // Check if a value exists
        public bool Contains(int value)
        {
            if (value == this.Data)
                return true;

            if (value < this.Data)
                return this.Left?.Contains(value) ?? false;

            return this.Right?.Contains(value) ?? false;
        }

        // Traverse Backwards (Right, Root, Left)
        public void TraverseBackwards()
        {
            this.Right?.TraverseBackwards();
            Console.Write(this.Data + " ");
            this.Left?.TraverseBackwards();
        }

        // Get Tree Height
        public int GetHeight()
        {
            int leftHeight = this.Left?.GetHeight() ?? 0;
            int rightHeight = this.Right?.GetHeight() ?? 0;
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        // Create Tree from Sorted List
        public static BinarySearchTree CreateFromSortedList(int[] sortedList)
        {
            return CreateFromSortedListHelper(sortedList, 0, sortedList.Length - 1);
        }

        private static BinarySearchTree? CreateFromSortedListHelper(int[] sortedList, int start, int end)
        {
            if (start > end)
                return null;

            int mid = (start + end) / 2;
            BinarySearchTree node = new BinarySearchTree(sortedList[mid]);

            node.Left = CreateFromSortedListHelper(sortedList, start, mid - 1);
            node.Right = CreateFromSortedListHelper(sortedList, mid + 1, end);

            return node;
        }
    }
}

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Binary Search Tree
            Trees.BinarySearchTree tree = new Trees.BinarySearchTree(10);
            tree.Insert(5);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(12);
            tree.Insert(18);

            // Problem 2 - Contains
            Console.WriteLine("Contains 7: " + tree.Contains(7));   // True
            Console.WriteLine("Contains 20: " + tree.Contains(20)); // False

            // Problem 3 - Traverse Backwards
            Console.WriteLine("Traverse Backwards:");
            tree.TraverseBackwards(); // 18 15 12 10 7 5 3
            Console.WriteLine();

            // Problem 4 - Tree Height
            Console.WriteLine("Height of the tree: " + tree.GetHeight());

            // Problem 5 - Create Tree from Sorted List
            int[] sortedList = { 1, 2, 3, 4, 5, 6, 7 };
            Trees.BinarySearchTree balancedTree = Trees.BinarySearchTree.CreateFromSortedList(sortedList);
            Console.WriteLine("In-order Traversal of Balanced Tree:");
            balancedTree.TraverseBackwards();
            Console.WriteLine();
        }
    }
}
