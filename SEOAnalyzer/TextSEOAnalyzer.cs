using SEOAnalyzer.Models;
using SEOAnalyzer.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEOAnalyzer
{
    public class TextSEOAnalyzer : SEOAnalyzer
    {
      
        public TextSEOAnalyzer(string text, SEOAnalyzerCriteria criteria) :base(text, criteria)
        {
            PlainTextProcessor = new TextProcessor();
        }

        public override bool IsValid()
        {
            return String.IsNullOrWhiteSpace(Text);
        }

        public override SEOAnalyzerResult Process()
        {
            AnalyzerResult = new SEOAnalyzerResult();
            if (PlainTextProcessor != null && IsValid())
            {
                AnalyzerResult.WordFrequency = PlainTextProcessor.ProcessText(Text);
            }

            return AnalyzerResult;
        }
    }
}
