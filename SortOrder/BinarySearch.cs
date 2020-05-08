namespace SortOrder
{
    public class BinarySearch
    {
        public int SearchLinear(int[] input, int desiredValue)
        {
            if (input is null)
                return -1;

            int low = 0;
            int high = input.Length - 1;
            int mid = 0;
        
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (input[mid] < desiredValue)
                    low = mid + 1;
                else if (input[mid] > desiredValue)
                    high = mid - 1;
                else
                    return mid;
            }

            return -1;
        }

        public int SearchRecursive(int[] input, int desiredValue, int low, int high)
        {
            if (input is null || low > high)
                return -1;
            
            int mid = (low + high) / 2;
            if (input[mid] < desiredValue)
                return SearchRecursive(input, desiredValue, mid + 1, high);
            else if (input[mid] > desiredValue)
                return SearchRecursive(input, desiredValue, low, mid - 1);
            else
                return mid;
        }
    }
}