/*
 Contiguous Subarrays
You are given an array arr of N integers. For each index i, you are required to determine the number of contiguous subarrays that fulfill the following conditions:
The value at index i must be the maximum element in the contiguous subarrays, and
These contiguous subarrays must either start from or end on index i.
Signature
int[] countSubarrays(int[] arr)
Input
Array arr is a non-empty list of unique integers that range between 1 to 1,000,000,000
Size N is between 1 and 1,000,000
Output
An array where each index i contains an integer denoting the maximum number of contiguous subarrays of arr[i]
Example:
arr = [3, 4, 1, 6, 2]
output = [1, 3, 1, 5, 1]
Explanation:
For index 0 - [3] is the only contiguous subarray that starts (or ends) with 3, and the maximum value in this subarray is 3.
For index 1 - [4], [3, 4], [4, 1]
For index 2 - [1]
For index 3 - [6], [6, 2], [1, 6], [4, 1, 6], [3, 4, 1, 6]
For index 4 - [2]
So, the answer for the above input is [1, 3, 1, 5, 1]


*/
using Xunit;

namespace Leetcode.Tests.Facebook
{
    public class ContinuousSubArrays
    {
        private static int[] CountSubarrays(int[] arr)
        {
            var result = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++)
            {

                var value = arr[i];
                for (var left = 0; left < i; left++)
                {
                    if (arr[left] > value)
                    {
                        break;
                    }
                    result[i]++;
                }

                for (var right = i; right < arr.Length; right++)
                {
                    if (arr[right] > value)
                    {
                        break;
                    }
                    result[i]++;
                }
            }
            return result;
        }

        [Theory]
        [InlineData(new int[] { 3, 4, 1, 6, 2 }, new int[] { 1, 3, 1, 5, 1 })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { 3,3,3 }, new int[] { 3,3,3})]
        [InlineData(new int[] { 1000000000, 1, 1000000000 }, new int[] { 3,1,3})]
        public void CipherTheText(int[] input, int[] expected)
        {
            Assert.Equal(expected, CountSubarrays(input));
        }
    }
}
