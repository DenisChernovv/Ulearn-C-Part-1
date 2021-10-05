using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            if (text.Count == 0) return result;

            var bigrams = GetBigrams(text);
            var threegrams = GetThreeGrams(text);

            foreach (var bi in bigrams)
            {
                result.Add(bi.Key, bi.Value);
            }

            if (threegrams != null)
            {
                foreach (var three in threegrams)
                {
                    result.Add(three.Key, three.Value);
                }
            }
            
            return result;
        }

        static public Dictionary<string, string> GetBigrams(List<List<string>> text)
        {
            var bigramDic = new Dictionary<string, Dictionary<string, int>>();

            foreach (var subList in text)
            {
                for (int i = 0; i < subList.Count - 1; i++)
                {
                    if (!bigramDic.ContainsKey(subList[i]))
                    {
                        bigramDic[subList[i]] = new Dictionary<string, int>();
                    }

                    if (!bigramDic[subList[i]].ContainsKey(subList[i + 1]))
                        bigramDic[subList[i]][subList[i + 1]] = 0;
                    bigramDic[subList[i]][subList[i + 1]]++;
                }
            }

            var sortBigramDic = SortDic(bigramDic);
            return sortBigramDic;
        }

        static public Dictionary<string, string> GetThreeGrams(List<List<string>> text)
        {
            var threegramDic = new Dictionary<string, Dictionary<string, int>>();

            foreach (var subList in text)
            {
                for (int i = 0; i < subList.Count - 2; i++)
                {
                    if (!threegramDic.ContainsKey(subList[i] + " " + subList[i + 1]))
                        threegramDic[subList[i] + " " + subList[i + 1]] = new Dictionary<string, int>();
                    if (!threegramDic[subList[i] + " " + subList[i + 1]].ContainsKey(subList[i + 2]))
                        threegramDic[subList[i] + " " + subList[i + 1]][subList[i + 2]] = 0;
                    threegramDic[subList[i] + " " + subList[i + 1]][subList[i + 2]]++;
                }
            }

            var sortThreegramDic = SortDic(threegramDic);
            return sortThreegramDic;
        }

        static public Dictionary<string, string> SortDic(Dictionary<string, Dictionary<string, int>> dic)
        {
            var sortDic = new Dictionary<string, string>();
            foreach (var di in dic)
            {
                var key = "";
                var max = 0;

                foreach (var d in di.Value)
                {
                    if (d.Value >= max)
                    {
                        if (d.Value > max)
                        {
                            max = d.Value;
                            key = d.Key;
                        }
                        else if (string.CompareOrdinal(key, d.Key) > 0)
                        {
                            key = d.Key;
                        }
                    }
                }

                sortDic.Add(di.Key, key);
            }

            return sortDic;
        }
    }
}
