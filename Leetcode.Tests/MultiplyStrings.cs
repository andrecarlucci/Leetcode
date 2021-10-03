/*
Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.
Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.

Example 1:

Input: num1 = "2", num2 = "3"
Output: "6"
Example 2:

Input: num1 = "123", num2 = "456"
Output: "56088"
 
Constraints:

1 <= num1.length, num2.length <= 200
num1 and num2 consist of digits only.
Both num1 and num2 do not contain any leading zero, except the number 0 itself.

*/

using Xunit;

namespace Leetcode
{
    public class MultiplyStrings
    {
        public string Multiply(string num1, string num2)
        {
            var products = new int[num1.Length + num2.Length];
            int product, index1, index2;
            for (var i = num1.Length - 1; i >= 0; i--)
            {
                for (var j = num2.Length - 1; j >= 0; j--)
                {
                    index1 = i + j;
                    index2 = index1 + 1;
                    product = (num1[i] - 48) * (num2[j] - 48) + products[index2];
                    
                    products[index1]+= product / 10;
                    products[index2] = product % 10;
                }
            }

            var k = 0;
            while (products[k] == 0) { 
                k++; 
                if(k == products.Length)
                {
                    return "0";
                }
            }
            var number = new char[products.Length - k];
            for (int j = 0; j < number.Length; j++)
            {
                number[j] = (char) (products[j + k] + 48);
            }
            return new string(number);
        }

        [Theory]
        [InlineData("0", "0", "0")]
        [InlineData("2", "3", "6")]
        [InlineData("99", "99", "9801")]
        [InlineData("123", "456", "56088")]
        [InlineData("498828660196", "840477629533", "419254329864656431168468")]
        public void Test(string num1, string num2, string result)
        {
            Assert.Equal(result, Multiply(num1, num2));
        }
    }
}
