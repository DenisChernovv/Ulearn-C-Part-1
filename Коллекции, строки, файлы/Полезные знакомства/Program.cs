using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
		private static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
		{
			var dictionary = new Dictionary<string, List<string>>();
			foreach(var nameEmail in contacts)
			{
				if (String.IsNullOrWhiteSpace(nameEmail) || nameEmail.Length < 2) continue;
				string[] name = nameEmail.Split(':');
				string firstTwoOrOneChar;
				if (name[0].Length >= 2)
				{
					firstTwoOrOneChar = name[0].Substring(0, 2);
				}
				else firstTwoOrOneChar = name[0];
				if (!dictionary.ContainsKey(firstTwoOrOneChar))
				{
					dictionary[firstTwoOrOneChar] = new List<string> { nameEmail };
				}
				else dictionary[firstTwoOrOneChar].Add(nameEmail);
			}
			return dictionary;
		}
		public static void Main()
		{
			var sasha = new List<string>();
			sasha.Add("Ваня:v@mail.ru");
			sasha.Add("Вася:vasiliy@gmail.com");
			sasha.Add("Ваня:ivan@grozniy.ru");
			sasha.Add("Саша:sasha1995@sasha.ru");
			sasha.Add("Саша:alex@nd.ru");
			sasha.Add("Паша:pavel.egorov@urfu.ru");
			sasha.Add("Юрий:dolg@rukiy.ru");
			sasha.Add("Гена:genadiy.the.best@inbox.ru");
			var dictionary = new Dictionary<string, List<string>>();
			dictionary = OptimizeContacts(sasha);
			foreach (var e in dictionary)
			{
				Console.WriteLine(e.Key);
				foreach(var i in e.Value)
                {
					Console.WriteLine("\t" + i);
                }
			}
			Console.ReadKey();
		}
	}
}
