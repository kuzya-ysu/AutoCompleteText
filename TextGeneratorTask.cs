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
            var a = phraseBeginning.Split(' ');
            StringBuilder key = new StringBuilder();
            key.Append(a[a.Length - 2] + " " + a[a.Length - 1]);
            int num = 0;
            while (num < wordsCount)
            {
                if (a.Length > 1 && nextWords.ContainsKey(key.ToString()))
                {
                    key.Append(" " + nextWords[key.ToString()]);
                }
                else
                {
                    key = null;
                    key.Append(a[a.Length - 1]);
                    if (nextWords.ContainsKey(key.ToString()))
                    {
                        key.Append(" " + nextWords[key.ToString()]);
                    }
                }
            }
            return phraseBeginning;
        }
    }
}