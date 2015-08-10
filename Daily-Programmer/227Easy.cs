using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dailys
{
    class _227Easy
    {
        static void Main(string[] args)
        {
            UInt64 retx, rety;
            UInt64 size = Convert.ToUInt64(Console.ReadLine());
            while (size % 2 != 1)
            {
                Console.WriteLine("Size of square must be odd, try again.");
                size = Convert.ToUInt64(Console.ReadLine());
            }
            UInt64 center = (UInt64)Math.Floor((double)size / 2);
            string command = Console.ReadLine();
            if (command.Contains(' '))
            {
                rety = Convert.ToUInt64(command.Split(' ')[0]) - 1;
                retx = Convert.ToUInt64(command.Split(' ')[1]) - 1;
            }
            else
            {
                get_coord(Convert.ToUInt64(command), size, center);
            }
           
            Console.ReadLine();
        }

        private static void get_coord(UInt64 num, UInt64 size, UInt64 center)
        {
            bool rowFound = false;
            UInt64 highsquare = 0;
            UInt64 l = 1;
            UInt64 r = 3;
            UInt64 endcorner = 0;
            UInt64 pad = 0;
            while (!rowFound)
            {


                if ((l * l) < num && num < (r * r))
                {
                    for (UInt64 i = (l * l) + 1; i < (r * r) + 1; i++)
                    {
                        highsquare = r;
                        pad = (size - r)/2;
                        endcorner = r + pad;
                        rowFound = true;
                    }
                }
                l += 2;
                r += 2;
            }
            UInt64 rightx = endcorner;
            UInt64 leftx = endcorner - (endcorner - 1) + pad;
            UInt64 bottomy = endcorner;
            UInt64 topy = endcorner - (endcorner - 1) + pad;
            UInt64 brcorn = highsquare * highsquare;
            UInt64 blcorn = brcorn - (1 * (highsquare - 1));
            UInt64 tlcorn = brcorn - (2 * (highsquare - 1));
            UInt64 trcorn = brcorn - (3 * (highsquare - 1));
            if (num >= blcorn)
            {
                Console.WriteLine("({0}, {1})", rightx - (brcorn - num), bottomy);
            }
            else if (num >= tlcorn)
            {
                Console.WriteLine("({0}, {1})", leftx, bottomy - (blcorn - num));
            }
            else if (num >= trcorn)
            {
                Console.WriteLine("({0}, {1})", leftx + (tlcorn - num), topy);
            }
            else
            {
                UInt64 lowersqure = (highsquare - 2) * (highsquare - 2);
                if (num == lowersqure + 1)
                {
                    Console.WriteLine("({0}, {1})", rightx, bottomy -1);
                }
                else
                {
                    Console.WriteLine("({0}, {1})", rightx, bottomy - (trcorn - num));
                }
                
            }
        }
    }
}
