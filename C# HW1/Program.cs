/*

1.	What type would you choose for the following “numbers”?

○	A person’s telephone number => string or ulong

○	A person’s height => decimal

○	A person’s age => byte

○	A person’s gender (Male, Female, Prefer Not To Answer) => string

○	A person’s salary => decimal

○	A book’s ISBN => string

○	A book’s price => decimal

○	A book’s shipping weight => decimal

○	A country’s population => ulong

○	The number of stars in the universe => ulong

○	The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business) => ulong

 2.	What are the differences between value type and reference type variables?
 What is boxing and unboxing?
 => Value types store data directly, while reference types store a reference to the data's memory address. 
    example of value type: int, float, bool
    example of reference type: string, array, class 
 => Boxing is the process of converting a value type to a reference type, while unboxing is converting a reference type back to a value type.
    example of boxing: int i = 123; object o = i; // boxing
    example of unboxing: object o = 123; int i = (int)o; // unboxing

3.	What is meant by the terms managed resource and unmanaged resource in .NET?
=> Managed resources are those that are handled by the .NET runtime's garbage collector, such as objects created from .NET classes. 
=> Unmanaged resources are those that are not managed by the .NET runtime, such as file handles, database connections, or memory allocated through native code. Developers need to explicitly release unmanaged resources to avoid memory leaks.

4.	What is the purpose of the Garbage Collector in .NET?
=> The Garbage Collector (GC) in .NET is responsible for automatically managing memory allocation and deallocation for managed objects. 
    It helps to reclaim memory occupied by objects that are no longer in use, thus preventing memory leaks and optimizing application performance. 
    The GC periodically checks for objects that are no longer reachable from the application's root references and frees up their memory.

Controlling Flow and Converting Types – Questions
1.	What happens when you divide an int variable by 0? => It throws a DivideByZeroException at runtime.

2.	What happens when you divide a double variable by 0? => It results in positive or negative infinity (Infinity or -Infinity) or NaN (Not a Number) if the numerator is also zero.

3.	What happens when you overflow an int variable (assign a value beyond its range)? => It wraps around to the minimum value of the int type (e.g., int.MaxValue + 1 becomes int.MinValue) unless checked context is used, which throws an OverflowException.

4.	What is the difference between x = y++; and x = ++y;? => x = y++; assigns the current value of y to x and then increments y (post-increment). x=++y; increments y first and then assigns the new value of y to x (pre-increment).

5.	What is the difference between break, continue, and return when used inside a loop statement? => break exits the loop entirely, continue skips the current iteration and moves to the next iteration of the loop, and return exits the entire method, returning control to the calling method.

6.	What are the three parts of a for statement and which of them are required? => The three parts of a for statement are initialization, condition, and iteration. None of them are strictly required; you can omit any or all of them, but the semicolons must remain to separate the parts.

7.	What is the difference between the = and == operators? => = is the assignment operator used to assign a value to a variable, while == is the equality operator used to compare two values for equality.

8.	Does the following statement compile? for ( ; true; ) ; => Yes, it compiles. This is an infinite loop that will run indefinitely because the condition is always true.

9.	What interface must an object implement to be enumerated by the foreach statement? => The object must implement the IEnumerable interface to be enumerated by the foreach statement.


 * */


/* Coding：
1.How can we find the minimum and maximum values, as well as the number of bytes, for the following data types: sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal?

*/
using HW1;
using System;

//public class DataTypeInfo
//{
//    public static void DataType()
//    {

//        Console.WriteLine("sbyte: " + sbyte.MinValue + " " + sbyte.MaxValue + " " + sizeof(sbyte));
//        Console.WriteLine("byte: " + byte.MinValue + " " + byte.MaxValue + " " + sizeof(byte));
//        Console.WriteLine("short: " + short.MinValue + " " + short.MaxValue + " " + sizeof(short));
//        Console.WriteLine("ushort: " + ushort.MinValue + " " + ushort.MaxValue + " " + sizeof(ushort));
//        Console.WriteLine("int: " + int.MinValue + " " + int.MaxValue + " " + sizeof(int));
//        Console.WriteLine("uint: " + uint.MinValue + " " + uint.MaxValue + " " + sizeof(uint));
//        Console.WriteLine("long: " + long.MinValue + " " + long.MaxValue + " " + sizeof(long));
//        Console.WriteLine("ulong: " + ulong.MinValue + " " + ulong.MaxValue + " " + sizeof(ulong));
//        Console.WriteLine("float: " + float.MinValue + " " + float.MaxValue + " " + sizeof(float));
//        Console.WriteLine("double: " + double.MinValue + " " + double.MaxValue + " " + sizeof(double));
//        Console.WriteLine("decimal: " + decimal.MinValue + " " + decimal.MaxValue + " " + sizeof(decimal));

//    }
//}

/*
 * 2. Write a method in C# called FizzBuzz that takes an integer num and prints numbers from 1 up to num, but:
●	Print Fizz if the number is divisible by 3.

●	Print Buzz if the number is divisible by 5.

●	Print FizzBuzz if the number is divisible by both 3 and 5.

●	Otherwise, print the number itself.
*/

//class Program
//{
//    static void Main(string[] args)
//    {
//        FizzBuzz(100);
//    }
//    static void FizzBuzz(int num)
//    {
//        for (int i = 1; i <= num; i++)
//        {
//            if (i % 3 == 0 && i % 5 == 0)
//            {
//                Console.WriteLine("FizzBuzz");
//            }
//            else if (i % 3 == 0)
//            {
//                Console.WriteLine("Fizz");
//            }
//            else if (i % 5 == 0)
//            {
//                Console.WriteLine("Buzz");
//            }
//            else
//            {
//                Console.WriteLine(i);
//            }
//        }
//    }
//}

/*
 3. What will happen if this code executes?
int max = 500;
for (byte i = 0; i < max; i++)
{
    Console.WriteLine(i);
}

 */
//class Program
//    {
//    static void Main(string[] args)
//    {
//        int max = 500;
//        for (byte i = 0; i < max; i++)
//        {
//            Console.WriteLine(i);
//        }
//    }
//}
// The code will result in an infinite loop because the byte variable 'i' will overflow after reaching its maximum value of 500, wrapping around to 0 and continuing the loop indefinitely.

/*
 4. Two Sum
 Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

●	You may assume that each input would have exactly one solution.

●	You may not use the same element twice.

●	You can return the answer in any order.
*/

//class Program
//{
//    static void Main(string[] args)
//    {
//        int[] nums = { 2, 7, 11, 15 };
//        int target = 9;
//        int[] result = TwoSum(nums, target);
//        Console.WriteLine($"[{result[0]}, {result[1]}]");
//    }
//    static int[] TwoSum(int[] nums, int target)
//    {
//        for (int i = 0; i < nums.Length; i++)
//        {
//            for (int j = i + 1; j < nums.Length; j++)
//            {
//                if (nums[i] + nums[j] == target)
//                {
//                    return new int[] { i, j };
//                }
//            }
//        }
//        return new int[] { -1, -1 }; // Return -1, -1 if no solution is found
//    }
//}


class Program
{
    static void Main(string[] args)
    {
        DataTypeInfo.DataType();
        Console.WriteLine();
        FizzBuzz.Run(100);
        Console.WriteLine();
        //LoopOverflow.Run(); // Uncommenting this will cause an infinite loop
        Console.WriteLine();
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;
        int[] result = TwoSum.FindTwoSum(nums, target);
        Console.WriteLine($"[{result[0]}, {result[1]}]");
    }
}
