using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            PrintInfo<sbyte>();
            PrintInfo<byte>();
            PrintInfo<short>();
            PrintInfo<ushort>();
            PrintInfo<int>();
            PrintInfo<uint>();
            PrintInfo<long>();
            PrintInfo<ulong>();
            PrintInfo<float>();
            PrintInfo<double>();
            PrintInfo<decimal>();

        }

        static void PrintInfo<T>()where T : struct
        {
            Type type = typeof(T);
            object min = type.GetField("MinValue").GetValue(null);
            object max = type.GetField("MaxValue").GetValue(null);
            int size = Marshal.SizeOf(type);

            Console.WriteLine($"{type.Name}: Min = {min}, Max = {max}, Size = {size} bytes");
        }


    }
}
