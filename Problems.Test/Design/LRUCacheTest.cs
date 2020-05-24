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

            // put 10 in the cache with value 13. count = 1
            cache.Put(10, 13);
            
            // put 3 on the cache which makes 10 eldest. count = 2
            cache.Put(3, 17);
            
            // put 6 on the cache which 10 is the eldest. count = 3
            cache.Put(6, 11);
            
            // update 10 on the stack, 3 is eldest. count = 3
            cache.Put(10, 5);
            
            // put 9 on the stack makes 3 eldest count = 4
            cache.Put(9, 10);

            // look for key 13 not found return -1
            Assert.Equal<int>(-1, cache.Get(13));
            
            // add 2 to cache, 3 is eldest. count = 5
            cache.Put(2, 19);
            
            // 2 is already youngest, just return value.
            Assert.Equal<int>(19, cache.Get(2));
            
            // make 3 youngest, return 17, 6 is eldest.
            Assert.Equal<int>(17, cache.Get(3));

            // put 5 on cache, 6 is eldest, count = 6
            cache.Put(5, 25);

            // get key 8 not found return -1
            Assert.Equal<int>(-1, cache.Get(8));
            
            // update 9 on the cache, make 9 youngest, 6 is eldest count = 6. 
            cache.Put(9, 22);
            
            // update 5 on the cache, make 5 youngest, 6 is eldest. count = 6
            cache.Put(5, 5);
            
            // add 1 with value 30, 1 is youngest, 6 is eldest, count = 7.
            cache.Put(1, 30);
            
            // get key 11, but not found return -1
            Assert.Equal<int>(-1, cache.Get(11));

            // update 9, make 9 youngest, 6 is eldest count = 7
            cache.Put(9, 12);
            
            // get 7 not found return -1.
            Assert.Equal<int>(-1, cache.Get(7));
            
            // get 5 return 5, set 5 youngest, 6 is eldest.
            Assert.Equal<int>(5, cache.Get(5));
            
            // get 8 not found return -1.
            Assert.Equal<int>(-1, cache.Get(8));
            
            // get 9 return 12, set 9 youngest, 6 is eldest.
            Assert.Equal<int>(12, cache.Get(9));
            
            // add 4 with 30, set 4 youngest, 6 is eldest. count = 8.
            cache.Put(4, 30);
            
            // update 9 with 3, set 9 youngest, 6 is eldest, count = 8.
            cache.Put(9,  3);
            
            // 9 is already youngest, return 3.
            Assert.Equal<int>(3, cache.Get(9));

            // 10 is now youngest, 6 is eldest.
            Assert.Equal<int>(5, cache.Get(10));
            
            // 10 is already youngest, return 5, 6 is eldest.
            Assert.Equal<int>(5, cache.Get(10));
            
            // update 6 to be youngest, eldest is 2,  count = 8.
            cache.Put(6, 14);
            
            // update 3 to be youngest, eldest is 2,  count = 8.
            cache.Put(3, 1);
            
            // 3 is already youngest, return 1
            Assert.Equal<int>(1, cache.Get(3));

            // update 10 to be youngest, 2 is eldest, count = 8
            cache.Put(10, 11);
            
            // key 8 not found return -1
            Assert.Equal<int>(-1, cache.Get(8));
            
            // update 2 to be youngest, eldest is 1, count = 8.
            cache.Put(2, 14);

            // get 1 setting 1 youngest, and 5 is eldest
            Assert.Equal<int>(30, cache.Get(1));
            
            // get 5 setting 5 to be youngest, and 4 is eldest
            Assert.Equal<int>(5, cache.Get(5));
            
            // get 4 setting 4 to be youngest, and 9 is eldest
            Assert.Equal<int>(30, cache.Get(4));
            
            // add 11 with 4 as youngest, 9 is eldest, count = 9
            cache.Put(11, 4);
            
            // add 12 with 24 as youngest, 9 is eldest, count = 10
            cache.Put(12, 24);
            
            // update 5 to be youngest, 9 is eldest, count = 10
            cache.Put(5, 18);
            
            // get key 13 not found return -1
            Assert.Equal<int>(-1, cache.Get(13));
            
            // add 7 with 23 as youngest, evict eldest 9, eldest is now 6, count = 10
            cache.Put(7, 23);
            
            // get key 8 not found return -1
            Assert.Equal<int>(-1, cache.Get(8));
            
            // get key 12, return 24, set 12 as youngest, 6 is eldest
            Assert.Equal<int>(24, cache.Get(12));
            
            // update 3 to 27, set 3 youngest, 6 is eldest, count = 10
            cache.Put(3, 27);
            
            // update 2 with 12, set 2 youngest, 6 is eldest, count = 10
            cache.Put(2, 12);
            
            // get 5 return 18 set 5 youngest, 6 is eldest.
            Assert.Equal<int>(18, cache.Get(5));

            // update 2 with 9, set 2 youngest, 6 is eldest, count = 10
            cache.Put(2, 9);
            
            // add 13 with 4, evict eldest 6, 10 is eldest, count = 10
            cache.Put(13, 4);
            
            // add 8 with 18, evict eldest 10, 1 is eldest, count = 10
            cache.Put(8, 18);
            
            // update 1 to be youngest, 4 is eldest, count = 10
            cache.Put(1, 7);
            
            // get 6, it was evicted before, so not found return -1
            Assert.Equal<int>(-1, cache.Get(6));
            
            // add 9 with 29, 9 is youngest, evict 4 as eldest, 11 is eldest, count = 10
            cache.Put(9, 29);
            
            // update 8 as youngest, 11 is eldest, count = 10
            cache.Put(8, 21);
            
            // get 5 return 18, 5 is youngest, 11 is eldest
            Assert.Equal<int>(18, cache.Get(5));
            
            // add 6 with 30, set 6 as youngest, evict eldest 11, 7 is eldest, count = 10
            cache.Put(6, 30);
            
            // update 1 to 12, set 1 youngest, 7 is eldest, count = 10
            cache.Put(1, 12);
            
            // get 10 but it was evicted, return -1
            Assert.Equal<int>(-1, cache.Get(10));
            
            // add 4 with 15, 4 is youngest, evict eldest 7, set 12 eldest, count = 10
            cache.Put(4, 15);
            
            // add 7 with 22, 7 is youngest, evict eldest 12, set 3 eldest, count = 10
            cache.Put(7, 22);
            
            // add 11 with 26, 11 is youngest, evict eldest 3, set 2 eldest, count = 10
            cache.Put(11, 26);
            
            // update 8 as 17, set 8 youngest, 2 is eldest, count = 10 
            cache.Put(8, 17);
            
            // update 9 as 29, set 9 youngest, 2 is eldest, count = 10
            cache.Put(9, 29);
            
            // get 5 return 18, set 5 youngest, 2 is eldest, count = 10
            Assert.Equal<int>(18, cache.Get(5));
            
            // add 3 with 4, set 3 youngest, evict eldest 2, set 13 eldest, count = 10
            cache.Put(3, 4);
            
            // update 11 with 30, set 11 youngest, 13 is eldest, count = 10
            cache.Put(11, 30);
            
            // fails here. expected -1 got 24. (it wasn't evicted properly)
            // 12 was evicted, key not found, return -1
            Assert.Equal<int>(-1, cache.Get(12));
            
            // update 4 with 29, set youngest, 13 is eldest, count =  10
            cache.Put(4, 29);
            
            // get 3 return 4, set 3 youngest, 13 is eldest
            Assert.Equal<int>(4, cache.Get(3));
            
            // get 9 return 29, set 9 youngest, 13 is eldest
            Assert.Equal<int>(29, cache.Get(9));

            // get 6 return 30, set 6 youngest, 13 is eldest
            Assert.Equal<int>(30, cache.Get(6));
            
            // update 3 with 4, set 3 youngest, 13 is eldest, count = 10
            cache.Put(3, 4);
            
            // get 1 returns 12, set 1 youngest, 13 is eldest
            Assert.Equal<int>(12, cache.Get(1));
            
            // 10 was evicted before, key not found, return -1
            Assert.Equal<int>(-1, cache.Get(10));
            
            // update 3 with 29, set 3 youngest, 13 is eldest, count = 10
            cache.Put(3, 29);
            
            // add 10 with 28, set 10 youngest, evict 13 eldest, set 7 eldest, count = 10
            cache.Put(10, 28);
            
            // update 1 with 20, set 1 youngest, eldest is 7, count = 10
            cache.Put(1, 20);
            
            // update 11 with 13, set 11 youngest, eldest is 7, count = 10
            cache.Put(11, 13);
            
            // get 3, set 3 youngest, 7 is eldest
            Assert.Equal<int>(29, cache.Get(3));
            
            // update 3 with 12, 3 is youngest, 7 is eldest, count = 10
            cache.Put(3, 12);
            
            // update 3 with 8, 3 is youngest, 7 is eldest, count = 10
            cache.Put(3, 8);
            
            // update 10 with 9, set 10 youngest, 7 is eldest, count = 10
            cache.Put(10, 9);
            
            // update 3 with 26, set 3 youngest, eldest is 7, count = 10
            cache.Put(3, 26);

            // get 8 return 17, set 8 youngest, 7 is eldest
            Assert.Equal<int>(17, cache.Get(8));
            
            // get 7 return 22, set 7 youngest, 5 is eldest
            Assert.Equal<int>(22, cache.Get(7));
            
            // get 5 return 18, set 5 youngest, 4 is eldest
            Assert.Equal<int>(18, cache.Get(5));
            
            // add 13 with 17, set 13 youngest, evict the eldest 4, set 9 as eldest, count = 10
            cache.Put(13, 17);
            
            // add 2 with 27 as youngest, evict eldest 9, set 6 eldest, count = 10
            cache.Put(2, 27);
            
            // update 11 with 15, set 11 youngest, eldest is 6, count = 10
            cache.Put(11, 15);
            
            // get 12 was evicted key not found return -1
            Assert.Equal<int>(-1, cache.Get(12));

            // add 9 with 19, set 9 youngest, evict eldest 6, set 1 eldest, count = 10
            cache.Put(9, 19);
            
            // add 2 with 15, set 2 youngest, evict eldest 1, set 10 eldest, count = 10
            cache.Put(2, 15);
            
            // update 3 with 16, set 3 youngest, 10 is eldest, count = 10
            cache.Put(3, 16);
            
            // problem 1 was evicted go back and replay from 1 being evicted this is problem.
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