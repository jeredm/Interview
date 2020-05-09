namespace SortOrder
{
    // This is a pretty fast way to sort and it uses a little more space due to the cost of the call
    // stack. The trade off with a Merge Sort is that this sort uses less space (Merge Sort is O(n) due
    // to the helper it uses to partition the array). In contrast choosing a bad pivot (e.g. index 0
    // of an already sorted list) makes this worst case time complexity and run slower than the Merge Sort.
    //
    // Time Complexity:
    // - Average: O(n log n)
    // - Worst: O(n ^ 2)
    // Space Complexity:
    // - O(log n)
    public class QuickSort
    {
        public void Sort(int[] input)
        {
            if (input is null || input.Length == 0)
                return;
            Sort(input, 0, input.Length - 1);
        }

        private void Sort(int[] input, int left, int right)
        {
            if (left >= right)
                return;
            
            var pivot = input[left + (right - left) / 2];
            var index = ModifyPortion(input, left, right, pivot);
		    Sort(input, left, index - 1);
		    Sort(input, index, right);
        }

        private int ModifyPortion(int[] input, int left, int right, int pivot)
        {
            while(left <= right)
            {
                while(input[left] < pivot)
                    left ++;
                while(input[right] > pivot)
                    right --;
                if (left <= right)
                {
                    Swap(input, left, right);
                    left ++;
                    right --;
                }
            }
            return left;
        }

        private void Swap(int[] input, int left, int right)
        {
            var temp = input[left];
            input[left] = input[right];
            input[right] = temp;
        }
    }
}