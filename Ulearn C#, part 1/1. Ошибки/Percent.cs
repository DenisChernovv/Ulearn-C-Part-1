using System;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFromUser = Console.ReadLine();
            var sum = Calculate(inputFromUser);
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        public static double Calculate(string userInput)
        {
            var parts = userInput.Split(' ');
            var startMoney = double.Parse(parts[0]);
            var percent = double.Parse(parts[1]);
            var countMouth = double.Parse(parts[2]);

            var sum = startMoney * Math.Pow(1+ percent/(100 * 12), countMouth);
            return sum;
        }
    }
}
