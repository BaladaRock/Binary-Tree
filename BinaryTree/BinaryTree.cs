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

        public bool IsReadOnly { get; set; }

        public void Add(T item)
        {
            Node<T> nodeToAdd = new Node<T>(item);
            InsertChild(nodeToAdd);
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return FindNode(root, item) != null;
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
            Node<T> parent = null;
            var foundNode = FindNode(root, item, ref parent);
            if (foundNode == null)
            {
                return false;
            }

            if (IsRoot(foundNode))
            {
                RemoveRoot(foundNode);
            }
            else if (IsLeaf(foundNode))
            {
                RemoveLeafNode(parent, foundNode);
            }
            else if (CheckForOneChild(parent))
            {
                RemoveOnlyChild(parent, foundNode);
            }
            else if (CheckForTwoChildren(parent))
            {
                RemoveSibling(parent, foundNode);
            }

            Count--;
            return true;
        }

        public void RemoveChild(Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            Remove(node.Data);
        }

        private bool CheckChildren(Node<T> root, Node<T> foundNode)
        {
            bool checkForNull = false;
            if ((root.Left == null && foundNode.Left == null)
            || (root.Right == null && foundNode.Right == null))
            {
                checkForNull = true;
            }

            if (!checkForNull)
            {
                return root.Left.Equals(foundNode.Left) && root.Right.Equals(foundNode.Right);
            }

            return checkForNull;
        }

        private bool CheckForOneChild(Node<T> parent)
        {
            return (parent.Right == null && parent.Left != null)
                || (parent.Left == null && parent.Right != null);
        }

        private bool CheckForTwoChildren(Node<T> parent)
        {
            return parent.Left != null && parent.Right != null;
        }

        private Node<T> FindNode(Node<T> rootNode, T item)
        {
            var newNode = new Node<T>(root.Data);
            return FindNode(rootNode, item, ref newNode);
        }

        private Node<T> FindNode(Node<T> rootNode, T item, ref Node<T> parent)
        {
            if (rootNode == null)
            {
                return null;
            }

            if (Count == 1)
            {
                parent = rootNode;
            }

            if (rootNode.Left?.Data.Equals(item) == true || rootNode.Right?.Data.Equals(item) == true)
            {
                parent = rootNode;
            }

            int result = rootNode.Data.CompareTo(item);
            if (result == 0)
            {
                return rootNode;
            }

            parent = rootNode;

            return result > 0
                ? FindNode(rootNode.Left, item, ref parent)
                : FindNode(rootNode.Right, item, ref parent);
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

        private Node<T> InsertChild(Node<T> child, Node<T> parent)
        {
            if (parent == null)
            {
                Count++;
                return child;
            }

            InsertNode(child, parent);
            return parent;
        }

        private void InsertNode(Node<T> child, Node<T> parent)
        {
            if (parent == null)
            {
                return;
            }

            if (parent.Data.CompareTo(child.Data) >= 0)
            {
                parent.Left = InsertChild(child, parent.Left);
            }
            else
            {
                parent.Right = InsertChild(child, parent.Right);
            }
        }

        private bool IsLeaf(Node<T> node)
        {
            return node.Right == null && node.Left == null;
        }

        private bool IsRoot(Node<T> foundNode)
        {
            return root.Data.Equals(foundNode.Data) && CheckChildren(root, foundNode);
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

        private void RemoveLeafNode(Node<T> parent, Node<T> leaf)
        {
            if (Count == 1)
            {
                root = null;
            }

            if (parent.Data.CompareTo(leaf.Data) >= 0)
            {
                parent.Left = null;
            }
            else
            {
                parent.Right = null;
            }
        }

        private void RemoveOnlyChild(Node<T> parent, Node<T> foundNode)
        {
            if (IsRoot(foundNode))
            {
                root = foundNode.Left ?? foundNode.Right;
            }

            parent.Left = foundNode.Left;
            parent.Right = foundNode.Right;
        }

        private void RemoveRoot(Node<T> rootNode)
        {
            if (Count == 1)
            {
                root = null;
            }
            else if (CheckForOneChild(rootNode))
            {
                RemoveRootChild(rootNode);
            }
            else
            {
                Node<T> temp = rootNode.Right;
                root = rootNode.Left;
                InsertChild(temp);
            }
        }

        private void RemoveRootChild(Node<T> rootNode)
        {
            root = rootNode.Left ?? rootNode.Right;
        }

        private void RemoveSibling(Node<T> parent, Node<T> foundNode)
        {
            SwapWithChild(parent, foundNode);
        }

        private Node<T> ReplaceWithRoot()
        {
            return new Node<T>(root.Data)
            {
                Left = root.Left,
                Right = root.Right
            };
        }

        private void SwapWithChild(Node<T> parent, Node<T> child)
        {
            Node<T> temp = child.Right;
            parent.Left = child.Left;
            InsertChild(temp);
        }
    }
}
