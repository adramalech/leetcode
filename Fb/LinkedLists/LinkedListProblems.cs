using System.Collections.Generic;
using System.Numerics;

namespace fb.LinkedLists
{
    public class ListNode
    {
        public int val { get; private set; }
        public ListNode next;

        public ListNode(int x)
        {
            this.val = x;
            this.next = null;
        }
    }
    
    public class LinkedListProblems
    {
        /*
         *  Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
         *  Output: 7 -> 0 -> 8
         *  Explanation: 342 + 465 = 807.
         */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)
            {
                return null;
            }
            
            BigInteger n1 = 0;
            BigInteger n2 = 0;
            int place = 0;

            // get first number value.
            do
            {
                n1 = BigInteger.Add(n1, BigInteger.Multiply(l1.val, BigInteger.Pow(10, place++)));
                l1 = l1.next;
            } while (l1 != null);

            // reset place.
            place = 0;
            
            // get the second number value.
            do
            {
                n2 = BigInteger.Add(n2, BigInteger.Multiply(l2.val, BigInteger.Pow(10, place++)));
                l2 = l2.next;
            } while (l2 != null);

            // get the sum of the two numbers.
            BigInteger sum = BigInteger.Add(n1, n2);
            
            // get the digit.
            int n;

            // add it in reverse by first push each digit onto the stack
            // then reverse order insert them.
            var s = new Stack<int>();

            int count = 0;
            do
            {
                // get the digit.
                n = (int)(sum % 10);
                
                //push the digit.
                s.Push(n);
                
                // count the digits on stack.
                count++;
                
                // remove the digit.
                sum /= 10;
            } while (sum > 0);

            var current = new ListNode(s.Pop());
            count--;
            
            while (count > 0)
            {
                var node = new ListNode(s.Pop());
                node.next = current;
                current = node;
                count--;
            }

            return current;
        }
        
        /*
         Input: 1->2->4, 1->3->4
         Output: 1->1->2->3->4->4
         */
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode t = new ListNode(0);
            head = t;
            
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    t.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    t.next = l2;
                    l2 = l2.next;
                }
            
                t = t.next;
            }

            if (l1 != null)
            {
                t.next = l1;
            }

            if (l2 != null)
            {
                t.next = l2;
            }

            return head.next;
        }
    }
}