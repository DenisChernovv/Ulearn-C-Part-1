using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public static void Main(string[] args)
        {
            string text = @"push Привет! Это снова я! Пока!
pop 5
push Как твои успехи? Плохо?
push qwertyuiop
push 1234567890
pop 26";
            string[] commands = text.Split('\n');
            Console.WriteLine(ApplyCommands(commands));
            Console.ReadKey();
        }

        private static string ApplyCommands(string[] commands)
        {
            StringBuilder message = new StringBuilder();
            foreach (string e in commands)
            {
                if (e.StartsWith("push"))
                {
                    message.Append(e);
                    message.Remove(0, 5);
                }
                else {
                    string number = e.Substring(4);
                    int num = int.Parse(number);
                    message.Remove(message.Length - num - 1, num);
                }
            }
            return message.ToString();
        }



    }
}
