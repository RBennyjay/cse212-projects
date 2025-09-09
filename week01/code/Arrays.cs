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
        // Step 1: Create an array to hold the multiples
        double[] multiples = new double[length];

        // Step 2: Loop through each index
        for (int i = 0; i < length; i++)
        {
            // Step 3: Compute the multiple (start at 1x number up to length x number)
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the result
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
        // Step 1: Handle trivial case where rotating by the size of the list does nothing
        if (amount == data.Count) return;

        // Step 2: Get the last 'amount' items
        List<int> slice = data.GetRange(data.Count - amount, amount);

        // Step 3: Remove these items from the end
        data.RemoveRange(data.Count - amount, amount);

        // Step 4: Insert them at the beginning
        data.InsertRange(0, slice);
    }
}