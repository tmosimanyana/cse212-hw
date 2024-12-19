public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // Problem 1: Insert Unique Values Only
    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value is equal to Data, do nothing (no duplicates allowed)
    }

    // Problem 2: Contains
    public bool Contains(int value)
    {
        if (value < Data)
        {
            return Left?.Contains(value) ?? false;
        }
        else if (value > Data)
        {
            return Right?.Contains(value) ?? false;
        }
        return true; // Found the value
    }

    // Problem 4: Get Height
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
