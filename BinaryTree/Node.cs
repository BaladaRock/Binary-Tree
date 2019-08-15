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
        {
            Left = null;
            Right = null;
            dataArray = new T[arraySize];
            dataArray[0] = data;
            ArrayCount = 1;
        }

        public T FirstValue => dataArray[0];

        public T LastValue => dataArray[ArrayCount - 1];

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        private int ArrayCount { get; set; }

        public void Add(T value)
        {
            InsertData(value);
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
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

        public IEnumerable<T> GetPostOrderEnumerator()
        {
            for (int i = ArrayCount - 1; i >= 0; i--)
            {
                yield return dataArray[i];
            }
        }

        public bool HasOneChild()
        {
            return (Right == null && Left != null)
                || (Left == null && Right != null);
        }

        public bool IsFull()
        {
            return ArrayCount == dataArray.Length;
        }

        public bool IsLeaf()
        {
            return Right == null && Left == null;
        }

        public void RemoveData(T value)
        {
            for (int i = 0; i < ArrayCount; i++)
            {
                if (dataArray[i].Equals(value))
                {
                    ShiftLeft(i);
                    ArrayCount--;
                    return;
                }
            }
        }

        internal void MoveElement(T leafItem, T value)
        {
            RemoveData(value);
            Add(leafItem);
        }

        private void InsertData(T value)
        {
            if (!IsFull())
            {
                InsertElement(value);
                return;
            }

            if (value.CompareTo(LastValue) >= 0)
            {
                Right = InsertTo(Right, value);
                return;
            }

            if (value.CompareTo(FirstValue) <= 0)
            {
                Left = InsertTo(Left, value);
                return;
            }

            T temp = LastValue;
            InsertElement(value);
            Right = InsertTo(Right, temp);
        }

        private void InsertElement(T value)
        {
            for (int i = 0; i < dataArray.Length; i++)
            {
                if (dataArray[i].CompareTo(value) > 0)
                {
                    ShiftRight(i);
                    dataArray[i] = value;
                    ArrayCount = Math.Min(ArrayCount + 1, dataArray.Length);
                    return;
                }
            }

            if (IsFull())
            {
                throw new InvalidOperationException();
            }

            dataArray[ArrayCount++] = value;
        }

        private Node<T> InsertTo(Node<T> node, T value)
        {
            if (node == null)
            {
                return new Node<T>(value, ArrayCount);
            }

            node.InsertData(value);

            return node;
        }

        private void ShiftLeft(int startingIndex)
        {
            for (int i = startingIndex; i < ArrayCount - 1; i++)
            {
                dataArray[i] = dataArray[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = dataArray.Length - 1; i > index; i--)
            {
                dataArray[i] = dataArray[i - 1];
            }
        }
    }
}