// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using FluentAssertions;
using Xunit;

namespace SortOrder.Tests
{
    public class QuickSortTests
    {
        [Theory]
        [InlineData(new [] { 1, 2, 3 }, new [] { 1, 2, 3 })]
        [InlineData(new [] { 3, -2, 7 }, new [] { -2, 3, 7 })]
        [InlineData(new [] { 1, -7, 3, -2, 7 }, new [] { -7, -2, 1, 3, 7 })]
        [InlineData(new [] { 1, -7, -7, -2, 7 }, new [] { -7, -7, -2, 1, 7 })]
        public void It_can_sort_accurately(int[] input, int[] expected)
        {
            var qs = new QuickSort();

            qs.Sort(input);

            input.Should().ContainInOrder(expected);
        }
    }
}
