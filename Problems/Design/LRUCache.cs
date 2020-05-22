using System;
using System.Collections.Generic;

namespace Problems.Design
{
    public class Cache<T>
    {
        public Cache(T value)
        {
            this.value = value;
            this.timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
        
        public T value { get; }
        public long timestamp { get; set; }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
    public class LRUCache
    {
        private readonly Dictionary<int, Cache<int>> storage;
        private readonly int capacity;

        public LRUCache(int capacity) 
        {
            // store values.
            this.storage = new Dictionary<int, Cache<int>>(capacity);
            this.capacity = capacity;
        }
    
        public int Get(int key)
        {
            // try to get the value of the key.
            if (this.storage.TryGetValue(key, out var item))
            {
                // tick reference
                this.storage[key].timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                
                return item.value;
            }
            
            // not found.
            return -1;
        }
    
        public void Put(int key, int value) 
        {
            // if the key exists update the value.
            if (this.storage.ContainsKey(key))
            {
                this.storage[key] = new Cache<int>(value);
            }
            else
            {
                // we must remove the oldest element, because we are inserting new element.
                if (this.storage.Count + 1 > capacity)
                {
                    evictEldest();
                }
                
                // the key is not found insert key -> value pair.
                this.storage.Add(key, new Cache<int>(value));
            }
        }

        private void evictEldest()
        {
            var minKey = -1;
            var minTime = long.MaxValue;

            foreach (var k in this.storage.Keys)
            {
                if (minTime > this.storage[k].timestamp)
                {
                    minTime = this.storage[k].timestamp;
                    minKey = k;
                }
            }

            if (minKey > -1)
            {
                this.storage.Remove(minKey);
            }
        }
    }
}