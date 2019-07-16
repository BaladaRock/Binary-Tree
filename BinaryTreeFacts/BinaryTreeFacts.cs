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
        public void Test_Add_Method_For_Edge_Case()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
                5,
                2,
                6,
                5,
                3
            };
            //Then
            Assert.Equal(new[] { 3, 5, 2, 6, 5 }, tree.PostOrderTraversal());
            Assert.Equal(new[] { 2, 3, 5, 5, 6 }, tree.InOrderTraversal());
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
        public void Test_InOrderTraversal_After_Adding_Same_Value_Multiple_Times()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
                4,
                4,
                4
            };
            //Then
            Assert.Equal(new[] { 4, 4, 4 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Unbalanced_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.Add(3);
            tree.InsertChild(new Node<int>(2));
            tree.Add(0);
            tree.Add(-1);
            tree.Add(2);
            tree.Add(6);
            //Then
            Assert.Equal(new[] { -1, 0, 2, 2, 3, 4, 6 }, tree.InOrderTraversal());
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

        [Fact]
        public void Test_Clear_Method_Should_Properly_Work_for_a_random_case()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
                5,
                3,
                2,
                6,
                5
            };
            //When
            tree.Clear();
            //Then
            Assert.Empty(tree.InOrderTraversal());
        }

        [Fact]
        public void Test_ContainsMethod_Should_Return_TRUE_Tree_Has_Only_3_Nodes()
        {
            //Given
            var tree = new BinaryTreeCollection<int>()
            {
            4,
            2,
            5
            };
            //Then
            Assert.True(tree.Contains(2));
        }

        [Fact]
        public void Test_ContainsMethod_Should_Return_False_Tree_Does_Not_Contain_Given_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>()
            {
            4,
            2,
            5
            };
            //Then
            Assert.False(tree.Contains(1));
        }

        [Fact]
        public void Test_ContainsMethod_Should_Return_TRUE_Tree_Has_Only_One_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>()
            {
            4,
            };
            //Then
            Assert.True(tree.Contains(4));
        }

        [Fact]
        public void Test_RemoveChild_Method_Should_Return_FALSE_When_Tree_Does_Not_Contain_Given_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
                5,
                3,
                2,
                6,
                5
            };
            //When
            var removedElement = new Node<int>(7);
            tree.RemoveChild(removedElement);
            //Then
            Assert.Equal(new[] { 2, 3, 5, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Method_Should_Return_TRUE_When_Removed_Node_Is_Left_Leaf()
        {
            //Given
            var node = new Node<int>(3);
            var tree = new BinaryTreeCollection<int>
            {
                5,
                2,
                6,
                5,
                node.Data,
            };
            //Then
            Assert.True(tree.Remove(node.Data));
            Assert.Equal(new[] { 2, 5, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Method_Remove_LEAF_When_Tree_Has_3_Nodes()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               2,
               1,
               3
            };
            //Then
            Assert.True(tree.Remove(3));
            Assert.Equal(new[] { 1, 2 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Method_Should_Work_Correctly_When_Node_Has_1_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               2,
               1,
               3,
               4,
               5
            };
            //Then
            Assert.True(tree.Remove(4));
            Assert.Equal(new[] { 1, 2, 3, 5 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveMethod_Tree_Only_Has_Rootnode()
        {
            //Given
            var tree = new BinaryTreeCollection<int>()
            {
            4,
            };
            //When
            Assert.True(tree.Remove(4));
            //Then
            Assert.Empty(tree);
        }

        [Fact]
        public void Test_RemoveChild_When_NODE_is_ROOT_and_has_only_1_child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               2,
               3,
               4,
               5
            };
            //Then
            Assert.True(tree.Remove(2));
            Assert.Equal(new[] { 3, 4, 5 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_When_Node_is_ROOT_and_has_Only_Left_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               2,
               1,
               0,
               -1
            };
            //Then
            Assert.True(tree.Remove(2));
            Assert.Equal(new[] { -1, 0, 1 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_When_Node_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               4,
               1,
               0,
               5,
               6,
               2
            };
            //When
            tree.Remove(1);
            //Then
            Assert.Equal(new[] { 0, 2, 4, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Node_Has_2_Children_Another_Case()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               5,
               3,
               6,
               2,
               4,
               0,
               1
            };
            //When
            tree.Remove(3);
            //Then
            Assert.Equal(new[] { 0, 1, 2, 4, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_When_Node_Is_ROOT_And_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               5,
               3,
               6,
            };
            //When
            tree.Remove(5);
            //Then
            Assert.Equal(new[] { 3, 6 }, tree.InOrderTraversal());
        }
    }
}
