using System.Collections.Generic;
using System.Numerics;
using Common.Models;

namespace Problems.LinkedLists
{
    public class LinkedListProblems
    {
        /*
         *  Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
         *  Output: 7 -> 0 -> 8
         *  Explanation: 342 + 465 = 807.
         */
        public SingleLinkedListNode AddTwoNumbers(SingleLinkedListNode l1, SingleLinkedListNode l2)
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

            var current = new SingleLinkedListNode(s.Pop());
            count--;
            
            while (count > 0)
            {
                var node = new SingleLinkedListNode(s.Pop());
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
        public SingleLinkedListNode MergeTwoLists(SingleLinkedListNode l1, SingleLinkedListNode l2)
        {
            SingleLinkedListNode head = null;
            SingleLinkedListNode t = new SingleLinkedListNode(0);
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
        
        /*
         Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
         
         Input:
            [
              1 -> 4 -> 5,
              1 -> 3 -> 4,
              2 -> 6
            ]
            
         Output: 1 -> 1 -> 2 -> 3 -> 4 -> 4 -> 5 -> 6
         */
        public SingleLinkedListNode MergeKListsBruteForce(SingleLinkedListNode[] lists)
        {
            SingleLinkedListNode head = null;
            SingleLinkedListNode current = new SingleLinkedListNode(int.MinValue);
            head = current;

            // iterate until lists are empty.
            // 1. keep track of empty count. if we become empty in search break.
            // 2. find the current minimum value. push that onto the list.
            // 3. remove the found value 
            while (true)
            {
                // find the minimum value list.
                int minListIndex = -1;
                int emptyCount = 0;
                int minValue = int.MaxValue;
                
                var length = lists.Length;
                
                // O(m)
                for (var i = 0; i < length; i++)
                {
                    if (lists[i] == null)
                    {
                        emptyCount++;
                        continue;
                    }

                    if (lists[i].val < minValue)
                    {
                        minListIndex = i;
                        minValue = lists[i].val;
                    }
                }
                
                // when the lists are empty return.
                if (emptyCount == length)
                {
                    break;
                }
                
                // fast forward next after we found the min value.
                lists[minListIndex] = lists[minListIndex].next;
                
                // found the minimum list index set it and fast forward next.
                current.next = new SingleLinkedListNode(minValue);
                current = current.next;
            }
            
            return head.next;
        }
        
        public SingleLinkedListNode MergeKLists(SingleLinkedListNode[] lists)
        {
            SingleLinkedListNode head = null;
            SingleLinkedListNode current = new SingleLinkedListNode(int.MinValue);
            head = current;

            int minValue = int.MaxValue;
            int maxValue = int.MinValue;

            // val -> count
            var lookup = new Dictionary<int, int>();

            var length = lists.Length;
            
            // iterate over each list.
            for (var i = 0; i < length; i++)
            {
                // add each element to the list.
                while (lists[i] != null)
                {
                    if (lookup.ContainsKey(lists[i].val))
                    {
                        lookup[lists[i].val]++;
                    }
                    else
                    {
                        lookup.Add(lists[i].val, 1);

                        // if the number is the min we have seen add as minimum.
                        if (lists[i].val < minValue)
                        {
                            minValue = lists[i].val;
                        }

                        // if it is the maximum we have seen add as maximum.
                        if (lists[i].val > maxValue) 
                        {
                            maxValue = lists[i].val;
                        }
                    }
                
                    lists[i] = lists[i].next;
                }
            }

            var num = minValue;

            while (num <= maxValue)
            {
                if (lookup.ContainsKey(num))
                {
                    while (lookup[num] > 0)
                    {
                        current.next = new SingleLinkedListNode(num);
                        current = current.next;
                        lookup[num]--;
                    }
                }

                num++;
            }

            return head.next;
        }
        
        // Space O(n)
        // Time O(n)
        public SingleLinkedListNode RemoveNthFromEnd(SingleLinkedListNode head, int n)
        {
            if (head == null)
            {
                return null;
            }

            var size = SingleLinkedListNode.Size(head);

            // when we reach this count we will return next as current.
            var count = size - n;

            // if we found removing N is greater than length of linked list return the linked list.
            if (count < 0)
            {
                return head;
            }

            // if it is head return next.
            if (count == 0)
            {
                return head.next;
            }

            // it is found somewhere between 1 and size - 1.
            SingleLinkedListNode newHead = null;
            var current = new SingleLinkedListNode(head.val);
            newHead = current;
            head = head.next;

            while (head != null)
            {
                // we are at the current node to remove, add the tail of head.
                if (count == 1)
                {
                    current.next = head.next;
                    break;
                }

                count--;
                current.next = new SingleLinkedListNode(head.val);
                current = current.next;
                head = head.next;
            }
            
            return newHead;
        }
    }
}