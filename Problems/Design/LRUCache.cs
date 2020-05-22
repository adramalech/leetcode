using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Design
{
    public class Cache<T>
    {
        public Cache(T value)
        {
            this.value = value;
            this.timestamp = DateTimeOffset.Now.Ticks;
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
                this.storage[key].timestamp = DateTimeOffset.Now.Ticks;
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
        
        // sub-optimal solution O(n) linear
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
    
    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
    public class LRUCacheDictionary
    {
        private readonly Dictionary<int, Cache<int>> storage;
        private readonly int capacity;
        private int size;
        private readonly SortedDictionary<long, int> expirationTracking;
        
        public LRUCacheDictionary(int capacity) 
        {
            // store values.
            this.storage = new Dictionary<int, Cache<int>>(capacity);
            this.expirationTracking = new SortedDictionary<long, int>();
            this.capacity = capacity;
            this.size = 0;
        }
    
        public int Get(int key)
        {
            // try to get the value of the key.
            if (this.storage.TryGetValue(key, out var item))
            {
                this.expirationTracking.Remove(this.storage[key].timestamp);
                this.storage[key].timestamp = DateTimeOffset.Now.Ticks;
                this.expirationTracking.Add(this.storage[key].timestamp, key);
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
                this.expirationTracking.Remove(this.storage[key].timestamp);
                this.storage[key] = new Cache<int>(value);
                this.expirationTracking.Add(this.storage[key].timestamp, key);
            }
            else
            {
                // we must remove the oldest element, because we are inserting new element.
                if (this.size + 1 > capacity)
                {
                    evictEldest();
                }
                
                // the key is not found insert key -> value pair.
                this.storage.Add(key, new Cache<int>(value));
                this.expirationTracking.Add(this.storage[key].timestamp, key);
                this.size++;
            }
        }

        private void evictEldest()
        {
            var key = this.expirationTracking.First().Key;
            this.storage.Remove(this.expirationTracking[key]);
            this.expirationTracking.Remove(key);
            this.size--;
        }
    }
}