using Problems.LinkedLists;
using Xunit;
using Common.Models;

namespace Problems.Test.LinkedLists
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

        [Fact]
        public void TestMergeKLists()
        {
            var linkedListProblems = new LinkedListProblems();
            
            var inputs = new int[3][] {new int[3] {1, 4, 5}, new int[3] {1, 3, 4}, new int[2] {2, 6}};
            var expectedResults = SingleLinkedListNode.GenerateList(new int[] {1, 1, 2, 3, 4, 4, 5, 6});

            SingleLinkedListNode[] lists = new SingleLinkedListNode[]
            {
                SingleLinkedListNode.GenerateList(inputs[0]),
                SingleLinkedListNode.GenerateList(inputs[1]),
                SingleLinkedListNode.GenerateList(inputs[2]),
            };

            var actualResults = linkedListProblems.MergeKLists(lists);

            Assert.True(SingleLinkedListNode.AreListsEqual(expectedResults, actualResults));
        }
        
        [Fact]
        public void TestMergeKListsBruteForce()
        {
            var linkedListProblems = new LinkedListProblems();
            
            var inputs = new int[3][] {new int[3] {1, 4, 5}, new int[3] {1, 3, 4}, new int[2] {2, 6}};
            var expectedResults = SingleLinkedListNode.GenerateList(new int[] {1, 1, 2, 3, 4, 4, 5, 6});

            SingleLinkedListNode[] lists = new SingleLinkedListNode[]
            {
                SingleLinkedListNode.GenerateList(inputs[0]),
                SingleLinkedListNode.GenerateList(inputs[1]),
                SingleLinkedListNode.GenerateList(inputs[2]),
            };

            var actualResults = linkedListProblems.MergeKListsBruteForce(lists);

            Assert.True(SingleLinkedListNode.AreListsEqual(expectedResults, actualResults));
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 3, new int[] {1, 2, 3, 4, 5, 6, 8, 9})]
        public void TestRemoveNthFromEnd(int[] list, int n, int[] expected)
        {
            var linkedListProblems = new LinkedListProblems();
            var expectedResults = SingleLinkedListNode.GenerateList(expected);
            var input = SingleLinkedListNode.GenerateList(list);

            var actualResults = linkedListProblems.RemoveNthFromEnd(input, n);

            Assert.True(SingleLinkedListNode.AreListsEqual(expectedResults, actualResults));
        }

        [Theory]
        [InlineData(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, new int[] {9, 8, 7, 6, 5, 4, 3, 2, 1})]
        public void TestReverseList(int[] list, int[] expectedOutput)
        {
            var linkedListProblems = new LinkedListProblems();

            var input = SingleLinkedListNode.GenerateList(list);
            var expectedResults = SingleLinkedListNode.GenerateList(expectedOutput);
            
            var actualResults = linkedListProblems.ReverseList(input);
            
            Assert.True(SingleLinkedListNode.AreListsEqual(expectedResults, actualResults));
        }
        
        [Theory]
        [InlineData(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, new int[] {9, 8, 7, 6, 5, 4, 3, 2, 1})]
        public void TestReverseListRecursion(int[] list, int[] expectedOutput)
        {
            var linkedListProblems = new LinkedListProblems();

            var input = SingleLinkedListNode.GenerateList(list);
            var expectedResults = SingleLinkedListNode.GenerateList(expectedOutput);
            
            var actualResults = linkedListProblems.ReverseListRecursion(input);
            
            Assert.True(SingleLinkedListNode.AreListsEqual(expectedResults, actualResults));
        }
    }
}