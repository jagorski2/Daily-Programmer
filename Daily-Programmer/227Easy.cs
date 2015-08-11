using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


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
            UInt64 center = (UInt64)Math.Floor((double)size / 2) + 1;
            
            string command = Console.ReadLine();
            if (command.Contains(' '))
            {
                bool squareFound = false;
                UInt64 square = 0;
                retx = Convert.ToUInt64(command.Split(' ')[0]);
                rety = Convert.ToUInt64(command.Split(' ')[1]);
                double distx = Math.Abs((int)center - (int)retx);
                double disty = Math.Abs((int)center - (int)rety);
                if (distx == disty)
                {
                    square = (UInt64)distx;
                }
                else if (distx > disty)
                {
                    square = (UInt64)distx;
                }
                else
                {
                    square = (UInt64)disty;
                }

                square = (square * 2) + 1;
                if (square % 2 == 0)
                {
                    square--;
                }
                while (!squareFound)
                {
                    UInt64[] range = getCoordsfromSquare(size, (UInt64)square);

                    if (retx == range[0] || retx == range[1])
                    {
                        if (rety >= range[0] && rety <= range[1])
                        {
                            UInt64 bottomRightCoord = square * square;
                            UInt64 topRightCorner = bottomRightCoord - ((square - 1) * 3);
                            UInt64 topLeftCorner = bottomRightCoord - ((square - 1) * 2);
                            UInt64 botLeftCorner = bottomRightCoord - ((square - 1));
                            if (retx == range[0])
                            {

                                Console.WriteLine(botLeftCorner - (range[1] - rety));
                            }
                            else
                            {
                                Console.WriteLine(topRightCorner - (rety - range[0]));
                            }
                            squareFound = true;
                            break;
                        }

                    }
                    if (rety == range[0] || rety == range[1])
                    {
                        if (retx >= range[0] && retx <= range[1])
                        {
                            UInt64 bottomRightCoord = square * square;
                            UInt64 topRightCorner = bottomRightCoord - ((square - 1) * 3);
                            UInt64 topLeftCorner = bottomRightCoord - ((square - 1) * 2);
                            UInt64 botLeftCorner = bottomRightCoord - ((square - 1));
                            if (rety == range[0])
                            {
                                
                                Console.WriteLine(topLeftCorner - (retx - range[0]));
                            }
                            else
                            {
                                Console.WriteLine(bottomRightCoord - (range[1] - retx));
                            }
                            squareFound = true;
                            break;
                        }
                    }
                    square += 2;
                }
            }
            else
            {
                to_Point(Convert.ToUInt64(command), size, center);
            }

            Console.ReadLine();
        }



        private static void to_Point(UInt64 num, UInt64 size, UInt64 center)
        {
            bool rowFound = false;
            UInt64 highsquare = 0;
            UInt64 l = 1;
            UInt64 r = 3;
            UInt64 endcorner = 0;
            UInt64 pad = 0;
            l = (UInt64)Math.Sqrt((double)num) -1;
            r = (UInt64)Math.Sqrt((double)num) + 1;
            if (l % 2 == 0)
            {
                l--;
                r--;
            }
            while (!rowFound)
            {

                if ((l * l) < num && num < (r * r))
                {
                    break;
                }
                l += 2;
                r += 2;
            }
            highsquare = r;
            pad = (size - r) / 2;
            endcorner = r + pad;
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
                    Console.WriteLine("({0}, {1})", rightx, bottomy - 1);
                }
                else
                {
                    Console.WriteLine("({0}, {1})", rightx, bottomy - (trcorn - num));
                }

            }
        }
        private static UInt64[] getCoordsfromSquare(UInt64 size, UInt64 square)
        {
            UInt64 pad;
            UInt64 max = 0;
            UInt64 min = 0;
            pad = (size - square) / 2;
            max = square + pad;
            min = max - (square - 1);
            return new UInt64[] { min, max };
        }
    }
}
