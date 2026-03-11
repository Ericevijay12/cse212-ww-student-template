using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double number, int count)
    {
        // Plan:
        // 1. Create a new array of doubles called 'results' with size 'count'.
        // 2. Loop through the array using a for-loop from index 0 to count-1.
        // 3. For each index, calculate the multiple as: number * (index + 1).
        // 4. Return the 'results' array.

        double[] results = new double[count];
        for (int i = 0; i < count; i++)
        {
            results[i] = number * (i + 1);
        }
        return results;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Return early if the list is empty to avoid errors.
        // 2. Use modulo (%) to ensure 'amount' is within the list bounds.
        // 3. Find the split point: data.Count - effective amount.
        // 4. Use GetRange to copy the end part, then RemoveRange and InsertRange.

        if (data.Count == 0) return;
        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0) return;

        List<int> suffix = data.GetRange(data.Count - effectiveAmount, effectiveAmount);
        data.RemoveRange(data.Count - effectiveAmount, effectiveAmount);
        data.InsertRange(0, suffix);
    }
}
