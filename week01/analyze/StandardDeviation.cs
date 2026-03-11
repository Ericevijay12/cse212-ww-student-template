using System;
using System.Linq;

/*
 * Name: Eric Evijay Ohiani
 * Analysis: StandardDeviation Performance Comparison
 */

public static class StandardDeviation {
    public static void Run() {
        var numbers = new[] { 600, 470, 170, 430, 300 };
        Console.WriteLine(StandardDeviation1(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation2(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation3(numbers)); // Should be 147.322 
    }

    /// <summary>
    /// Big O Analysis: O(n) - Linear Time
    /// Reasoning: This function uses two separate loops. First to find the total, 
    /// then to find the squared differences. O(n) + O(n) simplifies to O(n).
    /// </summary>
    private static double StandardDeviation1(int[] numbers) {
        var total = 0.0;
        var count = 0;
        foreach (var number in numbers) {
            total += number;
            count += 1;
        }

        var avg = total / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }

    /// <summary>
    /// Big O Analysis: O(n^2) - Quadratic Time
    /// Reasoning: This is inefficient because it contains a nested loop. 
    /// For every number in the list, it loops through the entire list again 
    /// to calculate the average. This results in n * n operations.
    /// </summary>
    private static double StandardDeviation2(int[] numbers) {
        var sumSquaredDifferences = 0.0;
        var countNumbers = 0;
        foreach (var number in numbers) {
            var total = 0;
            var count = 0;
            // NESTED LOOP HERE makes it O(n^2)
            foreach (var value in numbers) {
                total += value;
                count += 1;
            }

            var avg = total / count;
            sumSquaredDifferences += Math.Pow(number - avg, 2);
            countNumbers += 1;
        }

        var variance = sumSquaredDifferences / countNumbers;
        return Math.Sqrt(variance);
    }

    /// <summary>
    /// Big O Analysis: O(n) - Linear Time
    /// Reasoning: Similar to version 1, this uses the built-in Sum() method 
    /// (which is O(n)) followed by one loop. O(n) + O(n) = O(n).
    /// </summary>
    private static double StandardDeviation3(int[] numbers) {
        var count = numbers.Length;
        var avg = (double)numbers.Sum() / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }
}
