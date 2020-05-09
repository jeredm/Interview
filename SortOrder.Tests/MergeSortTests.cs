using FluentAssertions;
using Xunit;

namespace SortOrder.Tests
{
    public class MergeSortTests
    {
        [Theory]
        [InlineData(new [] { 1, 2, 3 }, new [] { 1, 2, 3 })]
        [InlineData(new [] { 3, -2, 7 }, new [] { -2, 3, 7 })]
        [InlineData(new [] { 1, -7, 3, -2, 7 }, new [] { -7, -2, 1, 3, 7 })]
        [InlineData(new [] { 1, -7, -7, -2, 7 }, new [] { -7, -7, -2, 1, 7 })]
        public void It_can_sort_accurately(int[] input, int[] expected)
        {
            var ms = new MergeSort();

            ms.Sort(input);

            input.Should().ContainInOrder(expected);
        }
    }
}