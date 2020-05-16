using LinkedLists;
using Xunit;
using Common.Models;

namespace Fb.Test.LinkedLists
{
    public class LinkedListProblemsTest
    {
        [Theory]
        [InlineData(
            new int[] { 1, 2, 3 }, 
            new int[] { 4, 5, 6 }, 
            new int[] { 9, 7, 5 }
        )] // 321 + 654 = 975
        [InlineData(
            new int [] { 3, 4, 2 }, 
            new int [] { 4, 6, 5 }, 
            new int[] { 8, 0, 7 }
        )] // 342 + 465 = 807
        [InlineData(
            new int [] { 9 }, 
            new int [] { 9, 9, 9, 9, 9, 9, 9, 9, 9, 1 }, 
            new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        )]
        [InlineData(
            new int [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, 
            new int [] { 4, 6, 5 }, 
            new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 6, 6 }
        )] 
        public void TestAddTwoNumbers(int[] num1, int[] num2, int[] expectedNum)
        {
            var l1 = SingleLinkedListNode.GenerateList(num1);
            var l2 = SingleLinkedListNode.GenerateList(num2);
            var expectedResults = SingleLinkedListNode.GenerateList(expectedNum);
            var linkedListProblems = new LinkedListProblems();

            var actualResults = linkedListProblems.AddTwoNumbers(l1, l2);
            
            Assert.NotNull(expectedResults);
            Assert.True(SingleLinkedListNode.AreListsEqual(expectedResults, actualResults));
        }

        [Theory]
        [InlineData(
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 1, 2, 3, 4, 5, 6 }
        )]
        [InlineData(
            new int[] { 1, 2, 4 },
            new int[] { 1, 3, 4 },
            new int[] { 1, 1, 2, 3, 4, 4 }
        )]
        [InlineData(
            new int[] { 1 },
            new int [] { 2 },
            new int [] { 1, 2 }
        )]
        public void TestMergeTwoLists(int[] num1, int[] num2, int[] expectedNum)
        {
            var l1 = SingleLinkedListNode.GenerateList(num1);
            var l2 = SingleLinkedListNode.GenerateList(num2);
            var expectedResults = SingleLinkedListNode.GenerateList(expectedNum);
            var linkedListProblems = new LinkedListProblems();

            var actualResults = linkedListProblems.MergeTwoLists(l1, l2);
            
            Assert.NotNull(expectedResults);
            Assert.True(SingleLinkedListNode.AreListsEqual(expectedResults, actualResults));
        }
    }
}