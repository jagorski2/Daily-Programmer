using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _226_Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UInt64> num = new List<UInt64>();
            List<UInt64> den = new List<UInt64>();
            UInt64[] ret = new UInt64[1];

            int num_inputs = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < num_inputs; i++)
            {
                string s = Console.ReadLine();
                num.Add(Convert.ToUInt64(s.Split('/')[0]));
                den.Add(Convert.ToUInt64(s.Split('/')[1]));
            }
            
            for (int i = 0; i < num.Count() - 1; i++)
            {
                if (i == 0)
                {
                    ret = addfrac(num.ElementAt(0), den.ElementAt(0), num.ElementAt(1), den.ElementAt(1));
                }
                else
                {
                    ret = addfrac(ret.ElementAt(0), ret.ElementAt(1), num.ElementAt(i + 1), den.ElementAt(i + 1));
                }
            }
            Console.WriteLine(ret[0]+"/"+ret[1]);
            Console.ReadLine();
        }
        static UInt64[] addfrac(UInt64 num1, UInt64 den1, UInt64 num2, UInt64 den2)
        {
            UInt64 num = 0;
            UInt64 den = 0;
            UInt64 g = 0;
            num = (num1 * den2) + (num2 * den1);
            den = den1 * den2;
            g = gcd(num,den);
            return new UInt64[] {num/g, den/g };
        }
        static ulong gcd(ulong a, ulong b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return gcd(b, a % b);
            }
        }
    }
}