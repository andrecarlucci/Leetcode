/*
Given an integer x, return true if x is palindrome integer.
An integer is a palindrome when it reads the same backward as forward. For example, 121 is palindrome while 123 is not.
*/

using Xunit;

namespace Leetcode.Tests
{
    public class PalindromeNumber
    {

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            var w = x.ToString();
            var reverse = new char[w.Length];
            for (int i = 0; i < w.Length; i++)
            {
                reverse[i] = w[w.Length - 1 - i];
            }
            return w == new string(reverse);
        }

        [Theory]
        [InlineData(121,true)]
        [InlineData(-121,false)]
        [InlineData(10,false)]
        [InlineData(int.MaxValue,false)]
        [InlineData(0,true)]
        [InlineData(434343434,true)]
        public void Test(int x, bool result)
        {
            Assert.Equal(result, IsPalindrome(x));
        }
    }
}
