using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Coding：
1.How can we find the minimum and maximum values, as well as the number of bytes, for the following data types: sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal?

*/
namespace HW1
{
    public class DataTypeInfo
    {
        public static void DataType()
        {
          
            Console.WriteLine("sbyte: " + sbyte.MinValue + " " + sbyte.MaxValue + " " + sizeof(sbyte));
            Console.WriteLine("byte: " + byte.MinValue + " " + byte.MaxValue + " " + sizeof(byte));
            Console.WriteLine("short: " + short.MinValue + " " + short.MaxValue + " " + sizeof(short));
            Console.WriteLine("ushort: " + ushort.MinValue + " " + ushort.MaxValue + " " + sizeof(ushort)); 
            Console.WriteLine("int: " + int.MinValue + " " + int.MaxValue + " " + sizeof(int)); 
            Console.WriteLine("uint: " + uint.MinValue + " " + uint.MaxValue + " " + sizeof(uint)); 
            Console.WriteLine("long: " + long.MinValue + " " + long.MaxValue + " " + sizeof(long)); 
            Console.WriteLine("ulong: " + ulong.MinValue + " " + ulong.MaxValue + " " + sizeof(ulong)); 
            Console.WriteLine("float: " + float.MinValue + " " + float.MaxValue + " " + sizeof(float));
            Console.WriteLine("double: " + double.MinValue + " " + double.MaxValue + " " + sizeof(double));
            Console.WriteLine("decimal: " + decimal.MinValue + " " + decimal.MaxValue + " " + sizeof(decimal));
         
        }
    }
}
