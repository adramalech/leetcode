using Common.Models;
using Xunit;

namespace Common.Test.Models
{
    public class SingleListNodeTest
    {
        [Fact]
        public void TestSize()
        {
            var expectedSize = 10;
            SingleLinkedListNode root = null;
            SingleLinkedListNode current = new SingleLinkedListNode(0);
            root = current;
            
            for (var i = 1; i < 10; i++)
            {
                current.next = new SingleLinkedListNode(i);
                current = current.next;
            }

            var actualSize = SingleLinkedListNode.Size(root);
            
            Assert.Equal<int>(expectedSize, actualSize);
        }

        [Fact]
        public void TestSizeOfEmpty()
        {
            var expectedSize = 0;

            SingleLinkedListNode root = null;

            var actualSize = SingleLinkedListNode.Size(root);
            
            Assert.Equal<int>(expectedSize, actualSize);
        }
        
        [Fact]
        public void TestSizeOfOne()
        {
            var expectedSize = 1;

            SingleLinkedListNode root = new SingleLinkedListNode(0);

            var actualSize = SingleLinkedListNode.Size(root);
            
            Assert.Equal<int>(expectedSize, actualSize);
        }
    }
}