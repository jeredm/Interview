using FluentAssertions;
using Xunit;

namespace SortOrder.Tests
{
    public class BubbleSortTests
    {
        [Theory]
        [InlineData(new [] { 1, 2, 3 }, new [] { 1, 2, 3 })]
        [InlineData(new [] { 3, -2, 7 }, new [] { -2, 3, 7 })]
        [InlineData(new [] { 1, -7, 3, -2, 7 }, new [] { -7, -2, 1, 3, 7 })]
        [InlineData(new [] { 1, -7, -7, -2, 7 }, new [] { -7, -7, -2, 1, 7 })]
        public void It_can_sort_ascending(int[] input, int[] expected)
        {
            var qs = new BubbleSort();

            qs.Sort(input, (left, right) => { return left > right; });

            input.Should().ContainInOrder(expected);
        }
         
        [Theory]
        [InlineData(new [] { 3, 2, 1 }, new [] { 3, 2, 1 })]
        [InlineData(new [] { 3, -2, 7 }, new [] { 7, 3, -2 })]
        [InlineData(new [] { 1, -7, 3, -2, 7 }, new [] { 7, 3, 1, -2, -7 })]
        [InlineData(new [] { 1, -7, -7, -2, 7 }, new [] { 7, 1, -2, -7, -7 })]
        public void It_can_sort_decending(int[] input, int[] expected)
        {
            var qs = new BubbleSort();

            qs.Sort(input, (left, right) => { return left < right; });

            input.Should().ContainInOrder(expected);
        }
    }
}