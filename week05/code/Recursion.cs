using System.Collections.Generic;
using System;
using System.Linq;

public static class Recursion
{
    /// <summary>
    /// Problem 1: sum of 1^2 + 2^2 + ... + n^2
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        if (n == 1)
            return 1;
        
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations of length 'size'
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base Case: If the word is the target size, we are done
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive Step: Try adding each available letter
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: Climbing stairs with Memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s < 0) return 0;
        if (s == 0) return 1; // Reached the top

        // Check Memoization
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion and store in dictionary
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);
        
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base Case: No more wildcards
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive Step: Replace '*' with '0' and '1'
        string zeroPattern = pattern[..index] + "0" + pattern[(index + 1)..];
        string onePattern = pattern[..index] + "1" + pattern[(index + 1)..];

        WildcardBinary(zeroPattern, results);
        WildcardBinary(onePattern, results);
    }

    /// <summary>
    /// Problem 5: Solve Maze
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Add current position to path
        currPath.Add((x, y));

        // Base Case: If we found the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Recursive Step: Try Right, Left, Down, Up
            int[] dx = { 1, -1, 0, 0 };
            int[] dy = { 0, 0, 1, -1 };

            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                if (maze.IsValidMove(currPath, newX, newY))
                {
                    SolveMaze(results, maze, newX, newY, currPath);
                }
            }
        }

        // Backtrack: Remove current position before returning
        currPath.RemoveAt(currPath.Count - 1);
    }
}
