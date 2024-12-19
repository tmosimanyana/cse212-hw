using System;

public class Node
{
    public int Data { get; set; }
    public Node? Left { get; private set; } // Nullable reference type
    public Node? Right { get; private set; } // Nullable reference type

    // Constructor initializes Data, Left and Right are nullable (null by default)
    public Node(int data)
    {
        this.Data = data;
        Left = null; // Explicitly set to null
        Right = null; // Explicitly set to null
    }

    // Insert method to add a new value to the tree
    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value); // Create new node if left is null
            else
                Left.Insert(value); // Recursively insert in the left subtree
        }
        else
        {
            if (Right == null)
                Right = new Node(value); // Create new node if right is null
            else
                Right.Insert(value); // Recursively insert in the right subtree
        }
    }

    // Method to check if a value exists in the tree
    public bool Contains(int value)
    {
        if (value == Data)
            return true; // Value found

        if (value < Data)
            return Left?.Contains(value) ?? false; // Safe handling for Left being null

        return Right?.Contains(value) ?? false; // Safe handling for Right being null
    }

    // Method to get the height of the tree
    public int GetHeight()
    {
        // Handle null values for Left and Right subtrees using null-coalescing operator
        int leftHeight = Left?.GetHeight() ?? 0; // If Left is null, return 0
        int rightHeight = Right?.GetHeight() ?? 0; // If Right is null, return 0

        return 1 + Math.Max(leftHeight, rightHeight); // 1 + max height of left or right subtree
    }

    // Method to traverse the tree in-order (Left, Root, Right)
    public void TraverseInOrder()
    {
        Left?.TraverseInOrder(); // Traverse left subtree if it exists
        Console.Write(Data + " "); // Visit the current node
        Right?.TraverseInOrder(); // Traverse right subtree if it exists
    }

    // Method to traverse the tree in pre-order (Root, Left, Right)
    public void TraversePreOrder()
    {
        Console.Write(Data + " "); // Visit the current node
        Left?.TraversePreOrder(); // Traverse left subtree if it exists
        Right?.TraversePreOrder(); // Traverse right subtree if it exists
    }

    // Method to traverse the tree in post-order (Left, Right, Root)
    public void TraversePostOrder()
    {
        Left?.TraversePostOrder(); // Traverse left subtree if it exists
        Right?.TraversePostOrder(); // Traverse right subtree if it exists
        Console.Write(Data + " "); // Visit the current node
    }
}

public class BinaryTree
{
    public Node? Root { get; private set; }

    // Method to insert a value into the tree
    public void Insert(int value)
    {
        if (Root == null)
            Root = new Node(value); // Create the root node if the tree is empty
        else
            Root.Insert(value); // Insert the value into the tree starting from the root
    }

    // Method to check if the tree contains a value
    public bool Contains(int value)
    {
        return Root?.Contains(value) ?? false; // Return false if the root is null
    }

    // Method to get the height of the tree
    public int GetHeight()
    {
        return Root?.GetHeight() ?? 0; // Return 0 if the root is null
    }

    // Method to traverse the tree in order
    public void TraverseInOrder()
    {
        if (Root != null)
            Root.TraverseInOrder(); // Traverse the tree starting from the root
    }

    // Method to traverse the tree in pre-order
    public void TraversePreOrder()
    {
        if (Root != null)
            Root.TraversePreOrder(); // Traverse the tree starting from the root
    }

    // Method to traverse the tree in post-order
    public void TraversePostOrder()
    {
        if (Root != null)
            Root.TraversePostOrder(); // Traverse the tree starting from the root
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Example usage
        BinaryTree tree = new BinaryTree();

        // Insert values into the tree
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(12);
        tree.Insert(18);

        // Check if a value is contained in the tree
        Console.WriteLine("Contains 7: " + tree.Contains(7)); // True
        Console.WriteLine("Contains 20: " + tree.Contains(20)); // False

        // Get the height of the tree
        Console.WriteLine("Height of the tree: " + tree.GetHeight());

        // In-order traversal (Left, Root, Right)
        Console.WriteLine("In-order traversal: ");
        tree.TraverseInOrder(); // 3 5 7 10 12 15 18
        Console.WriteLine();

        // Pre-order traversal (Root, Left, Right)
        Console.WriteLine("Pre-order traversal: ");
        tree.TraversePreOrder(); // 10 5 3 7 15 12 18
        Console.WriteLine();

        // Post-order traversal (Left, Right, Root)
        Console.WriteLine("Post-order traversal: ");
        tree.TraversePostOrder(); // 3 7 5 12 18 15 10
        Console.WriteLine();
    }
}
