using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var tempResult = new Dictionary<string, SortedDictionary<string, int> > ();
            foreach(var sentence in text)
            {
                for(int i=0;i<sentence.Count-1;i++)
                {
                    if (!tempResult.ContainsKey(sentence[i]))
                    {
                        var wordDictionary = new SortedDictionary<string, int>();
                        wordDictionary.Add(sentence[i + 1], 1);
                        tempResult.Add(sentence[i],wordDictionary);
                    }
                    else
                    {
                        if (!tempResult[sentence[i]].ContainsKey(sentence[i + 1]))
                            tempResult[sentence[i]].Add(sentence[i + 1], 1);
                        else
                            tempResult[sentence[i]][sentence[i + 1]]++;
                    }
                }
            }
            foreach(var word in tempResult)
            {
                KeyValuePair<string,int> resultValue=new KeyValuePair<string, int>();
                foreach(var word2 in word.Value)
                {
                    if(resultValue.Key==null)
                        resultValue = word2;
                    if (word2.Value > resultValue.Value)
                        resultValue = word2;
                }
                result.Add(word.Key, resultValue.Key);
            }

            tempResult = new Dictionary<string, SortedDictionary<string, int>>();
            foreach (var sentence in text)
            {
                for (int i = 0; i < sentence.Count - 2; i++)
                {
                    if (!tempResult.ContainsKey(sentence[i]+" "+sentence[i+1]))
                    {
                        var wordDictionary = new SortedDictionary<string, int>();
                        wordDictionary.Add(sentence[i + 2], 1);
                        tempResult.Add(sentence[i] + " " + sentence[i + 1], wordDictionary);
                    }
                    else
                    {
                        if (!tempResult[sentence[i] + " " + sentence[i + 1]].ContainsKey(sentence[i + 2]))
                            tempResult[sentence[i] + " " + sentence[i + 1]].Add(sentence[i + 2], 1);
                        else
                            tempResult[sentence[i] + " " + sentence[i + 1]][sentence[i + 2]]++;
                    }
                }
            }
            foreach (var word in tempResult)
            {
                KeyValuePair<string, int> resultValue = new KeyValuePair<string, int>();
                foreach (var word2 in word.Value)
                {
                    if (resultValue.Key == null)
                        resultValue = word2;
                    if (word2.Value > resultValue.Value)
                        resultValue = word2;
                }
                result.Add(word.Key, resultValue.Key);
            }


            return result;
        }
   }
}