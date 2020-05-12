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
            Array.ForEach(expected, x => list.AddValue(x));

            var result = list.GetValues();

            result.Should().ContainInOrder(expected);
        }

        [Fact]
        public void It_can_reset_the_current_node_to_the_head()
        {
            var head = 7;
            var list = new SingleLinkedList<int>();
            list.AddValue(head);
            list.AddValue(28);
            list.AddValue(79);
            var nextOne = list.GetNext();
            var nextTwo = list.GetNext();

            list.Reset();
            var resetOne = list.GetNext();

            resetOne.Should().Be(nextOne);
            resetOne.Should().Be(head);
        }

        [Fact]
        public void It_resets_current_when_adding()
        {
            var initialState = new int[] { 5, 6, 7 };
            var list = new SingleLinkedList<int>();
            Array.ForEach(initialState, x => list.AddValue(x));

            var nextOne = list.GetNext();
            var nextTwo = list.GetNext();
            list.AddValue(9);
            var afterOne = list.GetNext();

            afterOne.Should().Be(nextOne);
        }

        [Theory]
        [InlineData(new int[] { 5, 3, 8 }, new int[] {3, 8}, 5)]
        [InlineData(new int[] { 5, 3, 8 }, new int[] {5, 8}, 3)]
        [InlineData(new int[] { 5, 3, 8 }, new int[] {5, 3}, 8)]
        public void It_can_remove_nodes(int[] initialState, int[] endingState, int valueToRemove)
        {
            var list = new SingleLinkedList<int>();
            Array.ForEach(initialState, x => list.AddValue(x));

            list.RemoveValue(valueToRemove);

            var result = list.GetValues();
            result.Should().ContainInOrder(endingState);
        }

        [Fact]
        public void It_resets_current_when_removing()
        {
            var initialState = new int[] { 5, 6, 2, 9 };
            var list = new SingleLinkedList<int>();
            Array.ForEach(initialState, x => list.AddValue(x));

            var nextOne = list.GetNext();
            var nextTwo = list.GetNext();
            list.RemoveValue(2);
            var afterOne = list.GetNext();

            afterOne.Should().Be(nextOne);
            nextOne.Should().NotBe(nextTwo);
        }
    }
}
