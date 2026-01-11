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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Initialize a fixed-size container (array) that can hold as many 
        // decimal numbers as the 'length' parameter specifies.
        double[] multiples = new double[length];

        // Step 2: Create a loop that starts at 0 and repeats for each slot 
        // available in the array (up to 'length' minus one).
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the current multiple. 
            // Since 'i' starts at 0, add 1 to it (to get 1, 2, 3...) 
            // and multiply it by the starting 'number'.
            // Step 4: Save that result in the current position 'i' of the array.
            multiples[i] = number * (i + 1);
        }

        // Step 5: Send the completed list of multiples back to whoever called this function.
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
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Handle potential error. If the list is empty, there is nothing to rotate.
        if (data.Count == 0) return;

        // Step 2: Get the total number of items in the list (n) and calculate the "real" rotation.
        // Using the remainder operator (%) ensures that if the amount is larger than the list,
        // we only move the necessary number of spaces, avoiding redundant full circles.
        int n = data.Count;
        int effectiveAmount = amount % n;

        // Step 3: If after the calculation the movement is 0, stop here because no changes are needed.
        if (effectiveAmount == 0) return;
        
        // Step 4: Split the list into two parts like a puzzle.

        // First, cut the "tail": these are the elements at the very end that will jump to the front.
        // We start cutting at (total size minus rotation amount).
        List<int> tail = data.GetRange(n - effectiveAmount, effectiveAmount);
        
        // Second, cut the "head": these are the remaining elements from the beginning 
        // that will simply shift to the right.
        List<int> head = data.GetRange(0, n - effectiveAmount);

        // Step 5: Update the original list.

        // First, wipe the list clean to remove the old order.
        data.Clear();

        // Second, put the pieces back together but in reverse order:
        // Add the "tail" first so it appears at the beginning, then add the "head" after it.
        data.AddRange(tail);
        data.AddRange(head);
    }
}
