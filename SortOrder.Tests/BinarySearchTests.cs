using FluentAssertions;
using Xunit;

namespace SortOrder.Tests
{
    public class BinarySearchTests
    {
        [Theory]
        [InlineData(new int[0], -1)]
        [InlineData(new [] { 3 }, 0)]
        [InlineData(new [] { 3, 9, 12, 7 }, 2)]
        [InlineData(new [] { 3, 9, 12, 7, 19, 23, 89, 67 }, 5)]
        public void It_can_search_linearly(int[] input, int desiredIndex)
        {
            var searcher = new BinarySearch();
            var searchValue = desiredIndex < 0 ? 999 : input[desiredIndex];

            var index = searcher.SearchLinear(input, searchValue);

            index.Should().Be(desiredIndex);
        }

        [Theory]
        [InlineData(new [] { 3 }, 0)]
        [InlineData(new [] { 3, 9, 12, 7 }, 2)]
        [InlineData(new [] { 3, 9, 12, 7, 19, 23, 89, 67 }, 5)]
        public void It_can_search_recursively(int[] input, int desiredIndex)
        {
            var searcher = new BinarySearch();

            var index = searcher.SearchRecursive(input, input[desiredIndex], 0, input.Length);

            index.Should().Be(desiredIndex);
        }
    }
}