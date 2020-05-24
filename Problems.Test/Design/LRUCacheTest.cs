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

        [Fact]
        public void TestLRUCacheLong()
        {
            // set up the cache.
            var cache = new LRUCache(10);

            cache.Put(10, 13);
            cache.Put(3, 17);
            cache.Put(6, 11);
            cache.Put(10, 5);
            cache.Put(9, 10);

            Assert.Equal<int>(-1, cache.Get(13));
            
            cache.Put(2, 19);
            
            Assert.Equal<int>(19, cache.Get(2));
            
            Assert.Equal<int>(17, cache.Get(3));

            cache.Put(5, 25);

            Assert.Equal<int>(-1, cache.Get(8));
            
            cache.Put(9, 22);
            cache.Put(5, 5);
            cache.Put(1, 30);
            
            Assert.Equal<int>(-1, cache.Get(11));

            cache.Put(9, 12);
            
            Assert.Equal<int>(-1, cache.Get(7));
            
            Assert.Equal<int>(5, cache.Get(5));
            
            Assert.Equal<int>(-1, cache.Get(8));
            
            Assert.Equal<int>(12, cache.Get(9));
            
            cache.Put(4, 30);
            cache.Put(9,  3);
            
            Assert.Equal<int>(3, cache.Get(9));

            Assert.Equal<int>(5, cache.Get(10));
            
            Assert.Equal<int>(5, cache.Get(10));
            
            cache.Put(6, 14);
            cache.Put(3, 1);
            
            Assert.Equal<int>(1, cache.Get(3));

            cache.Put(10, 11);
            
            Assert.Equal<int>(-1, cache.Get(8));
            
            cache.Put(2, 14);

            Assert.Equal<int>(30, cache.Get(1));
            
            Assert.Equal<int>(5, cache.Get(5));
            
            Assert.Equal<int>(30, cache.Get(4));
            
            cache.Put(11, 4);
            cache.Put(12, 24);
            cache.Put(5, 18);
            
            Assert.Equal<int>(-1, cache.Get(13));
            
            cache.Put(7, 23);
            
            Assert.Equal<int>(-1, cache.Get(8));
            
            Assert.Equal<int>(24, cache.Get(12));
            
            cache.Put(3, 27);
            cache.Put(2, 12);
            
            Assert.Equal<int>(18, cache.Get(5));

            cache.Put(2, 9);
            cache.Put(13, 4);
            cache.Put(8, 18);
            cache.Put(1, 7);
            
            Assert.Equal<int>(-1, cache.Get(6));
            
            cache.Put(9, 29);
            cache.Put(8, 21);
            
            Assert.Equal<int>(18, cache.Get(5));
            
            cache.Put(6, 30);
            cache.Put(1, 12);
            
            Assert.Equal<int>(-1, cache.Get(10));
            
            cache.Put(4, 15);
            cache.Put(7, 22);
            cache.Put(11, 26);
            cache.Put(8, 17);
            cache.Put(9, 29);
            
            Assert.Equal<int>(18, cache.Get(5));
            
            cache.Put(3, 4);
            cache.Put(11, 30);
            
            Assert.Equal<int>(-1, cache.Get(12));
            
            cache.Put(4, 29);
            
            Assert.Equal<int>(4, cache.Get(3));
            
            Assert.Equal<int>(29, cache.Get(9));

            Assert.Equal<int>(30, cache.Get(6));
            
            cache.Put(3, 4);
            
            Assert.Equal<int>(12, cache.Get(1));
            
            Assert.Equal<int>(-1, cache.Get(10));
            
            cache.Put(3, 29);
            cache.Put(10, 28);
            cache.Put(1, 20);
            cache.Put(11, 13);
            
            Assert.Equal<int>(29, cache.Get(3));
            
            cache.Put(3, 12);
            cache.Put(3, 8);
            cache.Put(10, 9);
            cache.Put(3, 26);

            Assert.Equal<int>(17, cache.Get(8));
            
            Assert.Equal<int>(22, cache.Get(7));
            
            Assert.Equal<int>(18, cache.Get(5));
            
            cache.Put(13, 17);
            cache.Put(2, 27);
            cache.Put(11, 15);
            
            Assert.Equal<int>(-1, cache.Get(12));

            cache.Put(9, 19);
            cache.Put(2, 15);
            cache.Put(3, 16);
            
            Assert.Equal<int>(20, cache.Get(1));
            
            cache.Put(12, 17);
            cache.Put(9, 1);
            cache.Put(6, 19);
            
            Assert.Equal<int>(-1, cache.Get(4));
            
            Assert.Equal<int>(18, cache.Get(5));
            
            Assert.Equal<int>(18, cache.Get(5));
            
            cache.Put(8, 1);
            cache.Put(11, 7);
            cache.Put(5, 2);
            cache.Put(9, 28);
            
            Assert.Equal<int>(20, cache.Get(1));
            
            cache.Put(2, 2);
            cache.Put(7, 4);
            cache.Put(4, 22);
            cache.Put(7, 24);
            cache.Put(9, 26);
            cache.Put(13, 28);
            cache.Put(11, 26);
        }
    }
}