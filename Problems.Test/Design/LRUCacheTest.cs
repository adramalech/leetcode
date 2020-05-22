using Problems.Design;
using Xunit;

namespace Problems.Test.Design
{
    public class LRUCacheTest
    {
        [Fact]
        public void TestLRUCache()
        {
            // set up the cache.
            var cache = new LRUCache(2);
            
            // cache has 1, empty by 1
            cache.Put(1, 1);
            
            // cache is full 2 with 1 and 2
            cache.Put(2, 2);
            
            // get 1 sets 1 youngest and 2 the eldest.
            Assert.Equal<int>(1, cache.Get(1));
            
            // oh no over capacity, 3 insert remove eldest 2, and insert 3, making 1 eldest.
            cache.Put(3, 3);
            
            // 2 should have been evicted, so return -1
            Assert.Equal<int>(-1, cache.Get(2));
            
            // oh no over capacity, remove eldest 1, 3 is now eldest, insert 4.
            cache.Put(4, 4);
            
            // 1 has been evicted should return -1.
            Assert.Equal<int>(-1, cache.Get(1));
            
            // 3 is eldest and should return 3.
            Assert.Equal<int>(3, cache.Get(3));
            
            // 4 is youngest and should return 4.
            Assert.Equal<int>(4, cache.Get(4));
        }
    }
}