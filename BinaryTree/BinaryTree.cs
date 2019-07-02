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
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
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
            if (root != null)
            {
                if (root.Left != null)
                {
                    yield return root.Left.Data;
                }

                yield return root.Data;
            }
            else
            {
                yield break;
            }

            foreach (T rightNode in PreOrderTraversal(root.Right))
            {
                yield return rightNode;
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
                if (node.Data.CompareTo(root.Data) < 0)
                {
                    InsertLeft(node, root);
                }
                else
                {
                    InsertRight(node, root);
                }
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
            if (node != null)
            {
                yield return node.Data;
            }
            else
            {
                yield break;
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
            foreach (var treeNode in this)
            {
                yield return treeNode;
            }
        }

        private void InsertLeft(Node<T> child, Node<T> parent)
        {
            if (parent.Left != null)
            {
                return;
            }

            parent.Left = child;
            Count++;
        }

        private void InsertRight(Node<T> child, Node<T> parent)
        {
            if (parent.Right != null)
            {
                return;
            }

            parent.Right = child;
            Count++;
        }
    }
}
