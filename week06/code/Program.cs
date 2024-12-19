
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test: Insertion and Contains
        BinarySearchTree bst = new BinarySearchTree();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(3);
        bst.Insert(7);
        bst.Insert(12);
        bst.Insert(18);

        Console.WriteLine("BST In-Order: " + bst.AsString());
        Console.WriteLine("Contains 10: " + bst.Contains(10));
        Console.WriteLine("Contains 20: " + bst.Contains(20));

        // Test: Reverse Traversal
        List<int> reverseOrder = bst.Reverse();
        Console.WriteLine("Reverse Order: " + string.Join(", ", reverseOrder));

        // Test: Tree Height
        Console.WriteLine("Tree Height: " + bst.GetHeight());

        // Test: Create Tree from Sorted List
        List<int> sortedList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        BinarySearchTree balancedBst = BinarySearchTree.CreateTreeFromSortedList(sortedList);
        Console.WriteLine("Balanced BST In-Order: " + balancedBst.AsString());
    }
}
