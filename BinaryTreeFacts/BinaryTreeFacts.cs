using BinaryTree;
using System;
using Xunit;

namespace BinaryTreeFacts
{
    public class BinaryTreeFacts
    {
        [Fact]
        public void Test_InsertChild_Should_Add_2_Children_To_Root()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(5));
            //Then
            Assert.Equal(new[] { 4, 2, 5 }, tree.PreOrderTraversal());
        }

        [Fact]
        public void Test_InsertChild_Should_Correctly_Add_More_Children_To_Root()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(1));
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(5));
            tree.InsertChild(new Node<int>(6));
            //Then
            Assert.Equal(new[] { 1, 2, 4, 4, 5, 6 }, tree.InOrderTraversal());
            Assert.Equal(6, tree.Count);
        }

        [Fact]
        public void Test_AddMethod_Should_Correctly_Add_More_Children_To_Root()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
                4,
                2,
                1,
                4,
                5,
                6
            };
            //Then
            Assert.Equal(new[] { 1, 2, 4, 4, 5, 6 }, tree.InOrderTraversal());
            Assert.Equal(6, tree.Count);
        }

        [Fact]
        public void Test_InsertChild_Should_Correctly_Add_Elements_Repeatedely_As_Left_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(10));
            tree.InsertChild(new Node<int>(9));
            tree.InsertChild(new Node<int>(8));
            tree.InsertChild(new Node<int>(7));
            tree.InsertChild(new Node<int>(6));
            tree.InsertChild(new Node<int>(5));
            //Then
            Assert.Equal(new[] { 5, 6, 7, 8, 9, 10 }, tree.InOrderTraversal());
            Assert.Equal(6, tree.Count);
        }

        [Fact]
        public void Test_InsertChild_Should_Correctly_Add_Elements_Repeatedely_As_Right_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(1));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(3));
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(5));
            tree.InsertChild(new Node<int>(6));
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, tree.InOrderTraversal());
            Assert.Equal(6, tree.Count);
        }

        [Fact]
        public void Test_Count_Property_After_Multiple_Insertions()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(1));
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(5));
            tree.InsertChild(new Node<int>(6));
            //Then
            Assert.Equal(6, tree.Count);
        }

        [Fact]
        public void Test_PreOrderTraversal_Tree_Has_1_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            //Then
            Assert.Equal(new[] { 4 }, tree.PreOrderTraversal());
        }

        [Fact]
        public void Test_PreOrderTraversal_Empty_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //Then
            Assert.Empty(tree.PreOrderTraversal());
        }

        [Fact]
        public void Test_PreOrderTraversal_Root_Has_1_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            //Then
            Assert.Equal(new[] { 4, 2 }, tree.PreOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Root_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(5));
            //Then
            Assert.Equal(new[] { 2, 4, 5 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Root_Has_1_Left_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            //Then
            Assert.Equal(new[] { 2, 4 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Root_Has_1_Right_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(6));
            //Then
            Assert.Equal(new[] { 4, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Tree_Has_1_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            //Then
            Assert.Equal(new[] { 4 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Empty_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //Then
            Assert.Empty(tree.InOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Root_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(5));
            //Then
            Assert.Equal(new[] { 2, 5, 4 }, tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Root_Has_1_Left_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            //Then
            Assert.Equal(new[] { 2, 4 }, tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Root_Has_1_Right_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(6));
            //Then
            Assert.Equal(new[] { 6, 4 }, tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Tree_Has_1_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            //Then
            Assert.Equal(new[] { 4 }, tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Empty_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //Then
            Assert.Empty(tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_GetEnumerator_Empty_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            var enumerator = tree.GetEnumerator();
            //Then
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_GetEnumerator_Tree_Has_1_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            var enumerator = tree.GetEnumerator();
            //Then
            Assert.True(enumerator.MoveNext());
            Assert.Equal(4, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Test_GetEnumerator_Root_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(5));
            var enumerator = tree.GetEnumerator();
            enumerator.MoveNext();
            //Then
            Assert.Equal(2, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(4, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(5, enumerator.Current);
            enumerator.MoveNext();
            Assert.False(enumerator.MoveNext());
        }

    }
}
