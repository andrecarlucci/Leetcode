using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Leetcode.Tests
{
    public class RomanToInteger
    {
        public int RomanToInt(string s)
        {
            var num = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == 'M')
                {
                    num += 1000;
                    continue;
                }
                else if (c == 'D')
                {
                    num += 500;
                }
                else if (c == 'C')
                {
                    if (i != s.Length - 1 && s[i + 1] == 'M')
                    {
                        num += 900;
                        i++;
                    }
                    else if (i != s.Length - 1 && s[i + 1] == 'D')
                    {
                        num += 400;
                        i++;
                    }
                    else
                    {
                        num += 100;
                    }
                }
                else if (c == 'L')
                {
                    num += 50;
                }
                else if (c == 'X')
                {
                    if (i != s.Length - 1 && s[i + 1] == 'L')
                    {
                        num += 40;
                        i++;
                    }
                    else if (i != s.Length - 1 && s[i + 1] == 'C')
                    {
                        num += 90;
                        i++;
                    }
                    else
                    {
                        num += 10;
                    }
                }
                else if (c == 'V')
                {
                    num += 5;
                }
                else if (c == 'I')
                {
                    if (i != s.Length - 1 && s[i + 1] == 'V')
                    {
                        num += 4;
                        i++;
                    }
                    else if (i != s.Length - 1 && s[i + 1] == 'X')
                    {
                        num += 9;
                        i++;
                    }
                    else
                    {
                        num += 1;
                    }
                }
            }
            return num;
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Test(string roman, int result)
        {
            Assert.Equal(result, RomanToInt(roman));
        }
    }
}
