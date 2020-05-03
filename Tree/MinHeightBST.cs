// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;

namespace Tree
{
    // Creates a binary search tree with the minimum height possible.
    // This is not encapsulated to make the problem simple, so methods like Add and Remove are exposed
    // and using them will not rebalance the tree. Only the constrcutor will set up the tree to the 
    // minimum height.
    public class MinHeightBST : BinarySearchTree
    {
        public MinHeightBST(int[] nodeValues)
        {
            Array.Sort(nodeValues);
            Root = BuildTree(nodeValues, 0, nodeValues.Length - 1);
        }

        private Node BuildTree(int[] values, int begin, int end)
        {
            if (begin > end)
                return null;

            var mid = (end + begin) / 2;
            var node = new Node { Value = values[mid] };
            node.Left = BuildTree(values, begin, mid - 1);
            node.Right = BuildTree(values, mid + 1, end);
            return node;
        }
    }
}