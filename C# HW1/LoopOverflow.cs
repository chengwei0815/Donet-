using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 3. What will happen if this code executes?
int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
}

 */
namespace HW1
{
    public class LoopOverflow
    {
        public static void Run()
        {
            int max = 500;
            for (byte i = 0; i < max; i++) // will overflow
            {
                Console.WriteLine(i);
            }
        }
    }
}

// The code will result in an infinite loop because the byte variable 'i' will overflow after reaching its maximum value of 255, wrapping around to 0 and continuing the loop indefinitely.
// To fix this, change the type of 'i' from byte to int:
// for (int i = 0; i < max; i++)