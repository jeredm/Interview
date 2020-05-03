// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using FluentAssertions;
using Xunit;

namespace Tree.Tests
{
    public class MinHeightBSTTests
    {
        [Fact]
        public void It_builds_with_min_height()
        {
            var tree = new MinHeightBST(new int[]{ 1, 2, 3 });

            tree.Depth().Should().Be(2);
            tree.Root.Value.Should().Be(2);
        }

        [Fact]
        public void It_builds_with_min_height_when_inputs_are_not_sorted()
        {
            var tree = new MinHeightBST(new int[]{ 2, 1, 3 });

            tree.Depth().Should().Be(2);
            tree.Root.Value.Should().Be(2);
        }

        [Fact]
        public void It_builds_with_min_height_when_there_are_an_even_number_of_inputs()
        {
            var tree = new MinHeightBST(new int[]{ 2, 1, 3, 4 });

            tree.Depth().Should().Be(3);
            tree.Root.Value.Should().Be(2);
        }

        [Fact]
        public void It_builds_with_min_height_with_a_larger_number_of_inputs()
        {
            var tree = new MinHeightBST(new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            //        5
            //      /   \
            //     2     8
            //    / \   / \
            //   1   3 6   9
            //        \ \   \
            //         4 7  10

            tree.Depth().Should().Be(4);
            tree.Root.Value.Should().Be(5);
        } 
    }
}