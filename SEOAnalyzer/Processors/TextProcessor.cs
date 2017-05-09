using SEOAnalyzer.Data;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace SEOAnalyzer.Processors
{
    public class TextProcessor
    {
        private HybridDictionary WordFrequency;
        private char[] seperators = new char[] { ',', '.', ':', ';', '&', '\t', '?', '!', '"', '-', '\n', '\r' };
        private string validWordPattern = @"(^[a-z]{3,}$)";

        public HybridDictionary ProcessText(string source)
        {
            WordFrequency = new HybridDictionary();
            var stopwords = Stopwords.GetStopwords();
            source = CleanText(source);
            foreach(var word in source.Split(' '))
            {
                if (!stopwords.Contains(word) && Regex.IsMatch(word.ToLower(), validWordPattern))
                {
                    if (WordFrequency.Contains(word))
                    {
                        WordFrequency[word] = (int)WordFrequency[word] + 1;
                    }
                    else
                    {
                        WordFrequency.Add(word, 1);
                    }
                }
            }
            return WordFrequency;
        }

        private string CleanText(string source)
        {
            source = source.ToLower();
            foreach(var sep in seperators)
            {
                source = source.Replace(sep.ToString(), string.Empty);
            }
            return source;
        }
    }
}
