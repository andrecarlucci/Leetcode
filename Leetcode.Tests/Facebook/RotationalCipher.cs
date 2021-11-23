using System;
using System.Text;
using Xunit;

namespace Leetcode.Tests.Facebook
{
    /**
Rotational Cipher
One simple way to encrypt a string is to "rotate" every alphanumeric character by a certain amount. Rotating a character means replacing it with another character that is a certain number of steps away in normal alphabetic or numerical order.
For example, if the string "Zebra-493?" is rotated 3 places, the resulting string is "Cheud-726?". Every alphabetic character is replaced with the character 3 letters higher (wrapping around from Z to A), and every numeric character replaced with the character 3 digits higher (wrapping around from 9 to 0). Note that the non-alphanumeric characters remain unchanged.

Given a string and a rotation factor, return an encrypted string.

Signature
string rotationalCipher(string input, int rotationFactor)

Input
1 <= |input| <= 1,000,000
0 <= rotationFactor <= 1,000,000
Output
Return the result of rotating input a number of times equal to rotationFactor.

Example 1
input = Zebra-493?
rotationFactor = 3
output = Cheud-726?

Example 2
input = abcdefghijklmNOPQRSTUVWXYZ0123456789
rotationFactor = 39
output = nopqrstuvwxyzABCDEFGHIJKLM9012345678 

    */
    public class RotationalCipher
    {

        public string CipherIt(string input, int rotationFactor)
        {
            var sb = new StringBuilder(input.Length);

            for (var i = 0; i < input.Length; i++)
            {
                sb.Append(CipherIt(input[i], rotationFactor));
            }
            return sb.ToString();
        }

        private char CipherIt(int c, int factor)
        {
            int r = CipherIt('a', 'z', c, factor);
            r = CipherIt('A', 'Z', r, factor);
            r = CipherIt('0', '9', r, factor);
            return (char)r;
        }

        private int CipherIt(int lower, int upper, int c, int factor)
        {
            if (c >= lower && c <= upper)
            {
                c += factor;
                if (c > upper)
                {
                    c = (c - lower) % (upper - lower + 1);
                    c += lower;
                }
            }
            return c;
        }

        [Theory]
        [InlineData("abcd", 3, "defg")]
        [InlineData("N", 39, "A")]
        [InlineData("Zebra-493", 3, "Cheud-726")]
        [InlineData("abcdefghijklmNOPQRSTUVWXYZ0123456789", 39, "nopqrstuvwxyzABCDEFGHIJKLM9012345678")]
        [InlineData("abcdefghijklmNOPQRSTUVWXYZ0123456789", 1000000, "opqrstuvwxyzaBCDEFGHIJKLMN0123456789")]
        public void CipherTheText(string input, int factor, string result)
        {
            Assert.Equal(result, CipherIt(input, factor));
        }
    }
}
