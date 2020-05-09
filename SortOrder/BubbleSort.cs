using System;

namespace SortOrder
{
    // In general this is a slow way to sort, but it does not require any extra space. There
    // could be an edge case where you have plenty of time to do the work, but 0 space.
    //
    // Note that the inner loop only needs to check one less set each iteration because the
    // lowest value is always bubbled to the end each iteration.
    // 
    // Time Complexity:
    // - Average: O(n ^ 2)
    // - Worst: O(n ^ 2)
    //
    // Space Complexity:
    // - O(1)
    public class BubbleSort
    {
        public void Sort(int[] input, ShouldSwap shouldSwap)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));
            if (shouldSwap is null)
                throw new ArgumentNullException(nameof(shouldSwap));

            for (int i = 0; i < input.Length - 1; i++)
            {
                // If nothing changes in one iteration, we should stop checking
                var hasSwap = false;
                for(int j = 0; j < input.Length - i - 1; j++)
                {
                    // Using a delegate here just to show a way to allow for differnt sorting directions
                    if (shouldSwap(input[j], input[j + 1]))
                    {
                        Swap(input, j, j + 1);
                        hasSwap = true;
                    }
                }
                if (!hasSwap)
                    break;
            }
        }

        private void Swap(int[] input, int left, int right)
        {
            var temp = input[left];
            input[left] = input[right];
            input[right] = temp;
        }
    }

    // Determines when the values should swap
    public delegate bool ShouldSwap(int left, int right);
}