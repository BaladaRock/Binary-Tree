using System.Collections.Generic;

namespace BinaryTree
{
    public interface IBinaryTreeCollection<T> : ICollection<T>
    {
        void RemoveChild(Node<T> node);

        void InsertChild(Node<T> node);

        IEnumerable<T> PreOrderTraversal();

        IEnumerable<T> PostOrderTraversal();

        IEnumerable<T> InOrderTraversal();
    }
}