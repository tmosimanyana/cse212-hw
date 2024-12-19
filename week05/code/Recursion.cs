using System;
using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n is less than or equal to 0, return 0
        if (n <= 0)
            return 0;
        
        // Recursive case: sum of squares is n^2 + sum of squares for (n-1)
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  
    /// This function should assume that each letter is unique.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if the word reaches the desired size, add it to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: build the word by adding each letter and call recursively
        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(results, letters, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize the remember dictionary if it's null
        remember ??= new Dictionary<int, decimal>();

        // Check if the result for this number of stairs is already computed
        if (remember.ContainsKey(s))
            return remember[s];

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Recursive case: count the ways for s-1, s-2, and s-3 stairs
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);

        // Memoize the result before returning
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Base case: if the pattern has no wildcard, add it to results
        if (!pattern.Contains('*'))
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: replace the first '*' with '0' and '1' and call recursively
        int starIndex = pattern.IndexOf('*');
        WildcardBinary(pattern.Substring(0, starIndex) + '0' + pattern.Substring(starIndex + 1), results);
        WildcardBinary(pattern.Substring(0, starIndex) + '1' + pattern.Substring(starIndex + 1), results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize currPath if it's null
        currPath ??= new List<ValueTuple<int, int>>();

        // Add the current position to the path
        currPath.Add((x, y));

        // Base case: if we are at the end, add the current path to the results
        if (maze.IsEnd(x, y))
        {
            results.Add(string.Join("->", currPath));
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        // Recursive case: explore adjacent cells (right, down, left, up)
        // Try moving right (x+1, y)
        if (maze.IsValidMove(currPath, x + 1, y))
            SolveMaze(results, maze, x + 1, y, currPath);

        // Try moving down (x, y+1)
        if (maze.IsValidMove(currPath, x, y + 1))
            SolveMaze(results, maze, x, y + 1, currPath);

        // Try moving left (x-1, y)
        if (maze.IsValidMove(currPath, x - 1, y))
            SolveMaze(results, maze, x - 1, y, currPath);

        // Try moving up (x, y-1)
        if (maze.IsValidMove(currPath, x, y - 1))
            SolveMaze(results, maze, x, y - 1, currPath);

        // Backtrack: remove the current position from the path before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}
