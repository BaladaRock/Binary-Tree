﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BinaryTreeFacts")]

namespace BinaryTree
{
    public class BinaryTreeCollection<T> : IBinaryTreeCollection<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public BinaryTreeCollection(int size = 1)
        {
            Size = size;
            Count = 0;
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; set; }

        public int Size { get; }

        public void Add(T item)
        {
            var dataArray = new T[Size];
            dataArray[0] = item;
            Node<T> nodeToAdd = new Node<T>(dataArray, Size);
            InsertChild(nodeToAdd);
        }

        public BinaryTreeCollection<T> AsReadOnly()
        {
            var readOnlyTree = new BinaryTreeCollection<T>();
            foreach (var node in this)
            {
                readOnlyTree.Add(node);
            }

            readOnlyTree.IsReadOnly = true;
            return readOnlyTree;
        }

        public void Clear()
        {
            ThrowReadOnly();

            root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return FindNode(root, item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ThrowCopyToExceptions(array, arrayIndex);

            var enumerator = GetEnumerator();
            for (int i = arrayIndex; i < Count + arrayIndex; i++)
            {
                enumerator.MoveNext();
                array[i] = enumerator.Current;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var enumeratedNode in InOrderTraversal(root))
            {
                yield return enumeratedNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(root);
        }

        public void InsertChild(Node<T> node)
        {
            ThrowInsertExceptions(node);

            if (Count == 0)
            {
                root = node;
            }
            else
            {
                root.Add(node.FirstValue);
            }

            Count++;
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrderTraversal(root);
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(root);
        }

        public bool Remove(T item)
        {
            ThrowReadOnly();

            Node<T> parent = null;
            var foundNode = FindNode(root, item, ref parent);
            if (foundNode == null)
            {
                return false;
            }

            if (parent == null)
            {
                RemoveRoot(foundNode);
            }
            else
            {
                RemoveSibling(parent, foundNode, item);
            }

            Count--;
            return true;
        }

        public void RemoveChild(Node<T> node)
        {
            ThrowNull(node);
            Remove(node.FirstValue);
        }

        internal Node<T> FindNode(Node<T> rootNode, T item)
        {
            var dataArray = new T[Size];
            dataArray[0] = item;
            var newNode = new Node<T>(dataArray, Size);
            return FindNode(rootNode, item, ref newNode);
        }

        private bool CheckForOneChild(Node<T> nodeToRemove)
        {
            return (nodeToRemove.Right == null && nodeToRemove.Left != null)
                || (nodeToRemove.Left == null && nodeToRemove.Right != null);
        }

        private Node<T> FindLeaf(Node<T> parent)
        {
            var newNode = GetNodeToSwap(parent);
            if (IsLeaf(newNode))
            {
                return newNode;
            }

            return FindLeaf(newNode.Left ?? newNode.Right);
        }

        private Node<T> FindNewRoot(Node<T> node)
        {
            if (IsLeaf(node) || CheckForOneChild(node))
            {
                return node;
            }

            return GetNodeToSwap(node);
        }

        private Node<T> FindNode(Node<T> rootNode, T item, ref Node<T> parent)
        {
            if (rootNode == null)
            {
                return null;
            }

            if (rootNode.Left?.FirstValue.Equals(item) == true || rootNode.Right?.FirstValue.Equals(item) == true)
            {
                parent = rootNode;
            }

            int result = rootNode.FirstValue.CompareTo(item);
            if (result == 0)
            {
                return rootNode;
            }

            parent = rootNode;

            return result > 0
                ? FindNode(rootNode.Left, item, ref parent)
                : FindNode(rootNode.Right, item, ref parent);
        }

        private Node<T> GetNodeToSwap(Node<T> foundNode)
        {
            return foundNode.Left ?? foundNode.Right ?? foundNode;
        }

        private IEnumerable<T> InOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Left != null)
            {
                foreach (var leftNode in InOrderTraversal(node.Left))
                {
                    yield return leftNode;
                }
            }

            foreach (var element in node)
            {
                yield return element;
            }

            if (node.Right == null)
            {
                yield break;
            }

            foreach (var rightNode in InOrderTraversal(node.Right))
            {
                yield return rightNode;
            }
        }

        private bool IsLeaf(Node<T> node)
        {
            return node.Right == null && node.Left == null;
        }

        private IEnumerable<T> PostOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Right != null)
            {
                foreach (var rightNode in PostOrderTraversal(node.Right))
                {
                    yield return rightNode;
                }
            }

            foreach (var element in node)
            {
                yield return element;
            }

            if (node.Left == null)
            {
                yield break;
            }

            foreach (var leftNode in PostOrderTraversal(node.Left))
            {
                yield return leftNode;
            }
        }

        private IEnumerable<T> PreOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            foreach (var element in node)
            {
                yield return element;
            }

            foreach (T leftNode in PreOrderTraversal(node.Left))
            {
                yield return leftNode;
            }

            foreach (T rightNode in PreOrderTraversal(node.Right))
            {
                yield return rightNode;
            }
        }

        private void RemoveLeafNode(Node<T> parent, Node<T> leaf)
        {
            if (parent.FirstValue.CompareTo(leaf.FirstValue) >= 0)
            {
                parent.Left = null;
            }
            else
            {
                parent.Right = null;
            }
        }

        private void RemoveRoot(Node<T> rootNode)
        {
            if (Count == 1)
            {
                root = null;
            }
            else
            {
                SwapRootNode(rootNode);
            }
        }

        private void RemoveSibling(Node<T> parent, Node<T> foundNode, T value)
        {
            if (IsLeaf(foundNode))
            {
                // foundNode.RemoveData(value);
                RemoveLeafNode(parent, foundNode);
                return;
            }

            if (CheckForOneChild(foundNode))
            {
                if (parent.Right == foundNode)
                {
                    parent.Right = GetNodeToSwap(foundNode);
                }
                else
                {
                    parent.Left = GetNodeToSwap(foundNode);
                }

                return;
            }

            SwapWithChild(parent, foundNode);
        }

        private void SwapRootNode(Node<T> rootNode)
        {
            if (CheckForOneChild(root))
            {
                root = root.Left ?? root.Right;
            }
            else
            {
                Node<T> newRoot = FindNewRoot(root.Right);
                newRoot.Left = root.Left;
                root = root.Right;
            }
        }

        private void SwapWithChild(Node<T> parent, Node<T> child)
        {
            Node<T> newNode = FindLeaf(child.Right);
            newNode.Left = child.Left;

            if (parent.Right == child)
            {
                parent.Right = child.Right;
            }
            else
            {
                parent.Left = child.Right;
            }
        }

        private void ThrowArgumentException(T[] array, int arrayIndex)
        {
            if (array.Length >= Count + arrayIndex)
            {
                return;
            }

            throw new ArgumentException(message: "Copying proccess could not be initialised\n", paramName: nameof(array));
        }

        private void ThrowCopyToExceptions(T[] array, int arrayIndex)
        {
            ThrowNull(array);
            ThrowIndexException(arrayIndex);
            ThrowArgumentException(array, arrayIndex);
        }

        private void ThrowIndexException(int arrayIndex)
        {
            if (arrayIndex >= 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(paramName: nameof(arrayIndex), message: "Give a valid index!\n");
        }

        private void ThrowInsertExceptions(Node<T> node)
        {
            ThrowReadOnly();
            ThrowNull(node);
        }

        private void ThrowNull(object element)
        {
            if (element != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(element));
        }

        private void ThrowReadOnly()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException(message: "Your BST is readonly!\n");
        }
    }
}