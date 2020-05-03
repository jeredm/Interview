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
    // - The nodes on the left are all less than the parent
    // - The nodes on the right are all greater than the parent
    // - Adding nodes does not re-assign nodes. This only happens on remove.
    //
    // Implementation Notes:
    // - This tree assumes duplicates are invalid and false is returned when a duplicate is added.
    //   Duplicates could be allowed by adding a Count to the Node class and incrementing the count.
    // - This tree uses an Integer for the value, but we could implement the same thing using Comparable.
    //   In that case, we could Compare each node instead of checking the value of an int.
    // 
    // Depth First Search (DFS):
    // These searches are recursive.
    // - Pre Order traversal: Visit the parent first and then left and then right children
    // - In Order traversal: Visit the left child, then the parent and then the right child (always produces sorted output)
    // - Post Order traversal: Visit left child, then the right child and then the parent
    //
    // Breadth First Search (BFS):
    // This search uses a Queue
    // - Level Order traversal: Visit nodes by levels from top to bottom and from left to right.
    //
    // Time Complexity:
    // - Find, Add, Remove Average: O(log n) Logarithmic time
    // - Find, Add, Remove Worst: O(n) Linear time
    // - Find, Add, Remove Best: O(1) Constant time
    // - All Traversal: O(n) Linear time because every node has to be visited
    //
    // Space Complexity:
    // - DFS Traversals: 
    //   Balanced O(log n) vs. Skewed O(n). This is because of more function call overhead when the tree
    //   is deeper. The recursive nature of this pattern is the function call overhead.
    // - BFS Traversals:
    //   Balanced O(n) vs. Skewed O(log n). The more nodes in a row means more space that is going to 
    //   be consumed by the queue.
    // - How to choose?:
    //   If the node you need is closer to the root, DFS will likely be better.
    //   If the node you need is a leaf, BFS will likely be better.
    public class BinarySearchTree
    {
        public Node Root { get; private set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            var node = Add(value, Root);
            if (Root is null)
            {
                Root = node;
            }
        }

        private Node Add(int value, Node node)
        {
            if (node == null)
            {
                node = new Node { Value = value};
                Count++;
            }
            else if (value < node.Value)
            {
                node.Left = Add(value, node.Left);
            }
            else
            {
                node.Right = Add(value, node.Right);
            }
            return node;
        }

        // This is a Depth First Search (DFS)
        public Node Find(int value)
        {
            return Find(value, Root);
        }

        private Node Find(int value, Node node)
        {
            if (node is null || value == node.Value)
            {
                return node;
            }
            else if (value < node.Value)
            {
                return Find(value, node.Left);
            }
 
            return Find(value, node.Right);
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
        public List<int> TraverseRootLeftRight()
        {
            var values = new List<int>();
            TraverseRootLeftRight(Root, values);
            return values;
        }

        private void TraverseRootLeftRight(Node node, List<int> values)
        {
            if (node != null)
            {
                values.Add(node.Value);
                TraverseRootLeftRight(node.Left, values);
                TraverseRootLeftRight(node.Right, values);
            }
        }
    
        // This is an In-Order Traversal
        public List<int> TraverseLeftRootRight()
        {
            var values = new List<int>();
            TraverseLeftRootRight(Root, values);
            return values;
        }

        private void TraverseLeftRootRight(Node node, List<int> values)
        {
            if (node != null)
            {
                TraverseLeftRootRight(node.Left, values);
                values.Add(node.Value);
                TraverseLeftRootRight(node.Right, values);
            }
        }
    
        // This is a Post-Order Traversal
        public List<int> TraverseLeftRightRoot()
        {
            var values = new List<int>();
            TraverseLeftRightRoot(Root, values);
            return values;
        }

        private void TraverseLeftRightRoot(Node node, List<int> values)
        {
            if (node != null)
            {
                TraverseLeftRightRoot(node.Left, values);
                TraverseLeftRightRoot(node.Right, values);
                values.Add(node.Value);
            }
        }

        public List<int> TraverseBreadthFirst()
        {
            var values = new List<int>();
            var visited = new HashSet<int>();
            var nextToVisit = new Queue<Node>();
            nextToVisit.Enqueue(Root);

            while (nextToVisit.Count > 0)
            {
                var node = nextToVisit.Dequeue();
                if (visited.Contains(node.Value))
                {
                    continue;
                }

                // If we want a BFS, we can check here for a match and return true if it is.

                visited.Add(node.Value);
                values.Add(node.Value);

                if (!(node.Left is null))
                {
                    nextToVisit.Enqueue(node.Left);
                }
                if (!(node.Right is null))
                {
                    nextToVisit.Enqueue(node.Right);
                }
            }
            return values; // If this is a BFS, we would return false here.
        }
    }
}