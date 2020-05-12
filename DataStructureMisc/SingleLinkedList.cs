// Copyright (c) 2020 Jered Myers
// 
// This software is released under the MIT License.
// https://opensource.org/licenses/MIT

using System;
using System.Collections.Generic;

namespace DataStructureMisc
{
    public class SingleLinkedList<T>
    {
        private SingleListNode<T> _head;
        private SingleListNode<T> _current;

        public void Add(T value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            var node = new SingleListNode<T> { Value = value };
            if (_head is null)
            {
                _head = node;
                _current = node;
            }
            else
            {
                var before = _head;
                while (before.Next != null)
                {
                    before = before.Next;
                }
                before.Next = node;
            }
        }

        public bool HasNext()
        {
            return _current != null;
        }

        public T GetNext()
        {
            if (_current is null)
                return default;
            
            var result = _current;
            _current = result.Next;
            return result.Value;
        }

        public void Reset()
        {
            _current = _head;
        }

        public void RemoveValue(T value)
        {
            if (_head is null) return;
            _head = RemoveValue(_head, value);
            Reset();
        }

        private SingleListNode<T> RemoveValue(SingleListNode<T> head, T value)
        {
            var node = head;

            if (node.Value.Equals(value))
            {
                return head.Next;
            }

            while(node.Next != null)
            {
                if (node.Next.Value.Equals(value))
                {
                    node.Next = node.Next.Next;
                    return head;
                }
                node = node.Next;
            }
            return head;
        }

        public T[] GetValues()
        {
            if (_head is null) return null;
            var values = new List<T>();
            
            while (HasNext())
            {
                values.Add(GetNext());
            }
            return values.ToArray();
        }
    }

    public class SingleListNode<T>
    {
        public T Value { get; set; }
        public SingleListNode<T> Next { get; set; }
    }
}