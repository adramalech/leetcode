using fb.LinkedLists;
using Xunit;

namespace Fb.Test.LinkedLists
{
    public class LinkedListProblemsTest
    {
        [Theory]
        [InlineData(
            new int [] { 3, 2, 1 }, 
            new int [] { 6, 5, 4 }, 
            new int[] { 9, 7, 5 }
        )] // 321 + 654 = 975
        [InlineData(
            new int [] { 2, 4, 3 }, 
            new int [] { 5, 6, 4 }, 
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
            var l1 = generateList(num1);
            var l2 = generateList(num2);
            var expectedResults = generateList(expectedNum);
            var linkedListProblems = new LinkedListProblems();

            var actualResults = linkedListProblems.AddTwoNumbers(l1, l2);
            
            Assert.NotNull(expectedResults);
            Assert.True(areListsEqual(expectedResults, actualResults));
        }
        
        private ListNode generateList(int[] nums)
        {
            var current = new ListNode(nums[0]);

            for (var i = 1; i < nums.Length; i++)
            {
                var node = new ListNode(nums[i]);
                node.next = current;
                current = node;
            }

            return current;
        }

        private bool areListsEqual(ListNode ln1, ListNode ln2)
        {
            // if one list is null or the other is return false.
            if (ln1 == null ^ ln2 == null)
            {
                 return false;
            }
            
            // if one list has a next and the other doesn't return false.
            if (ln1.next == null ^ ln2.next == null)
            {
                return false;
            }
            
            // iterate over both lists.
            do
            {
                // if the values don't match return false.
                if (ln1.val != ln2.val)
                {
                    return false;
                }

                // go next.
                ln1 = ln1.next;
                ln2 = ln2.next;
            } while (ln1 != null && ln2 != null); // if next is null break out else continue looping.
            
            return true;
        }
    }
}