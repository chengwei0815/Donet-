using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 2. Write a method in C# called FizzBuzz that takes an integer num and prints numbers from 1 up to num, but:
●	Print Fizz if the number is divisible by 3.

●	Print Buzz if the number is divisible by 5.

●	Print FizzBuzz if the number is divisible by both 3 and 5.

●	Otherwise, print the number itself.
*/

namespace HW1
{
    public class FizzBuzz
    {
        public static void Run(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
        }
    }
}
