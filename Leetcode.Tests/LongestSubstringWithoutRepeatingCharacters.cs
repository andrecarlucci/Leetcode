using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Leetcode.Tests
{
    public class LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
            {
                return 0;
            }
            var map = new Dictionary<char, int>();
            int max = 0;
            var j = 0;
            for (var i = 0; i < s.Length; ++i)
            {
                if (map.ContainsKey(s[i]))
                {
                    j = Math.Max(j, map[s[i]] + 1);
                }
                map[s[i]] = i;
                max = Math.Max(max, i - j + 1);
            }
            return max;
        }

        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb",1)]
        [InlineData("pwwkew", 3)]
        [InlineData("", 0)]
        [InlineData(" ", 1)]
        [InlineData("au", 2)]
        [InlineData("dvdf", 3)]
        [InlineData("anviaj", 5)]
        [InlineData("asdfea", 5)]
        [InlineData("asdfasdf", 4)]
        public void LengthOfLongestSubstringTest(string w, int result)
        {
            Assert.Equal(result, LengthOfLongestSubstring(w));
        }
    }
}
