﻿using System;
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

        public T FirstValue => dataArray[0];

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        private int ArrayCount { get; set; }

        private T LastValue => dataArray[ArrayCount - 1];

        public void Add(T value)
        {
            InsertData(value);
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

        public bool IsFull()
        {
            return ArrayCount == dataArray.Length;
        }

        public void RemoveData(T value)
        {
            foreach (var element in this)
            {
                /*   if (element.Equals(value))
                   {
                   }*/
            }
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
                    ShiftElements(i);
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
                var newArray = new T[ArrayCount];
                newArray[0] = value;
                return new Node<T>(newArray, ArrayCount);
            }

            node.InsertData(value);

            return node;
        }

        private void ShiftElements(int index)
        {
            for (int i = dataArray.Length - 1; i > index; i--)
            {
                dataArray[i] = dataArray[i - 1];
            }
        }
    }
}