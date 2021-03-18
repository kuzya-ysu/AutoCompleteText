using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace TextAnalysis
{
    public class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            List<string> sentences = text.ToLower().Split(new char[] { '.', '!', '?', '(', ')', '\\', ':', ';', '[', ']' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < sentences.Count; i++)
            {
                sentencesList.Add(sentences[i].Split(new char[] { ',', ':', ' ', ';', '<', '>', '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '/','^','#','$','+','=','-','\t', '\n', '\r',
                 '*',}, StringSplitOptions.RemoveEmptyEntries).ToList());
            }
            return sentencesList;
        }
    }
}