using System;
using System.Collections.Generic;

namespace BinaryTree
{
    public interface IBinaryTreeCollection<T> : ICollection<T>
        where T : IComparable<T>
    {
        IEnumerable<T> PreOrderTraversal();

        IEnumerable<T> PostOrderTraversal();

        IEnumerable<T> InOrderTraversal();
    }
}