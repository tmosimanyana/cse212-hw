
using System;
using System.Collections.Generic;

public class BinarySearchTree
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    private Node root;

    public BinarySearchTree()
    {
        root = null;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        root = InsertRecursive(root, value);
    }

    private Node InsertRecursive(Node node, int value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value < node.Value)
        {
            node.Left = InsertRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = InsertRecursive(node.Right, value);
        }

        return node;
    }

    // Problem 2: Contains (Search for value)
    public bool Contains(int value)
    {
        return ContainsRecursive(root, value);
    }

    private bool ContainsRecursive(Node node, int value)
    {
        if (node == null)
        {
            return false;
        }

        if (value < node.Value)
        {
            return ContainsRecursive(node.Left, value);
        }
        else if (value > node.Value)
        {
            return ContainsRecursive(node.Right, value);
        }
        else
        {
            return true; // Found the value
        }
    }

    // Problem 3: Traverse Backwards (Reverse Order)
    public List<int> Reverse()
    {
        List<int> result = new List<int>();
        ReverseRecursive(root, result);
        return result;
    }

    private void ReverseRecursive(Node node, List<int> result)
    {
        if (node != null)
        {
            ReverseRecursive(node.Right, result);
            result.Add(node.Value);
            ReverseRecursive(node.Left, result);
        }
    }

    // Problem 4: Tree Height
    public int GetHeight()
    {
        return GetHeightRecursive(root);
    }

    private int GetHeightRecursive(Node node)
    {
        if (node == null)
        {
            return -1;
        }

        int leftHeight = GetHeightRecursive(node.Left);
        int rightHeight = GetHeightRecursive(node.Right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    // Problem 5: Create Tree from Sorted List (Balanced BST)
    public static BinarySearchTree CreateTreeFromSortedList(List<int> sortedList)
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.root = CreateTreeRecursive(sortedList, 0, sortedList.Count - 1);
        return tree;
    }

    private static Node CreateTreeRecursive(List<int> sortedList, int start, int end)
    {
        if (start > end)
        {
            return null;
        }

        int mid = (start + end) / 2;
        Node node = new Node(sortedList[mid]);
        node.Left = CreateTreeRecursive(sortedList, start, mid - 1);
        node.Right = CreateTreeRecursive(sortedList, mid + 1, end);
        return node;
    }

    // Helper function to display tree as string (for testing purposes)
    public string AsString()
    {
        List<int> values = new List<int>();
        InOrderTraversal(root, values);
        return string.Join(", ", values);
    }

    private void InOrderTraversal(Node node, List<int> values)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, values);
            values.Add(node.Value);
            InOrderTraversal(node.Right, values);
        }
    }
}
