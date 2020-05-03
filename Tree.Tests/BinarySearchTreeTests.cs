// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

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

            tree.Count.Should().Be(6);
        }

        [Fact]
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

            //       7
            //      /
            //     3
            //    / \
            //   2   4
            //  /     \
            // 1       6
            //        /
            //       5

            int height = tree.Depth();

            height.Should().Be(5);
        }

        [Fact]
        public void It_can_remove_a_node_with_two_children()
        {
            var tree = new BinarySearchTree();
            tree.Add(9);
            tree.Add(10);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);

            //       9
            //      / \
            //     7   10
            //    / \ 
            //   6   8  
            //  /
            // 4

            tree.Remove(7);

            //       9
            //      / \
            //     8   10
            //    /
            //   6
            //  /
            // 4

            tree.Count.Should().Be(5);
            tree.Find(7).Should().BeNull();
        }

        [Fact]
        public void It_can_remove_both_classes_of_children()
        {
            var tree = new BinarySearchTree();
            tree.Add(9);
            tree.Add(10);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);

            //       9
            //      / \
            //     7   10
            //    / \ 
            //   6   8  
            //  /
            // 4

            tree.Remove(6);
            tree.Remove(9);

            //       8
            //      / \
            //     7   10
            //    /
            //   4

            tree.Count.Should().Be(4);
            tree.Find(6).Should().BeNull();
            tree.Find(9).Should().BeNull();
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

        [Fact]
        public void Removing_an_invalid_node_is_a_noop()
        {
            var tree = new BinarySearchTree();
            tree.Add(13);

            tree.Remove(5);

            tree.Count.Should().Be(1);
        }

        [Fact]
        public void It_can_traverse_in_pre_order()
        {
            var tree = new BinarySearchTree();
            tree.Add(9);
            tree.Add(10);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);

            var expectedOrder = new [] { 9, 7, 6, 4, 8, 10 };

            //       9
            //      / \
            //     7   10
            //    / \ 
            //   6   8  
            //  /
            // 4

            var results = tree.TraverseRootLeftRight();

            results.Should().ContainInOrder(expectedOrder);
        }

        [Fact]
        public void It_can_traverse_in_order()
        {
            var tree = new BinarySearchTree();
            tree.Add(9);
            tree.Add(10);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);

            var expectedOrder = new [] { 4, 6, 7, 8, 9, 10 };

            //       9
            //      / \
            //     7   10
            //    / \ 
            //   6   8  
            //  /
            // 4

            var results = tree.TraverseLeftRootRight();

            results.Should().ContainInOrder(expectedOrder);
        }

        [Fact]
        public void It_can_traverse_in_post_order()
        {
            var tree = new BinarySearchTree();
            tree.Add(9);
            tree.Add(10);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);

            var expectedOrder = new [] { 4, 6, 8, 7, 10, 9 };

            //       9
            //      / \
            //     7   10
            //    / \ 
            //   6   8  
            //  /
            // 4

            var results = tree.TraverseLeftRightRoot();

            results.Should().ContainInOrder(expectedOrder);
        }

        [Fact]
        public void It_can_traverse_in_level_order()
        {
            var tree = new BinarySearchTree();
            tree.Add(9);
            tree.Add(10);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);

            var expectedOrder = new [] { 9, 7, 10, 6, 8, 4 };

            //       9
            //      / \
            //     7   10
            //    / \ 
            //   6   8  
            //  /
            // 4

            var results = tree.TraverseBreadthFirst();

            results.Should().ContainInOrder(expectedOrder);
        }
    }
}
