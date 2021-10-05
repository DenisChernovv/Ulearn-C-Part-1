using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }

        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }

        public static Array Combine(params Array[] arrays)
        {
            if (arrays.Length == 0) return null;
            var elementType = arrays[0].GetType().GetElementType();
            var summaryLength = 0;
            foreach (var e in arrays)
            {
                summaryLength += e.Length;
                if (e.GetType().GetElementType() != elementType) return null;
            }

            var newArray = Array.CreateInstance(elementType, summaryLength);
            var index = 0;
            foreach (var e in arrays)
            {
                for (int i = 0; i < e.Length; i++)
                {
                    newArray.SetValue(e.GetValue(i), index);
                    index++;
                }
            }

            return newArray;
        }
    }
}
