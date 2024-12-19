using System;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    public void Insert(int value)
    {
        Node newNode = new(value);
        if (_root is null)
        {
            _root = newNode;
        }
        else
        {
            _root.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    // Problem 3: Traverse Backwards
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node != null)
        {
            TraverseBackward(node.Right, values);  // Traverse right first (larger values)
            values.Add(node.Data);
            TraverseBackward(node.Left, values);  // Then left (smaller values)
        }
    }

    // Problem 5: Create Tree from Sorted List
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first <= last)
        {
            int middle = (first + last) / 2;
            bst.Insert(sortedNumbers[middle]);  // Insert the middle element
            InsertMiddle(sortedNumbers, first, middle - 1, bst);  // Insert from the left half
            InsertMiddle(sortedNumbers, middle + 1, last, bst);   // Insert from the right half
        }
    }

    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }

    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node != null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
