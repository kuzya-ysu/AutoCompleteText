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
            StringBuilder phraseContinuation = new StringBuilder();
            if (nextWords.Count > 0)
            {
                int num = 0;
                while (num < wordsCount)
                {
                    List<string> words = new List<string>(phraseBeginning.Split(' '));
                    if (words.Count > 1)
                    {
                        StringBuilder key = new StringBuilder();
                        key.Append(words[words.Count - 2] + " " + words[words.Count - 1]);
                        if (nextWords.ContainsKey(key.ToString()))
                        {
                            words.Add(nextWords[key.ToString()]);
                        }
                        else
                        {
                            key = new StringBuilder();
                            key.Append(words[words.Count - 1]);
                            if (nextWords.ContainsKey(key.ToString()))
                                words.Add(nextWords[key.ToString()]);
                            else
                                foreach (var word in words)
                                    phraseContinuation.Append(word + " ");
                        }

                    }
                    else
                    {
                        StringBuilder key = new StringBuilder();
                        key.Append(words[words.Count - 1]);
                        if (nextWords.ContainsKey(key.ToString()))
                            words.Add(nextWords[key.ToString()]);
                        else
                            foreach (var word in words)
                                phraseContinuation.Append(word + " ");
                    }
                    num++;
                }
            }
            return phraseContinuation.ToString();
        }
    }
}