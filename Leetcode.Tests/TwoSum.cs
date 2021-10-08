using System;
using Xunit;

namespace Leetcode.Tests
{
    public class TwoSum
    {
        public int[] FindIndex(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new Exception();
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] {0,1})]
        public void Test(int[] nums, int target, int[] result)
        {
            Assert.Equal(result, FindIndex(nums, target));
        }

    }
}
