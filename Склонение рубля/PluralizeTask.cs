﻿namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			// Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
			if (count % 10 == 0 || (count % 10 >= 5 && count % 10 <=9) || ((count % 100 >= 11) & (count % 100 <=19))) return "рублей";
			else if (count % 10 == 1) return "рубль";
			else return "рубля";
		}
	}
}