using BinaryTree;
using System;
using Xunit;

namespace BinaryTreeFacts
{
    public class BinaryTreeFacts
    {
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
            Assert.Equal(new[] { 6, 5, 5, 3, 2 }, tree.PostOrderTraversal());
            Assert.Equal(new[] { 2, 3, 5, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_AddMethod_Check_Node_After_Inserting_More_Elements_Then_Size()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            var node = new Node<int>(new[] { 1, 2, 3 }, 3);
            //When
            tree.InsertChild(node);
            tree.Add(3);
            //Then
            Assert.NotNull(tree.FindNode(new Node<int>(3, 3), 3));
        }

        [Fact]
        public void Test_AddMethod_For_Edge_Case_When_Size_Is_2()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                1,
                3,
                4,
                5,
                2,
            };
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, tree.InOrderTraversal());
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
        public void Test_AddMethod_Should_Correctly_Shift_Elements_When_Size_Is_2()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                2,
                0,
                2,
                3,
            };
            //Then
            Assert.Equal(new[] { 0, 2, 2, 3 }, tree.InOrderTraversal());
        }
        [Fact]
        public void Test_Array_Of_Values_When_Size_Is_1()
        {
            //Given, when
            var tree = new BinaryTreeCollection<int>(1)
            {
               1
            };
            //Then
            Assert.Equal(new[] { 1 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_AsReadOnly_Should_Return_False_When_List_Is_NOT_RO()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               5,
               3,
               6,
            };
            //Then
            Assert.False(tree.IsReadOnly);
        }

        [Fact]
        public void Test_AsReadOnly_Should_Return_True_When_List_Is_RO()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               5,
               3,
               6,
            };
            //When
            var roTree = tree.AsReadOnly();
            //Then
            Assert.False(tree.IsReadOnly);
            Assert.True(roTree.IsReadOnly);
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
        public void Test_CopyTo_Should_Copy_Nodes_When_Array_Has_Enough_Capacity()
        {
            //Given
            int[] array = new int[5];
            var tree = new BinaryTreeCollection<int>
            {
               5,
               3,
               6,
            };
            //When
            tree.CopyTo(array, 1);
            //Then
            Assert.Equal(new[] { 0, 3, 5, 6, 0 }, array);
        }

        [Fact]
        public void Test_CopyTo_Should_Not_Copy_Nodes_When_Array_Does_Not_Have_Enough_Capacity()
        {
            //Given
            int[] array = new int[3];
            var tree = new BinaryTreeCollection<int>
            {
               5,
               3,
               6,
            };
            //When
            Assert.Throws<ArgumentException>(() => tree.CopyTo(array, 1));
            //Then
            Assert.Equal(new[] { 0, 0, 0 }, array);
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
        public void Test_FindNode_Check_Parent_And_Child_After_Insertion()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(3)
            {
               5,
               3,
               6,
            };
            //When
            var checkNode = tree.FindNode(new Node<int>(6, 3), 6);
            //Then
            Assert.NotNull(checkNode);
        }

        [Fact]
        public void Test_FindNode_Method_Check_That_Node_Exists()
        {
            //Given
            var node = new Node<int>(3) { 1 };
            var tree = new BinaryTreeCollection<int>(3)
            {
               5,
               3,
               6,
            };
            //When
            var checkNode = tree.FindNode(node, 3);
            //Then
            Assert.Equal(node, checkNode);
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
        public void Test_InOrderTraversal_Empty_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //Then
            Assert.Empty(tree.InOrderTraversal());
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
        public void Test_InOrderTraversal_Size_Is_Larger()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                1,
                3,
                4,
                2,
                5,
                4,
                7,
                8,
                9
            };
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4, 4, 5, 7, 8, 9 }, tree.InOrderTraversal());
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
        public void Test_InOrderTraversal_When_Size_Is_1()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(1)
            {
                1,
                3,
                4,
                2,
            };
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4 }, tree.InOrderTraversal());
        }
        [Fact]
        public void Test_InOrderTraversal_When_Size_Is_2_()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                4,
                4,
                5,
                6
            };
            //Then
            Assert.Equal(new[] { 4, 4, 5, 6 }, tree.InOrderTraversal());
        }

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
        public void Test_PostOrderTraversal_Empty_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //Then
            Assert.Empty(tree.PostOrderTraversal());
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
            Assert.Equal(new[] { 4, 2 }, tree.PostOrderTraversal());
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
        public void Test_PostOrderTraversal_Root_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.InsertChild(new Node<int>(4));
            tree.InsertChild(new Node<int>(2));
            tree.InsertChild(new Node<int>(5));
            //Then
            Assert.Equal(new[] { 5, 4, 2 }, tree.PostOrderTraversal());
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
        public void Test_PreOrderTraversal_When_Size_Is_2_()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                1,
                2,
                3,
                4
            };
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Remove_Should_Correctly_Work_For_Array_When_Element_Is_Leaf()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(3)
            {
               3,
               5,
               6,
               7,
               8,
               9
            };
            //When
            tree.Remove(9);
            //Then
            Assert.Equal(new[] { 3, 5, 6, 7, 8 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Remove_Should_Correctly_Work_When_Element_Is_Leaf()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(3)
            {
               3,
               5,
               6,
               7,
               8,
               9
            };
            //When
            tree.Remove(9);
            //Then
            Assert.Equal(new[] { 3, 5, 6, 7, 8 }, tree.InOrderTraversal());
        }

        public void Test_RemoveChild_another_edge_case()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               5,
               3,
               6,
               0,
               4,
               7,
               4
            };
            //When
            tree.Remove(3);
            //Then
            Assert.Equal(new[] { 0, 4, 4, 5, 6, 7 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Check_Edge_Case()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               20,
               7,
               30,
               4,
               15,
               3,
               5,
               12,
               17,
               16,
               18
            };
            //When
            tree.Remove(15);
            //Then
            Assert.Equal(new[] { 3, 4, 5, 7, 12, 16, 17, 18, 20, 30 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Check_That_NO_Node_is_LOST_during_Deletion_process()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               4,
               0,
               5,
               -1,
               -2,
               2,
               1,
               3,
               6
            };
            //When
            tree.Remove(1);
            //Then
            Assert.Equal(new[] { -2, -1, 0, 2, 3, 4, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Check_That_NO_Node_is_LOST_When_NodeToDelete_Is_ROOT()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               4,
               1,
               5,
               6,
               0,
               2,
               3
            };
            //When
            tree.Remove(4);
            //Then
            Assert.Equal(new[] { 0, 1, 2, 3, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Edge_Case()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               -1,
               2,
               0,
               1,
               3
            };
            //When
            tree.Remove(2);
            //Then
            Assert.Equal(new[] { -1, 0, 1, 3 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_RemoveChild_Edge_Case_When_Node_IS_ROOT()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               20,
               6,
               1,
               30,
               21,
               31,
               22,
               8,
            };
            //When
            tree.Remove(20);
            //Then
            Assert.Equal(new[] { 1, 6, 8, 21, 22, 30, 31 }, tree.InOrderTraversal());
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
                node.FirstValue,
            };
            //Then
            Assert.True(tree.Remove(node.FirstValue));
            Assert.Equal(new[] { 2, 5, 5, 6 }, tree.InOrderTraversal());
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
        public void Test_RemoveChild_When_Node_is_ROOT_and_has_Only_Left_Children()
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
        public void Test_Size_Is_1_Add_Method_after_2_elements_have_been_added()
        {
            //Given, when
            var tree = new BinaryTreeCollection<int>(1)
            {
               1,
               2
            };
            //Then
            Assert.Equal(new[] { 1, 2 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Size_Is_2_Add_Method_should_FILL_current_Array_before_proceeding()
        {
            //Given, when
            var tree = new BinaryTreeCollection<int>(2)
            {
               1,
               2
            };
            //Then
            Assert.Equal(new[] { 1, 2 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_DataArray_Should_Not_Lose_Last_Element_After_Addition()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                1,
                2,
                1,
                3,
                4
            };
            //Then
            Assert.Equal(new[] { 1, 1, 2, 3, 4 }, tree.InOrderTraversal());
        }
    }
}