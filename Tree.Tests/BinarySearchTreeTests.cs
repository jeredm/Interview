// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tree.Tests
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void The_first_value_becomes_the_root()
        {
            var tree = new BinarySearchTree();

            tree.Add(5);

            tree.Root.Value.Should().Be(5);
        }

        [Fact]
        public void It_finds_the_value_when_the_value_exists()
        {
            var tree = new BinarySearchTree();
            tree.Add(28);
            tree.Add(1);
            tree.Add(5);
            tree.Add(9);
            tree.Add(8);

            var node = tree.Find(5);

            node.Value.Should().Be(5);
        }

        [Fact]
        public void Find_returns_null_when_a_value_cannot_be_found()
        {
            var tree = new BinarySearchTree();

            var node = tree.Find(5);

            node.Should().BeNull();
        }

        [Fact]
        public void It_counts_the_current_number_of_nodes()
        {
            var tree = new BinarySearchTree();

            tree.Add(28);
            tree.Add(1);
            tree.Add(5);
            tree.Add(9);
            tree.Add(9);
            tree.Add(8);

            tree.Count.Should().Be(5);
        }

        [Fact(Skip="broken for now")]
        public void It_knows_its_depth()
        {
            var tree = new BinarySearchTree();
            tree.Add(7);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(4);
            tree.Add(6);
            tree.Add(5);

            //      7
            //      /\
            //     3  4
            //    /    \
            //   2      6
            //  /       /
            // 1       5

            int depth = tree.Depth();

            depth.Should().Be(4);
        }

        [Fact(Skip = "Need a structure where there are to children")]
        public void It_can_remove_a_node_with_two_children()
        {
            var tree = new BinarySearchTree();
            tree.Add(7);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(4);
            tree.Add(6);
            tree.Add(5);

            // FIXME: wrong structure
            // FIXME: Need two children like this shows
            //      7
            //      /\
            //     3  4
            //    /   /\
            //   2   5  6
            //  /
            // 1

            tree.Remove(4);

            //      7
            //      /
            //     3
            //    / \ 
            //   2   6
            //  /   /
            // 1   5

            tree.Count.Should().Be(6);
            tree.Find(4).Should().BeNull();
        }

        [Fact]
        public void It_can_remove_the_root_node()
        {
            var tree = new BinarySearchTree();
            tree.Add(7);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(4);
            tree.Add(6);
            tree.Add(5);

            //      7
            //      /
            //     3
            //    / \
            //   2   4
            //  /     \
            // 1       6
            //        /
            //       5

            tree.Remove(7);

            //       3
            //      / \
            //     2   4
            //    /     \
            //   1       6
            //           /
            //          5

            tree.Count.Should().Be(6);
            tree.Find(7).Should().BeNull();
            tree.Root.Value.Should().Be(3);
        }

        [Fact]
        public void It_can_remove_a_node_with_one_child()
        {
            var tree = new BinarySearchTree();
            tree.Add(7);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(4);
            tree.Add(6);
            tree.Add(5);

            //       7
            //      /
            //     3
            //    / \
            //   2   4
            //  /     \
            // 1       6
            //        /
            //       5

            tree.Remove(3);

            //       7
            //      /\
            //     2  4
            //    /    \
            //   1      6
            //         /
            //        5

            tree.Count.Should().Be(6);
            tree.Find(3).Should().BeNull();
        }

        // TODO: Verify two removes in a row

        [Fact]
        public void Removing_an_invalid_node_is_a_noop()
        {
            var tree = new BinarySearchTree();
            tree.Add(13);

            tree.Remove(5);

            tree.Count.Should().Be(1);
        }

        // TODO: Verify pre order traversal
        // TODO: Verify in order traversal
        // TODO: Verify post order traversal

        [Fact]
        public void PrintTree()
        {
            // TODO: Remove when done testing
            var tree = new BinarySearchTree();
            tree.Add(7);
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(4);
            tree.Add(6);
            tree.Add(5);

            //      7
            //      /
            //     3
            //    / \
            //   2   4
            //  /     \
            // 1       6
            //        /
            //       5

            Printer.Print(tree.PrintRootLeftRight());
            Printer.Print(tree.PrintLeftRootRight());
            Printer.Print(tree.PrintLeftRightRoot()); 
        }

        private class Printer
        {
            public static void Print(List<int> values)
            {
                Console.WriteLine(string.Join(",", values.Select(x => x.ToString()).ToArray()));
                Console.WriteLine("");
            }
        }
    }
}
