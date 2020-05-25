using System.Collections.Generic;
using Common.Models;

namespace Problems.Design
{
    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
    public class LRUCache
    {
        private readonly Dictionary<int, DoubleListNode> storage;
        private readonly int capacity;
        private DoubleListNode head;
        private DoubleListNode tail;
        
        public LRUCache(int capacity) 
        {
            this.storage = new Dictionary<int, DoubleListNode>(capacity);
            this.capacity = capacity;
            this.head = new DoubleListNode(int.MinValue, int.MinValue);
            this.tail = new DoubleListNode(int.MaxValue, int.MaxValue);
            this.head.next = this.tail;
            this.tail.prev = this.head;
        }
        
        public int Get(int key)
        {
            // try to get the value of the key.
            if (this.storage.ContainsKey(key))
            {
                int value = this.storage[key].value;
                
                // if this value isn't head.next, move it to be head.next.
                if (this.storage[key].key != head.next.key)
                {
                    // bypass previous to next, and next to previous skipping current.
                    this.storage[key].prev.next = this.storage[key].next;
                    this.storage[key].next.prev = this.storage[key].prev;

                    this.storage[key].prev = this.head;
                    this.storage[key].next = this.head.next;
                    
                    // move current to between head and head.next.
                    this.head.next.prev = this.storage[key];
                    this.head.next = this.storage[key];
                }

                return value;
            }

            // not found.
            return -1;
        }
        
        public void Put(int key, int value) 
        {
            // if the key exists update the value.
            if (this.storage.ContainsKey(key))
            {
                // update the value.
                this.storage[key].value = value;

                // if this value isn't head.next, move it to be head.next.
                if (this.storage[key].key != head.next.key)
                {
                    // bypass previous to next, and next to previous skipping current.
                    this.storage[key].prev.next = this.storage[key].next;
                    this.storage[key].next.prev = this.storage[key].prev;

                    this.storage[key].prev = this.head;
                    this.storage[key].next = this.head.next;
                    
                    // move current to between head and head.next.
                    this.head.next.prev = this.storage[key];
                    this.head.next = this.storage[key];
                }
            }
            else
            {
                // we must remove the oldest element, because we are inserting new element.
                if (this.storage.Count + 1 > capacity)
                {
                    evictEldest();
                }
                
                // create new node and attach it to head and head.next
                var node = new DoubleListNode(key, value);
                node.prev = head;
                node.next = head.next;
                
                // target head and head.next to new node.
                head.next.prev = node;
                head.next = node;

                this.storage.Add(key, node);
            }
        }
        
        private void evictEldest()
        {
            var key = tail.prev.key;

            // this below bypasses the node previous tail by removing the pointers.
            
            // the tail's previous previous next should point to tail.
            tail.prev.prev.next = tail;
            
            // tail previous should point to previous previous node.
            tail.prev = tail.prev.prev;

            if (this.storage.ContainsKey(key))
            {
                this.storage.Remove(key);
            }
        }
    }
}