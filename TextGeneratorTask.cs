using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    public class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            StringBuilder phraseContinuation = new StringBuilder(phraseBeginning);
            List<string> words = new List<string>(phraseBeginning.Split(' '));
            if (nextWords.Count > 0)
            {
                int num = 0;
                while (num < wordsCount)
                {
                    
                    if (words.Count > 1)
                    {
                        StringBuilder key = new StringBuilder();
                        key.Append(words[words.Count - 2] + " " + words[words.Count - 1]);
                        if (nextWords.ContainsKey(key.ToString()))
                        {
                            words.Add(nextWords[key.ToString()]);
                            phraseContinuation.Append(" " + words[words.Count - 1]);
                        }
                        else
                        {
                            key = new StringBuilder();
                            key.Append(words[words.Count - 1]);
                            if (nextWords.ContainsKey(key.ToString()))
                            {
                                words.Add(nextWords[key.ToString()]);
                                phraseContinuation.Append(" " + words[words.Count-1]);
                            }
                                
                           
                        }

                    }
                    else
                    {
                        StringBuilder key = new StringBuilder();
                        key.Append(words[words.Count - 1]);
                        if (nextWords.ContainsKey(key.ToString()))
                        {
                            words.Add(nextWords[key.ToString()]);
                            phraseContinuation.Append(" " + words[words.Count - 1] );
                        }
                    }
                    num++;
                }
            }
            return phraseContinuation.ToString();
        }
    }
}