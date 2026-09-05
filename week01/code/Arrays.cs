using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // PLAN:
        // 1. Create a new double array named 'multiples' with a size equal to the given 'length'.
        // 2. Create a for-loop that starts at index i = 0 and iterates 'length' times (until i < length).
        // 3. Inside the loop, calculate the current multiple. Since array indexes start at 0 but we want
        //    the first multiple to be number * 1, we multiply 'number' by (i + 1).
        // 4. Assign this calculated value to the 'multiples' array at the current index 'i'.
        // 5. Once the loop has finished populating the array, return the 'multiples' array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // PLAN:
        // 1. Check if the list is null or has 1 or fewer items; if so, no rotation is needed.
        // 2. Find the start index of the slice to move to the front: (data.Count - amount).
        // 3. Extract the last 'amount' items using GetRange(startIndex, amount).
        // 4. Remove those items from the end of the list using RemoveRange(startIndex, amount).
        // 5. Insert the extracted items at index 0 using InsertRange(0, endSlice).

        if (data == null || data.Count <= 1 || amount <= 0)
        {
            return;
        }

        int startIndex = data.Count - amount;

        List<int> endSlice = data.GetRange(startIndex, amount);
        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, endSlice);
    }
}