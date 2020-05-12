// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using FluentAssertions;
using System;
using Xunit;

namespace DataStructureMisc.Tests
{
    public class SingleLinkListTests
    {
        [Theory]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { 1, 7, 3, 9 })]
        [InlineData(new int[] { 9, 7, 9 })]
        public void It_gets_values_in_the_right_order(int[] expected)
        {
            var list = new SingleLinkedList<int>();
            Array.ForEach(expected, x => list.Add(x));

            var result = list.GetValues();

            result.Should().ContainInOrder(expected);
        }
    }
}
