using System;

public class Node
{
    public int Data { get; set; }
    public Node? Left { get; private set; }
    public Node? Right { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (no duplicates allowed)
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
            return Left?.Contains(value) ?? false;

        return Right?.Contains(value) ?? false;
    }

    // Problem 4: Tree Height
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }

    // Helper method for Traverse Backwards (used by BinarySearchTree)
    public void TraverseBackward(Action<int> action)
    {
        Right?.TraverseBackward(action);
        action(Data);
        Left?.TraverseBackward(action);
    }
}
