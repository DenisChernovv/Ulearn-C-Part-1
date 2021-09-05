using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var charList = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            string[] linesMass = text.Split(charList, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < linesMass.Length; i++)
            {
                var words = DewideLinesIntoWords(linesMass[i]);
                if (words.Count != 0)
                    sentencesList.Add(words);
            }

            return sentencesList;
        }

        public static List<string> DewideLinesIntoWords(string lines)
        {
            List<string> listWords = new List<string>();

            var word = new StringBuilder();

            foreach (var e in lines)
            {
                if (char.IsLetter(e) || e == '\'')
                    word.Append(e);
                else if (word.Length != 0)
                {
                    listWords.Add(word.ToString().ToLower());
                    word.Clear();
                }
            }
            if (word.Length != 0)
                listWords.Add(word.ToString().ToLower());

            return listWords;
        }
    }
}