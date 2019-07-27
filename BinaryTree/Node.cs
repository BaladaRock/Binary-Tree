using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Node<T>
        where T : IComparable<T>
    {
        private readonly T[] dataArray;

        public Node(T data, int arraySize = 1)
        {
            Left = null;
            Right = null;
            Data = data;
            dataArray = new T[arraySize];
            dataArray[0] = data;
            ArrayCount = 1;
        }

        public T Data { get; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        private int ArrayCount { get; set; }

        public void AddValue(T value)
        {
            if (IsFull())
            {
                return;
            }

            if (CheckIfSorted(value))
            {
                dataArray[ArrayCount] = value;
            }
            else
            {
                InsertElement(value);
            }

            ArrayCount++;
        }

        public IEnumerable<T> GetElements()
        {
            for (int i = 0; i < ArrayCount; i++)
            {
                yield return dataArray[i];
            }
        }

        public bool IsFull()
        {
            return ArrayCount == dataArray.Length;
        }

        private bool CheckIfSorted(T value)
        {
            return dataArray[ArrayCount].CompareTo(value) <= 0;
        }

        private void InsertElement(T value)
        {
            for (int i = 0; i < ArrayCount; i++)
            {
                if (dataArray[i].CompareTo(value) >= 0)
                {
                    ShiftElements(i);
                    dataArray[i] = value;
                }
            }
        }

        private void ShiftElements(int index)
        {
            for (int i = index; i < ArrayCount; i++)
            {
                dataArray[i + 1] = dataArray[i];
            }
        }
    }
}