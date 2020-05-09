using System;

namespace SortOrder
{
    // This is a consitantly fast way to sort; however, it does consume more memory to store the intermediate
    // values in the helper array. See QuickSort.cs for more details on the trade offs.
    //
    // Time Complexity:
    // - Average: O(n log n)
    // - Worst: O(n log n)
    // Space Complexity:
    // - O(n)
    public class MergeSort
    {
        public void Sort(int[] input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));
            var helper = new int[input.Length];
            Sort(input, helper, 0, input.Length - 1);
        }

        private void Sort(int[] input, int[] helper, int left, int right)
        {
            if (left < right)
            {
                var mid = (left + right) / 2;
                Sort(input, helper, left, mid);
                Sort(input, helper, mid + 1, right);
                Merge(input, helper, left, mid, right);
            }
        }

        private void Merge(int[] input, int[] helper, int left, int mid, int right)
        {
            for (var i = left; i <= right; i++)
            {
                helper[i] = input[i];
            }

            var helperLeft = left;
            var helperRight = mid + 1;
            var current = left;

            while(helperLeft <= mid && helperRight <= right)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    input[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    input[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            var leftover = mid - helperLeft;
            for (var i = 0; i <= leftover; i++)
            {
                input[current + i] = helper[helperLeft + i];
            }
        }
    }
}