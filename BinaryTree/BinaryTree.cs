using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeCollection<T> : IBinaryTreeCollection<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public BinaryTreeCollection()
        {
            Count = 0;
        }

        public int Count { get; set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            Node<T> nodeToAdd = new Node<T>(item);
            InsertChild(nodeToAdd);
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var enumeratedNode in InOrderTraversal(root))
            {
                yield return enumeratedNode;
            }
        }

        public void RemoveChild(Node<T> node)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void InsertChild(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (Count == 0)
            {
                root = new Node<T>(node.Data) { Data = node.Data };
                Count++;
            }
            else
            {
                InsertNode(node, root);
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            return PreOrderTraversal(root);
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            return PostOrderTraversal(root);
        }

        public IEnumerable<T> InOrderTraversal()
        {
            return InOrderTraversal(root);
        }

        private IEnumerable<T> PreOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node.Data;

            foreach (T leftNode in PreOrderTraversal(node.Left))
            {
                yield return leftNode;
            }

            foreach (T rightNode in PreOrderTraversal(node.Right))
            {
                yield return rightNode;
            }
        }

        private IEnumerable<T> PostOrderTraversal(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Left != null)
            {
                foreach (var leftNode in PostOrderTraversal(node.Left))
                {
                    yield return leftNode;
                }
            }

            if (node.Right != null)
            {
                foreach (var rightNode in PostOrderTraversal(node.Right))
                {
                    yield return rightNode;
                }
            }

            yield return node.Data;
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

            yield return node.Data;

            if (node.Right == null)
            {
                yield break;
            }

            foreach (var rightNode in InOrderTraversal(node.Right))
            {
                yield return rightNode;
            }
        }

        private void InsertNode(Node<T> child, Node<T> parent)
        {
            if (parent == null)
            {
                return;
            }

            if (parent.Data.CompareTo(child.Data) > 0)
            {
                if (parent.Left == null)
                {
                    parent.Left = child;
                    Count++;
                    return;
                }

                InsertNode(child, parent.Left);
            }
            else
            {
                if (parent.Right == null)
                {
                    parent.Right = child;
                    Count++;
                    return;
                }

                InsertNode(child, parent.Right);
            }
        }
    }
}
