using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Node<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly T[] dataArray;

        public Node(T data, int arraySize = 1)
            : this(new[] { data }, arraySize)
        {
        }

        public Node(T[] dataArray, int arraySize = 1)
        {
            Left = null;
            Right = null;
            this.dataArray = dataArray;
            ArrayCount = 1;
        }

        public T Data => dataArray[0];

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        private int ArrayCount { get; set; }

        private T GetLastElement => dataArray[ArrayCount - 1];

        public void Add(T value)
        {
            InsertData(this, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < ArrayCount; i++)
            {
                yield return dataArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsFull(Node<T> node)
        {
            return node.ArrayCount == node.dataArray.Length;
        }

        private void InsertData(Node<T> node, T value)
        {
            if (!IsFull(node))
            {
                InsertElement(node, value);
                node.ArrayCount++;
            }

            if (value.CompareTo(node.GetLastElement) >= 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value, node.ArrayCount);
                }
                else
                {
                    InsertData(node.Right, value);
                }
            }
            else if (value.CompareTo(Data) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value, node.ArrayCount);
                }
                else
                {
                    InsertData(node.Left, value);
                }
            }
        }

        private void InsertElement(Node<T> node, T value)
        {
            for (int i = 0; i < node.ArrayCount; i++)
            {
                if (node.dataArray[i].CompareTo(value) >= 0)
                {
                    ShiftElements(node, i);
                    dataArray[i] = value;
                    break;
                }
            }
        }

        private void ShiftElements(Node<T> node, int index)
        {
            for (int i = index; i < node.ArrayCount; i++)
            {
                node.dataArray[i + 1] = node.dataArray[i];
            }
        }
    }
}