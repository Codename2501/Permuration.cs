using System;
using System.Numerics;
using System.Collections;
namespace Permutation
{
    public class Permutation
    {
        int n;
        BigInteger rank;
        public Permutation(int n, BigInteger rank)
        {
            this.n = n;
            this.rank = rank;
        }
        public int[] GetPermutation()
        {
            //Console.WriteLine("p" + rank + " " + n);
            int[] digits = new int[n];
            for (int digit = 2; digit <= n; digit++)
            {
                BigInteger divisor = new BigInteger(digit);
                digits[n - digit] = (int)(rank % divisor);
                if (digit < n)
                {
                    rank = rank / divisor;
                }
            }
            BitArray usedDigits = new BitArray(n);
            int[] permutation = new int[n];
            int v = 0;

            for (int i = 0; i < n; i++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (usedDigits.Get(x) == false)
                    {
                        v = x;
                        break;
                    }
                }
                for (int j = 0; j < digits[i]; j++)
                {
                    for (int x = v + 1; ; x++)
                    {
                        if (usedDigits.Get(x) == false)
                        {
                            v = x;
                            break;
                        }
                    }
                }
                permutation[i] = v;
                usedDigits.Set(v, true);
            }
            return permutation;
        }
    }
}
