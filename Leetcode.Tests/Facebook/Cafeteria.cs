using System.Linq;
using Xunit;

namespace Leetcode.Tests.Facebook
{
    public class Cafeteria
    {
        public long getMaxAdditionalDinersCount(long N, long K, int M, long[] S)
        {
            // Write your code here
            // N = Seats
            // K = distance
            // M = # of occupied
            // S = occupied places

            //1234567890
            //.x. .x.

            //123456789ABCDEF
            //   ..x...x..x..
            S = S.OrderBy(x => x).ToArray();

            long result = 0;
            long last = 0;

            for (var i = 0; i < M; i++)
            {
                var ocuppied = S[i]-1;
                var left = ocuppied - K;
                var right = ocuppied + K;

                for (var j = last; j < left; j++)
                {
                    if (j < left)
                    {
                        result++;
                        j += K;
                    }
                }
                last = right + 1;
            }

            for(var j=last; j<N; j++)
            {
                result++;
                j += K;
            }
            return result;
        }

        [Theory]
        [InlineData(3, 10, 1, 2, new long[] {2,6})]
        [InlineData(1, 15, 2, 3, new long[] {11,6,14})]
        public void TestCafeteria(long expected, long n, long k, int m, long[] s)
        {
            Assert.Equal(expected, getMaxAdditionalDinersCount(n, k, m, s));
        }
    }
}
