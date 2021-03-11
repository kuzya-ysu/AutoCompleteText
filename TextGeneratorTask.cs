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
            if (nextWords.Count > 0)
            {
                var a = phraseBeginning.Split(' ');
                StringBuilder key = new StringBuilder();
                int num = 0;
                while (num < wordsCount)
                {
                    if (a.Length > 1 && nextWords.ContainsKey(key.ToString()))
                    {

                        key.Append(a[a.Length - 2] + " " + a[a.Length - 1]);
                        key.Append(" " + nextWords[key.ToString()]);
                    }
                    else
                    {
                        key = new StringBuilder();
                        key.Append(a[a.Length - 1]);
                        if (nextWords.ContainsKey(key.ToString()))
                        {
                            key.Append(" " + nextWords[key.ToString()]);
                        }
                    }
                }
            }
            return phraseBeginning;
        }
    }
}