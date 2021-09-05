using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var sb = new StringBuilder(phraseBeginning);

            for (var i = 0; i < wordsCount; i++)
            {
                var wordsPhase = sb.ToString().Split(' ');
                var lastWord = wordsPhase[wordsPhase.Length - 1];

                if (wordsPhase.Length >= 2
                    && nextWords.ContainsKey(wordsPhase[wordsPhase.Length - 2] + " " + lastWord))
                    sb.Append(" " + nextWords[wordsPhase[wordsPhase.Length - 2] + " " + lastWord]);
                else if (nextWords.ContainsKey(lastWord))
                    sb.Append(" " + nextWords[lastWord]);
                else continue;
            }

            var endPhrase = sb.ToString();
            return endPhrase;
        }
    }
}