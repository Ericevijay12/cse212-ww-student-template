using System;

/*
 * Name: Eric Evijay Ohiani
 * Analysis: SortArray Performance
 */

public static class Sorting {
    public static void Run() {
        var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };
        SortArray(numbers);
        Console.Out.WriteLine("int[]{{{0}}}", string.Join(", ", numbers)); //int[]{1, 2, 3, 4, 6, 8, 9}
    }

    /// <summary>
    /// Big O Analysis:
    /// Performance: O(n^2) - Quadratic Time
    /// Reasoning: This function uses nested loops. The outer loop runs 'n' times, 
    /// and for each iteration, the inner loop also runs up to 'n' times. 
    /// As the size of the array (n) grows, the number of operations grows by n * n.
    /// </summary>
    private static void SortArray(int[] data) {
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--) {
            for (var swapPos = 0; swapPos < sortPos; ++swapPos) {
                if (data[swapPos] > data[swapPos + 1]) {
                    (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                }
            }
        }
    }
}
