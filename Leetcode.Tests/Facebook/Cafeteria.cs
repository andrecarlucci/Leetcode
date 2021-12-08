using System;
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

            //1234567890 K=1
            //.x. .x.

            //123456789ABCDEF K=2
            //   ..x....x..x.

            //123456789ABCDEFGH K=2
            //   ..x....x..x..
            S = S.OrderBy(x => x).ToArray();

            long result = 0;
            long last = 0;
            long freeSpaces = 0;

            for (var i = 0; i < M; i++)
            {
                var ocuppied = S[i];
                var left = ocuppied - K;
                var right = ocuppied + K;

                freeSpaces = ocuppied - K - last -1;
                if (freeSpaces > 0)
                {
                    var seats = freeSpaces / (K + 1);
                    result += seats;
                    if (freeSpaces % (K + 1) > 0)
                    {
                        result++;
                    }
                }
                last = right;
            }

            freeSpaces = N - last;
            if (freeSpaces > 0)
            {
                var seats = freeSpaces / (K + 1);
                result += seats;
                if (freeSpaces % (K + 1) > 0)
                {
                    result++;
                }
            }
            return result;
        }

        [Theory]
        [InlineData(3, 10, 1, 2, new long[] {2,6})]
        [InlineData(1, 15, 2, 3, new long[] {11,6,14})]
        [InlineData(1, 16, 2, 3, new long[] {11,6,14})]
        [InlineData(2, 17, 2, 3, new long[] {11,6,14})]
        public void TestCafeteria(long expected, long n, long k, int m, long[] s)
        {
            Assert.Equal(expected, getMaxAdditionalDinersCount(n, k, m, s));
        }
    }
}
