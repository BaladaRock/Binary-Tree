using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            ThrowDuplicateException(item);

            if (Count == 0)
            {
                root = new Node<T>(item, Size);
            }
            else
            {
                root.Add(item);
            }

            Count++;
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
            return FindNode(item) != null;
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

            RemoveItem(parent, foundNode, item);
            Count--;

            return true;
        }

        internal Node<T> FindNode(T item)
        {
            Node<T> dummy = null;
            return FindNode(root, item, ref dummy);
        }

        private Node<T> FindNode(Node<T> rootNode, T item, ref Node<T> parent)
            {
            if (rootNode == null)
            {
                return null;
            }

            if (rootNode.Contains(item))
            {
                return rootNode;
            }

            parent = rootNode;

            if (item.CompareTo(rootNode.FirstValue) < 0)
            {
                return FindNode(rootNode.Left, item, ref parent);
            }

            if (item.CompareTo(rootNode.LastValue) < 0)
            {
                return null;
            }

            return FindNode(rootNode.Right, item, ref parent);
        }

        private T FindValueToReplace(Node<T> foundNode)
        {
            return foundNode.Left == null
                ? GetMinValue(foundNode.Right)
                : GetMaxValue(foundNode.Left);
        }

        private T GetMaxValue(Node<T> node)
        {
            return PostOrderTraversal(node).First();
        }

        private T GetMinValue(Node<T> node)
        {
            return InOrderTraversal(node).First();
        }

        private IEnumerable<T> InOrderTraversal(Node<T> node)
        {
            return node == null
                ? Enumerable.Empty<T>()
                : InOrderTraversal(node.Left)
                    .Concat(node)
                    .Concat(InOrderTraversal(node.Right));
        }

        private IEnumerable<T> PostOrderTraversal(Node<T> node)
        {
            return node == null
                ? Enumerable.Empty<T>()
                : PostOrderTraversal(node.Right)
                    .Concat(node.GetPostOrderEnumerator())
                    .Concat(PostOrderTraversal(node.Left));
        }

        private IEnumerable<T> PreOrderTraversal(Node<T> node)
        {
            return node == null
               ? Enumerable.Empty<T>()
               : node
                   .Concat(PreOrderTraversal(node.Left))
                   .Concat(PreOrderTraversal(node.Right));
        }

        private void RemoveItem(Node<T> parent, Node<T> foundNode, T value)
        {
            if (foundNode.IsLeaf())
            {
                foundNode.RemoveData(value);
                if (foundNode.IsEmpty())
                {
                    RemoveChildNode(parent, foundNode);
                }

                return;
            }

            var valueToReplace = FindValueToReplace(foundNode);
            Remove(valueToReplace);

            foundNode.ReplaceValue(valueToReplace, value);
        }

        private void RemoveChildNode(Node<T> parent, Node<T> childNode)
        {
            if (parent == null)
            {
                root = null;
                return;
            }

            parent.RemoveChild(childNode);
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

        private void ThrowDuplicateException(T item)
        {
            if (!Contains(item))
            {
                return;
            }

            throw new InvalidOperationException(message: "Tree cannot contain duplicates! ");
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