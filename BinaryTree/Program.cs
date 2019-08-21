using System;
using CollectionsClasses;
using Dictionary;
using Linked_List;

namespace BinaryTree
{
    public static class Program
    {
        internal static void Main(string[] args)
        {
            var tree = new BinaryTreeCollection<int>();
            Random numbers = new Random();
            for (int i = 0; i < 5 * Math.Pow(10, 5); i++)
            {
                int current = numbers.Next(0, 10000);
                if (!tree.Contains(current))
                {
                    tree.Add(current);
                }
            }

            foreach (var element in tree)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}