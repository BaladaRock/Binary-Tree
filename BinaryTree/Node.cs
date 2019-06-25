namespace BinaryTree
{
    public class Node<T>
    {
        public Node(T data, int size)
        {
            Left = null;
            Right = null;
            Data = data;
            Size = size;
        }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public T Data { get; set; }

        public int Size { get; set; }
    }
}