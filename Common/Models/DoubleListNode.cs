using System.Text;

namespace Common.Models
{
    public class DoubleListNode
    {
        public DoubleListNode prev { get; set; }
        public DoubleListNode next { get; set; }
        public int value { get; set; }
        public int key { get; }
        
        public DoubleListNode(int key, int value)
        {
            this.value = value;
            this.key = key;
        }
        
        public static string PrintHeadToTail(DoubleListNode node)
        {
            return printNodes(node, false);
        }

        public static string PrintTailtoHead(DoubleListNode node)
        {
            return printNodes(node, true);
        }

        private static string printNodes(DoubleListNode node, bool followPrevious)
        {
            var sb = new StringBuilder();

            if (followPrevious)
            {
                while (node != null)
                {
                    sb.Append($"{node.key}->{node.value}, ");
                    node = node.prev;
                }
            }
            else
            {
                while (node != null)
                {
                    sb.Append($"{node.key}->{node.value}, ");
                    node = node.next;
                }
            }

            return sb.ToString();
        }
    }
}