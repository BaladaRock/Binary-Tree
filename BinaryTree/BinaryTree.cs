using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeCollection<T> : IBinaryTreeCollection<T>
        where T : IComparable<T>
    {
        private readonly Node<T> root;

        public BinaryTreeCollection(int dimension = 3)
        {
            root = new Node<T>(default, dimension);

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
            throw new NotImplementedException();
        }

        public void RemoveChild(Node<T> node)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void InsertChild(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            if (Count == 0)
            {
                root.Data = node.Data;
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
            return RootFirstTraversal(root);
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> InOrderTraversal()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<T> RootFirstTraversal(Node<T> node)
        {
            if (node.Data == null)
            {
                yield break;
            }

            yield return node.Data;
            RootFirstTraversal(node.Left);
            RootFirstTraversal(node.Right);
        }

        /*private IEnumerable<T> TraverseRight(Node<T> node)
        {
            if (node.Right == null)
            {
                yield break;
            }

            TraverseRight(node.Right);
            yield return node.Data;
        }*/

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
