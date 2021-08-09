using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{

    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            string[] linesMass = text.Split('.', '!', '?', ';', ':', '(', ')');
            for(int i = 0; i < linesMass.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(linesMass[i])) continue;
                sentencesList.Add(dewideOnWords(linesMass[i]));
            }
            return sentencesList;
        }

        public static List<string> dewideOnWords (string lines)
        {
            List<string> listWords = new List<string>();

            var sb = new StringBuilder();
            foreach (char e in lines)
            {
                if (char.IsLetter(e) || e == '\'')
                    sb.Append(e);
                else
                {
                    if (sb.Length == 0) continue;
                    listWords.Add(sb.ToString().ToLower());
                    sb.Clear();
                }  
            }
            if(sb.Length != 0) listWords.Add(sb.ToString().ToLower());

            return listWords;
        }
    }
}