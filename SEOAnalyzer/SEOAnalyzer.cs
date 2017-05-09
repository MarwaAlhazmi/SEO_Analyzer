using SEOAnalyzer.Models;
using SEOAnalyzer.Processors;

namespace SEOAnalyzer
{
    public abstract class SEOAnalyzer : ISEOAnalyzer
    {
        protected string text;
        protected TextProcessor PlainTextProcessor;
        protected SEOAnalyzerResult AnalyzerResult;
        protected SEOAnalyzerCriteria AnalyzerCriteria;

        public string Text
        {
            set
            {
                text = value;
            }
            get
            {
                return text;
            }
        }

        public SEOAnalyzerCriteria AnalysisCriteria
        {
            get
            {
                return AnalyzerCriteria;
            }

            set
            {
                AnalyzerCriteria = value;
            }
        }

        public SEOAnalyzer(string text, SEOAnalyzerCriteria criteria)
        {
            Text = text;
            AnalysisCriteria = criteria;
        }

        public abstract bool IsValid();

        public abstract SEOAnalyzerResult Process();
    }
}
