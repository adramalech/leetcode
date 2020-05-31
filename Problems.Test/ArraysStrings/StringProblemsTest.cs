using Xunit;
using Problems.ArraysStrings;

namespace Problems.Test.ArraysStrings
{
    public class StringProblemsTests
    {
        [Theory]
        [InlineData(" ", 1)]
        [InlineData("aa", 1)]
        [InlineData("aaaa", 1)]
        [InlineData("ab", 2)]
        [InlineData("ohvhjdml", 6)]
        public void TestLengthOfLongestSubstring(string s, int expectedLength) {
          var strProblems = new StringProblems();

          var actualLength = strProblems.LengthOfLongestSubstring(s);

          Assert.Equal<int>(expectedLength, actualLength);
        }

        [Theory]
        [InlineData("    2342   ", 2342)]
        [InlineData("-12345678900", int.MinValue)]
        [InlineData("2147483649", int.MaxValue)]
        [InlineData("0-1", 0)]
        public void TestAtoi(string s, int expectedValue)
        {
          var strProblems = new StringProblems();

          var actualLength = strProblems.Atoi(s);

          Assert.Equal<int>(expectedValue, actualLength);
        }

        [Theory]
        [InlineData("XIV", 14)]
        [InlineData("XCIX", 99)]
        [InlineData("DCXXI", 621)]
        [InlineData("DCCLVI", 756)]
        [InlineData("MMXX", 2020)]
        [InlineData("MMMCMXCIX", 3999)]
        public void TestRomanNumerial(string s, int expectedValue)
        {
          var strProblems = new StringProblems();

          var actualValue = strProblems.RomanNumerialToInt(s);

          Assert.Equal<int>(expectedValue, actualValue);
        }

        // error:  actual value is 109,586,953,112,635,269
        //       expected value is 121,932,631,112,635,269
        [Theory]
        [InlineData("0", "10", "0")]
        [InlineData("123423423234534", "0", "0")]
        [InlineData("1", "10", "10")]
        [InlineData("1324523457575434", "1", "1324523457575434")]
        [InlineData("4", "5", "20")]
        [InlineData("20", "6", "120")]
        [InlineData("10", "10", "100")]
        [InlineData("100", "200", "20000")]
        [InlineData("123", "456", "56088")]
        [InlineData("999", "999", "998001")]
        [InlineData("1234", "5678", "7006652")]
        [InlineData("12345", "6789", "83810205")]
        [InlineData("123456789", "987654321", "121932631112635269")]
        public void TestMultiply(string num1, string num2, string expectedValue)
        {
            var strProblems = new StringProblems();

            var actualValue = strProblems.Multiply(num1, num2);

            Assert.True(expectedValue.Equals(actualValue));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(10, 1)]
        [InlineData(89, 8)]
        [InlineData(75, 7)]
        [InlineData(55, 5)]
        [InlineData(19, 1)]
        public void TestCarry(int num, int expectedValue)
        {
            var strProblems = new StringProblems();

            var actualValue = strProblems.carry(num);

            Assert.Equal<int>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(11, 1)]
        [InlineData(25, 5)]
        [InlineData(33, 3)]
        [InlineData(48, 8)]
        [InlineData(87, 7)]
        [InlineData(6, 6)]
        public void TestDigit(int num, int expectedValue)
        {
            var strProblems = new StringProblems();

            var actualValue = strProblems.digit(num);

            Assert.Equal<int>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData('0', '9', 0)]
        [InlineData('9', '5', 45)]
        [InlineData('3', '3', 9)]
        [InlineData('5', '4', 20)]
        [InlineData('7', '3', 21)]
        [InlineData('5', '8', 40)]
        [InlineData('6', '3', 18)]
        [InlineData('8', '0', 0)]
        public void TestMulti(char digit1, char digit2, int expectedValue)
        {
            var strProblems = new StringProblems();

            var actualValue = strProblems.multi(digit1, digit2);

            Assert.Equal<int>(expectedValue, actualValue);
        }

        [Theory]
        [InlineData("", "", true)]
        [InlineData("a", "b", false)]
        [InlineData("aba", "baa", true)]
        [InlineData("abccgabce", "gaabbeccc", true)]
        [InlineData("abccgace", "gaabbecc", false)]
        public void TestIsStringPairAnagram(string s1, string s2, bool expectedResult)
        {
            var strProblems = new StringProblems();

            var actualResult = strProblems.isStringPairAnagram(s1, s2);

            Assert.Equal<bool>(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new string [] { "" }, 1)]
        [InlineData(new string [] { "", ""}, 1)]
        [InlineData(new string [] { "", "", ""}, 1)]
        [InlineData(new string [] { "", "", "", ""}, 1)]
        [InlineData(new string [] { "a", "b" }, 2)]
        [InlineData(new string [] { "ape", "and", "cat" }, 3)]
        [InlineData(new string [] { "aab", "aba", "baa" }, 1)]
        [InlineData(new string [] { "", "a", "bab", "abb", "aaa" }, 4)]
        [InlineData(new string [] { "", "a", "baba", "aabb", "abab", "abcd", "wxyz", "aaab" }, 6)]
        [InlineData(new string[] { "eat", "tea", "tan", "ate", "nat", "bat"}, 3)]
        [InlineData(new string [] { "a", "a", "b", "", "", "", "", "ab", "bc", "ba", "cb" }, 5)]
        public void TestIsStringGroupAnagram(string[] strs, int expectedCount)
        {
            var strProblems = new StringProblems();

            var actualResult = strProblems.GroupAnagrams(strs);

            Assert.NotNull(actualResult);
            Assert.NotEmpty(actualResult);
            Assert.Equal<int>(expectedCount, actualResult.Count);
        }

        [Theory]
        [InlineData(new string [] { "" }, 1)]
        [InlineData(new string [] { "", ""}, 1)]
        [InlineData(new string [] { "", "", ""}, 1)]
        [InlineData(new string [] { "", "", "", ""}, 1)]
        [InlineData(new string [] { "a", "b" }, 2)]
        [InlineData(new string [] { "ape", "and", "cat" }, 3)]
        [InlineData(new string [] { "aab", "aba", "baa" }, 1)]
        [InlineData(new string [] { "", "a", "bab", "abb", "aaa" }, 4)]
        [InlineData(new string [] { "", "a", "baba", "aabb", "abab", "abcd", "wxyz", "aaab" }, 6)]
        [InlineData(new string[] { "eat", "tea", "tan", "ate", "nat", "bat"}, 3)]
        [InlineData(new string [] { "a", "a", "b", "", "", "", "", "ab", "bc", "ba", "cb" }, 5)]
        public void TestIsStringGroupAnagram2(string[] strs, int expectedCount)
        {
            var strProblems = new StringProblems();

            var actualResult = strProblems.GroupAnagrams2(strs);

            Assert.NotNull(actualResult);
            Assert.NotEmpty(actualResult);
            Assert.Equal<int>(expectedCount, actualResult.Count);
        }

        [Theory]
        [InlineData("0", "0", "0")]
        [InlineData("1", "0", "1")]
        [InlineData("1", "1", "10")]
        [InlineData("11", "1", "100")]
        [InlineData("111", "1001", "10000")]
        [InlineData("101", "1001", "1110")]
        [InlineData("1111", "1111", "11110")]
        public void TestAddBinary(string a, string b, string expectedResult)
        {
            var strProblems = new StringProblems();

            var actualResult = strProblems.AddBinary(a, b);

            Assert.True(expectedResult.Equals(actualResult));
        }

        [Theory]
        [InlineData(0, "Zero")]
        [InlineData(19, "Nineteen")]
        [InlineData(59, "Fifty Nine")]
        [InlineData(123, "One Hundred Twenty Three")]
        [InlineData(12059, "Twelve Thousand Fifty Nine")]
        [InlineData(25359, "Twenty Five Thousand Three Hundred Fifty Nine")]
        [InlineData(500000, "Five Hundred Thousand")]
        [InlineData(505189, "Five Hundred Five Thousand One Hundred Eighty Nine")]
        [InlineData(1000000, "One Million")]
        [InlineData(12345678, "Twelve Million Three Hundred Forty Five Thousand Six Hundred Seventy Eight")]
        [InlineData(1000000000, "One Billion")]
        public void TestNumberToWords(int num, string expectedResult)
        {
            var strProblems = new StringProblems();

            var actualResult = strProblems.NumberToWords(num);

            Assert.True(expectedResult.Equals(actualResult));
        }

        [Theory]
        [InlineData("abcdefhi", "afi", "abcdefhi")]
        [InlineData("abcdefhi", "aef", "abcdef")]
        [InlineData("zwsxf", "abc", "")]
        [InlineData("zwsxf", "abcdefghij", "")]
        [InlineData("bba", "ab", "ba")]
        public void TestMinWindow(string s, string t, string expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.MinWindow(s, t);

            Assert.True(expectedResult.Equals(actualResult));
        }

        [Theory]
        [InlineData("", "", true)]
        [InlineData("#", "#", true)]
        [InlineData("##", "####", true)]
        [InlineData("#", "a#", true)]
        public void TestBackspaceCompare(string S, string T, bool expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.BackspaceCompare(S, T);

            Assert.Equal<bool>(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("", "", true)]
        [InlineData("#", "#", true)]
        [InlineData("##", "####", true)]
        [InlineData("#", "a#", true)]
        [InlineData("a#c", "b", false)]
        [InlineData("bxj##tw", "bxo#j##tw", true)]
        [InlineData("bxj##tw", "bxj###tw", false)]
        [InlineData("ab##", "c#d#", true)]
        public void TestBackspaceCompareConstantSpace(string S, string T, bool expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.BackspaceCompareConstantSpace(S, T);

            Assert.Equal<bool>(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("abab", true)]
        [InlineData("aabaaba", false)]
        public void TestRepeatedSubstringPattern(string s, bool expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.RepeatedSubstringPattern(s);

            Assert.Equal<bool>(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("}}]]))", false)]
        [InlineData("({{", false)]
        [InlineData("[]{}()", true)]
        [InlineData("(]", false)]
        [InlineData("([)]", false)]
        [InlineData("{[]}", true)]
        [InlineData("{{])", false)]
        [InlineData("([{}])", true)]
        [InlineData("({}[{)}]", false)]
        public void TestIsValid(string s, bool expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.IsValid(s);

            Assert.Equal<bool>(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("0", "0", "0")]
        [InlineData("9", "9", "18")]
        [InlineData("101", "10", "111")]
        [InlineData("1000", "123", "1123")]
        [InlineData("5000", "5000", "10000")]
        public void TestAddStrings(string num1, string num2, string expectedResult)
        {
            var stringProblems = new StringProblems();

            var actualResult = stringProblems.AddStrings(num1, num2);

            Assert.True(expectedResult.Equals(actualResult));
        }

        [Theory]
        [InlineData(new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }, 2)]
        public void TestNumUniqueEmails(string[] emails, int expectedCount)
        {
            var stringProblems = new StringProblems();

            var actualCount = stringProblems.NumUniqueEmails(emails);

            Assert.Equal<int>(expectedCount, actualCount);
        }

        [Theory]
        [InlineData("heeellooo", new string[] { "hello", "hi", "helo" }, 1)]
        [InlineData("dddiiiinnssssssoooo", new string[] { "dinnssoo", "ddinso", "ddiinnso", "ddiinnssoo", "ddiinso", "dinsoo", "ddiinsso", "dinssoo", "dinso" }, 3)]
        public void TestExpressiveWords(string S, string[] words, int expectedCount)
        {
            var stringProblems = new StringProblems();

            var actualCount = stringProblems.ExpressiveWords(S, words);

            Assert.Equal<int>(expectedCount, actualCount);
        }
    }
}