using System;

namespace BinaryTree
{
    public static class Program
    {
        internal static void Main(string[] args)
        {
            var tree = new BinaryTreeCollection<int>();
            var nodes = new Node<int>(3);
            foreach (var v in tree.PreOrderTraversal())
            {
                Console.WriteLine(" ");
            }

            Console.ReadKey();
        }
    }
}
