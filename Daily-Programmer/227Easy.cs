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
            int size = Convert.ToInt32(Console.ReadLine());
            /* When coord is true its case 1 and we return the coordinant of of the given number,
             * else it is case 2 and return the number of the given coord. */
            bool coord = false;
            int x, y, retx, rety;
            int counter = 1;
            int direction = 1;
            /* 
               1 = right
               2 = up
               3 = left
               4 = down 
             */
            while (size % 2 != 1)
            {
                Console.WriteLine("Size of square must be odd, try again.");
                size = Convert.ToInt32(Console.ReadLine());
            }
            string command = Console.ReadLine();
            if (command.Contains(' '))
            {
                coord = true;
                rety = Convert.ToInt32(command.Split(' ')[0]) -1;
                retx = Convert.ToInt32(command.Split(' ')[1]) -1;
            }
            else
            {
                retx = rety = 0;
            }

            int center = (int)Math.Floor((double)size/2);
            x = y = center;
            int[,] grid = new int[size,size];
            grid[x, y] = counter++;
            while (counter <= size * size)
            {
                switch (direction)
                {                  
                    case 1:
                        y++;
                        grid[x, y] = counter;
                        if (grid[x-1,y] == 0)
                        {
                            direction = 2;
                        }
                        
                        break;
                    case 2:
                        x--;
                        grid[x, y] = counter;
                        if (grid[x, y-1] == 0)
                        {
                            direction = 3;
                        }
                        break;
                    case 3:
                        y--;
                        grid[x, y] = counter;
                        
                        if (grid[x + 1, y] == 0)
                        {
                            direction = 4;
                        }
                        break;
                    case 4:
                        x++;
                        grid[x, y] = counter;
                        if (grid[x, y + 1] == 0)
                        {
                            direction = 1;
                        }
                        
                        break;
                    default:
                        break;
                }
                counter++;
            }
            if (coord)
            {
               Console.WriteLine(grid[retx, rety]); 
            }
            else
            {
                Print2DArray(grid, Convert.ToInt32(command));
            }
            Console.ReadLine();
        }
        public static void Print2DArray<T>(T[,] matrix, int num)
        {
            // This Method created with the help of Stack Overflow question
            // http://stackoverflow.com/questions/24094093/how-to-print-2d-array-to-console-in-c-sharp
            // Question by Big Shooter:
            // http://stackoverflow.com/users/3422169/big-shooter
            // Answer by Rezo Megrelidze:
            // http://stackoverflow.com/users/2204040/rezo-megrelidze

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (Convert.ToInt32(matrix[i, j]) == num)
                    {
                        Console.WriteLine("("+(j+1)+","+(i+1)+")");
                    }
                }
            }
        }
    }
}
