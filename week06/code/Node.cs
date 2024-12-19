using System;

public class Node
{
    public int Data { get; set; }
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public Node(int data)
    {
        this.Data = data;
        Left = null;
        Right = null;
    }

    // Insert Unique Values Only
    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value is equal to Data, do nothing (no duplicates allowed)
    }

    // Check if a Value Exists in the Tree
    public bool Contains(int value)
    {
        if (value < Data)
            return Left?.Contains(value) ?? false;
        else if (value > Data)
            return Right?.Contains(value) ?? false;
        return true; // Found the value
    }

    // Get the Height of the Tree
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return Math.Max(leftHeight, rightHeight) + 1;
    }

    // In-order Traversal (Left, Root, Right)
    public void TraverseInOrder()
    {
        Left?.TraverseInOrder();
        Console.Write($"{Data} ");
        Right?.TraverseInOrder();
    }

    // Pre-order Traversal (Root, Left, Right)
    public void TraversePreOrder()
    {
        Console.Write($"{Data} ");
        Left?.TraversePreOrder();
        Right?.TraversePreOrder();
    }

    // Post-order Traversal (Left, Right, Root)
    public void TraversePostOrder()
    {
        Left?.TraversePostOrder();
        Right?.TraversePostOrder();
        Console.Write($"{Data} ");
    }

    // Find the Minimum Value in the Subtree
    public int FindMin()
    {
        return Left?.FindMin() ?? Data;
    }

    // Find the Maximum Value in the Subtree
    public int FindMax()
    {
        return Right?.FindMax() ?? Data;
    }

    // Delete a Node with the Given Value
    public Node? Delete(int value)
    {
        if (value < Data)
        {
            if (Left != null)
                Left = Left.Delete(value);
        }
        else if (value > Data)
        {
            if (Right != null)
                Right = Right.Delete(value);
        }
        else
        {
            // Node to delete found
            if (Left == null) return Right;
            if (Right == null) return Left;

            // Node with two children: Replace with the minimum value in the right subtree
            Data = Right.FindMin();
            Right = Right.Delete(Data);
        }
        return this;
    }
}

public class BinaryTree
{
    public Node? Root { get; private set; }

    // Insert a Value into the Tree
    public void Insert(int value)
    {
        if (Root == null)
            Root = new Node(value);
        else
            Root.Insert(value);
    }

    // Check if the Tree Contains a Value
    public bool Contains(int value)
    {
        return Root?.Contains(value) ?? false;
    }

    // Get the Height of the Tree
    public int GetHeight()
    {
        return Root?.GetHeight() ?? 0;
    }

    // In-order Traversal
    public void TraverseInOrder()
    {
        if (Root != null)
        {
            Root.TraverseInOrder();
            Console.WriteLine();
        }
    }

    // Pre-order Traversal
    public void TraversePreOrder()
    {
        if (Root != null)
        {
            Root.TraversePreOrder();
            Console.WriteLine();
        }
    }

    // Post-order Traversal
    public void TraversePostOrder()
    {
        if (Root != null)
        {
            Root.TraversePostOrder();
            Console.WriteLine();
        }
    }

    // Find the Minimum Value in the Tree
    public int? FindMin()
    {
        if (Root == null) return null;
        return Root.FindMin();
    }

    // Find the Maximum Value in the Tree
    public int? FindMax()
    {
        if (Root == null) return null;
        return Root.FindMax();
    }

    // Delete a Value from the Tree
    public void Delete(int value)
    {
        if (Root != null)
            Root = Root.Delete(value);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        // Insert values into the tree
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(18);

        // Display the tree traversals
        Console.WriteLine("In-order Traversal:");
        tree.TraverseInOrder(); // Output: 3 5 7 10 12 15 18

        Console.WriteLine("Pre-order Traversal:");
        tree.TraversePreOrder(); // Output: 10 5 3 7 15 12 18

        Console.WriteLine("Post-order Traversal:");
        tree.TraversePostOrder(); // Output: 3 7 5 12 18 15 10

        // Check if specific values exist
        Console.WriteLine("Contains 7: " + tree.Contains(7));   // Output: True
        Console.WriteLine("Contains 20: " + tree.Contains(20)); // Output: False

        // Get the height of the tree
        Console.WriteLine("Height of the Tree: " + tree.GetHeight()); // Output: 3

        // Find minimum and maximum values
        Console.WriteLine("Minimum Value: " + tree.FindMin()); // Output: 3
        Console.WriteLine("Maximum Value: " + tree.FindMax()); // Output: 18

        // Delete a value and show in-order traversal again
        tree.Delete(5);
        Console.WriteLine("In-order Traversal After Deleting 5:");
        tree.TraverseInOrder(); // Output: 3 7 10 12 15 18
    }
}
