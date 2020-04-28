namespace Common.Models
{
    public class SingleLinkedListNode
    {
        public readonly int val;
        public SingleLinkedListNode next;

        public SingleLinkedListNode(int x)
        {
            this.val = x;
            this.next = null;
        }
        
        public static SingleLinkedListNode GenerateList(int[] nums)
        {
            SingleLinkedListNode head = null;
            SingleLinkedListNode current = new SingleLinkedListNode(nums[0]);
            head = current;
            
            for (var i = 1; i < nums.Length; i++)
            {
                current.next = new SingleLinkedListNode(nums[i]);
                current = current.next;
            }

            return head;
        }

        public static bool AreListsEqual(SingleLinkedListNode ln1, SingleLinkedListNode ln2)
        {
            // if one list is null or the other is return false.
            if (ln1 == null || ln2 == null)
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