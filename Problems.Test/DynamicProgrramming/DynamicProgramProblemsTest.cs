using Xunit;
using Problems.DynamicProgramming;

namespace Problems.Test.DynamicProgramming
{
    public class DynamicProgramProblemsTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(11, 55)]
        [InlineData(50, 7778742049)]
        public void TestFibonacci(int n, ulong expectedValue)
        {
            var problems = new DynamicProgrammingProblems();

            var actualValue = problems.Fibonacci(n);
            
            Assert.Equal<ulong>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(11, 55)]
        [InlineData(50, 7778742049)]
        public void TestFibonacciConstantSpace(int n, ulong expectedValue)
        {
            var problems = new DynamicProgrammingProblems();

            var actualValue = problems.FibonnaciWithConstantSpace(n);
            
            Assert.Equal<ulong>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("", "")] // ""
        [InlineData("bb", "bb")]  // "b", "bb"
        [InlineData("aaaa", "aaaa")] // "a", "aa", "aaa", "aaaa"
        [InlineData("ab", "a")] // "a", "b"
        [InlineData("abab", "aba")] // "a", "b", "aba", "bab"
        [InlineData("abcdefgh", "a")] // "a", "b", "c", "d", "e", "f", "g", "h"
        [InlineData("zudfweormatjycujjirzjpyrmaxurectxrtqedmmgergwdvjmjtstdhcihacqnothgttgqfywcpgnuvwglvfiuxteopoyizgehkwuvvkqxbnufkcbodlhdmbqyghkojrgokpwdhtdrwmvdegwycecrgjvuexlguayzcammupgeskrvpthrmwqaqsdcgycdupykppiyhwzwcplivjnnvwhqkkxildtyjltklcokcrgqnnwzzeuqioyahqpuskkpbxhvzvqyhlegmoviogzwuiqahiouhnecjwysmtarjjdjqdrkljawzasriouuiqkcwwqsxifbndjmyprdozhwaoibpqrthpcjphgsfbeqrqqoqiqqdicvybzxhklehzzapbvcyleljawowluqgxxwlrymzojshlwkmzwpixgfjljkmwdtjeabgyrpbqyyykmoaqdambpkyyvukalbrzoyoufjqeftniddsfqnilxlplselqatdgjziphvrbokofvuerpsvqmzakbyzxtxvyanvjpfyvyiivqusfrsufjanmfibgrkwtiuoykiavpbqeyfsuteuxxjiyxvlvgmehycdvxdorpepmsinvmyzeqeiikajopqedyopirmhymozernxzaueljjrhcsofwyddkpnvcvzixdjknikyhzmstvbducjcoyoeoaqruuewclzqqqxzpgykrkygxnmlsrjudoaejxkipkgmcoqtxhelvsizgdwdyjwuumazxfstoaxeqqxoqezakdqjwpkrbldpcbbxexquqrznavcrprnydufsidakvrpuzgfisdxreldbqfizngtrilnbqboxwmwienlkmmiuifrvytukcqcpeqdwwucymgvyrektsnfijdcdoawbcwkkjkqwzffnuqituihjaklvthulmcjrhqcyzvekzqlxgddjoir", "gykrkyg")]
        public void TestLongestPalindromeBruteForce(string s, string expectedValue)
        {
            var problems = new DynamicProgrammingProblems();

            var actualValue = problems.LongestPalindromeBruteForce(s);
            
            Assert.True(expectedValue.Equals(actualValue));
        }
        
        [Theory]
        [InlineData("", "")] // ""
        [InlineData("bb", "bb")]  // "b", "bb"
        [InlineData("aaaa", "aaaa")] // "a", "aa", "aaa", "aaaa"
        [InlineData("aaaabaaa", "aaabaaa")]
        [InlineData("ab", "a")] // "a", "b"
        [InlineData("abab", "aba")] // "a", "b", "aba", "bab"
        [InlineData("abcdefgh", "a")] // "a", "b", "c", "d", "e", "f", "g", "h"
        [InlineData("zudfweormatjycujjirzjpyrmaxurectxrtqedmmgergwdvjmjtstdhcihacqnothgttgqfywcpgnuvwglvfiuxteopoyizgehkwuvvkqxbnufkcbodlhdmbqyghkojrgokpwdhtdrwmvdegwycecrgjvuexlguayzcammupgeskrvpthrmwqaqsdcgycdupykppiyhwzwcplivjnnvwhqkkxildtyjltklcokcrgqnnwzzeuqioyahqpuskkpbxhvzvqyhlegmoviogzwuiqahiouhnecjwysmtarjjdjqdrkljawzasriouuiqkcwwqsxifbndjmyprdozhwaoibpqrthpcjphgsfbeqrqqoqiqqdicvybzxhklehzzapbvcyleljawowluqgxxwlrymzojshlwkmzwpixgfjljkmwdtjeabgyrpbqyyykmoaqdambpkyyvukalbrzoyoufjqeftniddsfqnilxlplselqatdgjziphvrbokofvuerpsvqmzakbyzxtxvyanvjpfyvyiivqusfrsufjanmfibgrkwtiuoykiavpbqeyfsuteuxxjiyxvlvgmehycdvxdorpepmsinvmyzeqeiikajopqedyopirmhymozernxzaueljjrhcsofwyddkpnvcvzixdjknikyhzmstvbducjcoyoeoaqruuewclzqqqxzpgykrkygxnmlsrjudoaejxkipkgmcoqtxhelvsizgdwdyjwuumazxfstoaxeqqxoqezakdqjwpkrbldpcbbxexquqrznavcrprnydufsidakvrpuzgfisdxreldbqfizngtrilnbqboxwmwienlkmmiuifrvytukcqcpeqdwwucymgvyrektsnfijdcdoawbcwkkjkqwzffnuqituihjaklvthulmcjrhqcyzvekzqlxgddjoir", "gykrkyg")]
        public void TestLongestPalindrome(string s, string expectedValue)
        {
            var problems = new DynamicProgrammingProblems();

            var actualValue = problems.LongestPalindrome(s);
            
            Assert.True(expectedValue.Equals(actualValue));
        }
    }
}