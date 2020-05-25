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
    }
}