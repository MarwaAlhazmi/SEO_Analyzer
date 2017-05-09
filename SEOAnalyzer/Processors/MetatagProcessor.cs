using HtmlAgilityPack;
using SEOAnalyzer.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace SEOAnalyzer.Processors
{
    public class MetatagProcessor
    {
        private char[] seperators = new char[] { ',', '.', ':', ';', '&', '\t', '?', '!', '"', '-' };

        public HybridDictionary ProcessMetaKeywordsFrequency(HtmlDocument document, HybridDictionary wordsFreq)
        {
            var MetaKeywordsFreq = new HybridDictionary();
            var stopwords = Stopwords.GetStopwords();
            var keywordsContent = string.Empty;
            var metaNodes = document.DocumentNode.SelectNodes("//meta");
            if (metaNodes.Count > 0)
            {
                foreach (var meta in metaNodes)
                {
                    keywordsContent = meta.GetAttributeValue("content", string.Empty);
                    if (!string.IsNullOrEmpty(keywordsContent) && wordsFreq != null)
                    {
                        var keywords = keywordsContent.Split(seperators);
                        if (keywords.Any())
                        {
                            foreach (var word in keywords)
                            {
                                if (!string.IsNullOrEmpty(word) && !stopwords.Contains(word)
                                    && wordsFreq.Contains(word)
                                    && !MetaKeywordsFreq.Contains(word))
                                {
                                    var frequency = (int)wordsFreq[word] + 1;
                                    MetaKeywordsFreq.Add(word, frequency);
                                }
                            }
                        }
                    }
                }
            }
            return MetaKeywordsFreq;
        }
    }
}
