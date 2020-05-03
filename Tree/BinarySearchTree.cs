// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.Collections.Generic;

namespace Tree
{
    // This is a BinarySearchTree:
    // - There is a maximum of two children per parent
    // - The left node is always less than the right node
    //
    // Implementation Notes:
    // - This tree assumes duplicates are invalid and false is returned when a duplicate is added.
    //   Duplicates could be allowed by adding a Count to the Node class and incrementing the count.
    // - This tree uses an Integer for the value, but we could implement the same thing using Comparable.
    //   In that case, we could Compare each node instead of checking the value of an int.
    // 
    // Depth First Traversal:
    // - Pre Order traversal: Visit the parent first and then left and then right children;
    // - In Order traversal: Visit the left child, then the parent and then the right child;
    // - Post Order traversal: Visit left child, then the right child and then the parent;
    //
    // BreadthFirst Traversal:
    // - Level Order traversal: Visit nodes by levels from top to bottom and from left to right.
    //
    // Time Complexity:
    // - Lookup, Insert, Remove Average: O(log n) Logarithmic time
    // - Lookup, Insert, Remove Worst: O(n) Linear time
    // - Lookup, Insert, Remove Best: O(1) Constant time
    // TODO: Verify times
    // TODO: Add space complexity
    public class BinarySearchTree
    {
        public Node Root { get; private set; }
        public int Count { get; private set; }

        public bool Add(int value)
        {
            // Always inserts the node. The tree is not re-ordered.
            Node before = null;
            Node after = Root;

            while (!(after is null))
            {
                before = after;

                if (value < after.Value)
                {
                    after = after.Left;
                }
                else if (value > after.Value)
                {
                    after = after.Right;
                }
                else
                {
                    // Duplicate value
                    return false;
                }
            }

            Node current = new Node { Value = value };

            if (Root is null)
            {
                Root = current;
            }
            else if (value > before.Value)
            {
                before.Right = current;
            }
            else
            {
                before.Left = current;
            }

            Count++;

            return true;
        }

        public Node Find(int value)
        {
            return Find(value, Root);
        }

        private Node Find(int value, Node node)
        {
            // Recursive. Walks each node and chooses left or right depending on the
            // value of the node. This allows the find to happen without having to
            // check every node.
            if (node is null)
            {
                return null;
            }
            else if (value == node.Value)
            {
                return node;
            }
            else if (value < node.Value)
            {
                return Find(value, node.Left);
            }
            else
            {
                return Find(value, node.Right);
            }
        }

        public void Remove(int value)
        {
            var replacementNode = Remove(value, Root);
            if (!(Root is null) && !(replacementNode is null) && value == Root.Value)
            {
                Root = replacementNode;
            }
        }

        private Node Remove(int value, Node node)
        {
            // 1. Single Child: Put the child where the parent was
            // 2. Two Children: Replace the node being deleted with the largest node in the left subtree and then delete that largest node. 
            //                  The node being deleted can be swapped with the smallest node is the right subtree.
            if (node is null)
            {
                return node;
            }

            if (value < node.Value)
            {
                node.Left = Remove(value, node.Left);
            }
            else if (value > node.Value)
            {
                node.Right = Remove(value, node.Right);
            }
            else
            {
                // 1. One or fewer children
                if (node.Left is null)
                {
                    Count--;
                    return node.Right;
                }
                else if (node.Right is null)
                {
                    Count --;
                    return node.Left;
                }

                // 2. Two children
                node.Value = MinValue(node.Right);
                node.Right = Remove(node.Value, node.Right);
            }
            return node;
        }

        public int Depth()
        {
            return Depth(Root);
        }

        private int Depth(Node node)
        {
            if (node is null)
            {
                return 0;
            }
            return 1 + Math.Max(Depth(node.Left), Depth(node.Right));
        }

        private int MinValue(Node node)
        {
            var minValue = node.Value;
            while (!(node.Left is null))
            {
                minValue = node.Value;
                node = node.Left;
            }
            return minValue;
        }

        // This is a Pre-Order Traversal
        public List<int> PrintRootLeftRight()
        {
            var values = new List<int>();
            PrintRootLeftRight(Root, values);
            return values;
        }

        private void PrintRootLeftRight(Node node, List<int> values)
        {
            if (node != null)
            {
                values.Add(node.Value);
                PrintRootLeftRight(node.Left, values);
                PrintRootLeftRight(node.Right, values);
            }
        }
    
        // This is an In-Order Traversal
        public List<int> PrintLeftRootRight()
        {
            var values = new List<int>();
            PrintLeftRootRight(Root, values);
            return values;
        }

        private void PrintLeftRootRight(Node node, List<int> values)
        {
            if (node != null)
            {
                PrintLeftRootRight(node.Left, values);
                values.Add(node.Value);
                PrintLeftRootRight(node.Right, values);
            }
        }
    
        // This is a Post-Order Traversal
        public List<int> PrintLeftRightRoot()
        {
            var values = new List<int>();
            PrintLeftRightRoot(Root, values);
            return values;
        }

        private void PrintLeftRightRoot(Node node, List<int> values)
        {
            if (node != null)
            {
                PrintLeftRightRoot(node.Left, values);
                PrintLeftRightRoot(node.Right, values);
                values.Add(node.Value);
            }
        }
    }
}