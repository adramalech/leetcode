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

                    this.storage[key].next = null;
                    this.storage[key].prev = null;
                    
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

                    this.storage[key].next = null;
                    this.storage[key].prev = null;
                    
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

/*
 broken test case:
 
 INPUT:
 ["LRUCache","put","put","put","put","put","get","put","get","get","put","get","put","put","put","get","put","get","get","get","get","put","put","get","get","get","put","put","get","put","get","put","get","get","get","put","put","put","get","put","get","get","put","put","get","put","put","put","put","get","put","put","get","put","put","get","put","put","put","put","put","get","put","put","get","put","get","get","get","put","get","get","put","put","put","put","get","put","put","put","put","get","get","get","put","put","put","get","put","put","put","get","put","put","put","get","get","get","put","put","put","put","get","put","put","put","put","put","put","put"]
[[10],[10,13],[3,17],[6,11],[10,5],[9,10],[13],[2,19],[2],[3],[5,25],[8],[9,22],[5,5],[1,30],[11],[9,12],[7],[5],[8],[9],[4,30],[9,3],[9],[10],[10],[6,14],[3,1],[3],[10,11],[8],[2,14],[1],[5],[4],[11,4],[12,24],[5,18],[13],[7,23],[8],[12],[3,27],[2,12],[5],[2,9],[13,4],[8,18],[1,7],[6],[9,29],[8,21],[5],[6,30],[1,12],[10],[4,15],[7,22],[11,26],[8,17],[9,29],[5],[3,4],[11,30],[12],[4,29],[3],[9],[6],[3,4],[1],[10],[3,29],[10,28],[1,20],[11,13],[3],[3,12],[3,8],[10,9],[3,26],[8],[7],[5],[13,17],[2,27],[11,15],[12],[9,19],[2,15],[3,16],[1],[12,17],[9,1],[6,19],[4],[5],[5],[8,1],[11,7],[5,2],[9,28],[1],[2,2],[7,4],[4,22],[7,24],[9,26],[13,28],[11,26]]

OUTPUT:
[null,null,null,null,null,null,-1,null,19,17,null,-1,null,null,null,-1,null,-1,5,-1,12,null,null,3,5,5,null,null,1,null,-1,null,30,5,30,null,null,null,-1,null,-1,24,null,null,18,null,null,null,null,-1,null,null,18,null,null,-1,null,null,null,null,null,18,null,null,24,null,4,29,30,null,12,-1,null,null,null,null,29,null,null,null,null,17,22,18,null,null,null,24,null,null,null,20,null,null,null,29,18,18,null,null,null,null,20,null,null,null,null,null,null,null]

EXPECTED:
[null,null,null,null,null,null,-1,null,19,17,null,-1,null,null,null,-1,null,-1,5,-1,12,null,null,3,5,5,null,null,1,null,-1,null,30,5,30,null,null,null,-1,null,-1,24,null,null,18,null,null,null,null,-1,null,null,18,null,null,-1,null,null,null,null,null,18,null,null,-1,null,4,29,30,null,12,-1,null,null,null,null,29,null,null,null,null,17,22,18,null,null,null,-1,null,null,null,20,null,null,null,-1,18,18,null,null,null,null,20,null,null,null,null,null,null,null]
*/