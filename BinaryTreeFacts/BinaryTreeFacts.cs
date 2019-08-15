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
                4,
                3
            };
            //Then
            Assert.Equal(new[] { 6, 5, 4, 3, 2 }, tree.PostOrderTraversal());
            Assert.Equal(new[] { 2, 3, 4, 5, 6 }, tree.InOrderTraversal());
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
                7,
                5,
                6
            };
            //Then
            Assert.Equal(new[] { 1, 2, 4, 5, 6, 7 }, tree.InOrderTraversal());
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
                3,
                4,
            };
            //Then
            Assert.Equal(new[] { 0, 2, 3, 4 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_AddMethod_Should_Throw_Exception_When_Value_Is_Already_In_Tree()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                2,
                0,
                3,
            };
            //When
            var exception = Assert.Throws<InvalidOperationException>(() => tree.Add(2));
            //Then
            Assert.Equal("Tree cannot contain duplicates! ", exception.Message);
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
                4
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
            var tree = new BinaryTreeCollection<int>() { 4, 2, 1, 3, 5, 6 };

            //Then
            Assert.Equal(6, tree.Count);
        }

        [Fact]
        public void Test_DataArray_Should_Not_Lose_Last_Element_After_Addition()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
                1,
                2,
                3,
                4,
                5
            };
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_FindNode_Check_That_Node_Is_Found_When_Last_Element_Is_Called()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(3) { 3, 5, 6 };
            //When
            var checkNode = tree.FindNode(6);
            //Then
            Assert.Equal(new[] { 3, 5, 6 }, checkNode);
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
            var tree = new BinaryTreeCollection<int>() { 4, 2, 5 };
            //Then
            Assert.Equal(new[] { 2, 4, 5 }, tree);
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
            var tree = new BinaryTreeCollection<int>() { 4 };
            //When
            tree.Add(2);
            //Then
            Assert.Equal(new[] { 2, 4 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Root_Has_1_Right_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>() { 4 };
            //When
            tree.Add(6);
            //Then
            Assert.Equal(new[] { 4, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Root_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>() { 4 };
            //When
            tree.Add(2);
            tree.Add(5);
            //Then
            Assert.Equal(new[] { 2, 4, 5 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Size_Is_Larger()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(5)
            {
                1,
                3,
                4,
                2,
                5,
                7,
                8,
                9,
                10,
                11
            };
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Tree_Has_1_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.Add(4);
            //Then
            Assert.Equal(new[] { 4 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InOrderTraversal_Unbalanced_Tree()
        {
            //Given, Whwn
            var tree = new BinaryTreeCollection<int>
            {
                4,
                3,
                2,
                0,
                -1,
                6
            };
            //Then
            Assert.Equal(new[] { -1, 0, 2, 3, 4, 6 }, tree.InOrderTraversal());
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
                3,
                4,
                5,
                6
            };
            //Then
            Assert.Equal(new[] { 3, 4, 5, 6 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_InsertChild_Should_Add_2_Children_To_Root()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.Add(4);
            tree.Add(2);
            tree.Add(5);
            //Then
            Assert.Equal(new[] { 4, 2, 5 }, tree.PreOrderTraversal());
        }

        [Fact]
        public void Test_InsertChild_Should_Correctly_Add_Elements_Repeatedely_As_Left_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.Add(10);
            tree.Add(9);
            tree.Add(8);
            tree.Add(7);
            tree.Add(6);
            tree.Add(5);
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
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, tree.InOrderTraversal());
            Assert.Equal(6, tree.Count);
        }

        [Fact]
        public void Test_InsertChild_Should_Correctly_Add_More_Children_To_Root()
        {
            //When
            var tree = new BinaryTreeCollection<int>
            {
                4,
                2,
                1,
                3,
                5,
                6
            };
            //Then
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, tree.InOrderTraversal());
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
            tree.Add(4);
            tree.Add(2);
            //Then
            Assert.Equal(new[] { 4, 2 }, tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Root_Has_1_Right_Child()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.Add(4);
            tree.Add(6);
            //Then
            Assert.Equal(new[] { 6, 4 }, tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Root_Has_2_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.Add(4);
            tree.Add(2);
            tree.Add(5);
            //Then
            Assert.Equal(new[] { 5, 4, 2 }, tree.PostOrderTraversal());
        }

        [Fact]
        public void Test_PostOrderTraversal_Tree_Has_1_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.Add(4);
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
            tree.Add(4);
            tree.Add(2);
            //Then
            Assert.Equal(new[] { 4, 2 }, tree.PreOrderTraversal());
        }

        [Fact]
        public void Test_PreOrderTraversal_Tree_Has_1_Node()
        {
            //Given
            var tree = new BinaryTreeCollection<int>();
            //When
            tree.Add(4);
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
        public void Test_Remove__Element_Has_More_Left_Children_Should_correctly_remove_FIRST_element()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(3)
            {
                0,
                1,
                2,
                -11,
                -10,
                -9,
                -8,
                -7,
                -6,
                -5,
                -4,
                -3,
                -2,
                -1
            };
            //When
            tree.Remove(-3);
            //Then
            Assert.Equal(new[] { -11, -10, -9, -8, -7, -6, -5, -4, -2, -1, 0, 1, 2 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Remove__Element_Has_More_Right_Children_Should_correctly_remove_MIDDLE_element()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(3)
            {
                0,
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                10,
                11
            };
            //When
            tree.Remove(4);
            //Then
            Assert.Equal(new[] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10, 11 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Remove__Element_Has_One_Right_Child_Should_correctly_remove_LAST_element()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
               0,
               1,
               2,
               3,
               4,
               5,
            };
            //When
            tree.Remove(3);
            //Then
            Assert.Equal(new[] { 0, 1, 2, 4, 5 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Remove__Element_Is_Leaf_Should_correctly_remove_FIRST_element()
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
            tree.Remove(7);
            //Then
            Assert.Equal(new[] { 3, 5, 6, 8, 9 }, tree.InOrderTraversal());
            Assert.Equal(5, tree.Count);
        }

        [Fact]
        public void Test_Remove__Element_Is_Leaf_Should_correctly_remove_Middle_element()
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
            tree.Remove(8);
            //Then
            Assert.Equal(new[] { 3, 5, 6, 7, 9 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Remove__Element_Is_Leaf_Should_Use_Empty_Spaces_At_Next_Addition()
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
            tree.Remove(8);
            tree.Add(8);
            Node<int> foundNode = tree.FindNode(8);
            //Then
            Assert.Equal(new[] { 7, 8, 9 }, foundNode);
        }

        [Fact]
        public void Test_Remove_Node_Is_Leaf_Check_That_Parent_Child_Is_Null()
        {
            //Given
            var tree = new BinaryTreeCollection<int>()
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
            Node<int> foundNode = tree.FindNode(8);
            //Then
            Assert.Null(foundNode.Right);
        }

        [Fact]
        public void Test_Remove_Node_Is_Leaf_Parent_should_have_SAME_CHILD()
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
            Node<int> foundNode = tree.FindNode(5);
            //Then
            Assert.Equal(new[] { 7, 8 }, foundNode.Right);
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
            var tree = new BinaryTreeCollection<int>()
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
        public void Test_Remove_When_Element_Has_Children_Size_Is_Larger()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(3)
            {
               12,
               11,
               13,
               5,
               6,
               7,
               8,
               9,
               10,
               2,
               3,
               4,
               0,
               1
            };
            //When
            tree.Remove(6);
            //Then
            Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13 }, tree.InOrderTraversal());
        }

        [Fact]
        public void Test_Remove_When_Node_Has_2_Children_Size_Is_2()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
               0,
               1,
               10,
               11,
               4,
               5,
               6,
               7,
               2,
               3,
            };
            //When
            tree.Remove(4);
            //Then
            Assert.Equal(new[] { 0, 1, 2, 3, 5, 6, 7, 10, 11 }, tree.InOrderTraversal());
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
        public void Test_RemoveChild_Method_Should_Return_TRUE_When_Removed_Node_Is_Left_Leaf()
        {
            //Given
            var node = new Node<int>(3);
            var tree = new BinaryTreeCollection<int>
            {
                5,
                2,
                6,
                1,
                node.FirstValue,
            };
            //Then
            Assert.True(tree.Remove(node.FirstValue));
            Assert.Equal(new[] { 1, 2, 5, 6 }, tree.InOrderTraversal());
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
               5,
               6
            };
            //Then
            Assert.True(tree.Remove(4));
            Assert.Equal(new[] { 1, 2, 3, 5, 6 }, tree.InOrderTraversal());
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
        public void Test_RemoveChild_When_Node_Has_Only_Left_Children()
        {
            //Given
            var tree = new BinaryTreeCollection<int>
            {
               6,
               4,
               2,
               1,
               3
            };
            //Then
            Assert.True(tree.Remove(4));
            Assert.Equal(new[] { 1, 2, 3, 6 }, tree.InOrderTraversal());
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
        public void Test_RemoveMethod_When_Node_Is_Root_Size_Is_2()
        {
            //Given
            var tree = new BinaryTreeCollection<int>(2)
            {
            4,
            5,
            2,
            3,
            6,
            7
            };
            //When
            Assert.True(tree.Remove(4));
            //Then
            Assert.Equal(new[] { 2, 3, 5, 6, 7 }, tree.InOrderTraversal());
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
    }
}