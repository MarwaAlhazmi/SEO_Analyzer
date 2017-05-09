using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace SEOAnalyzer.Models
{
    public class SEOAnalyzerResult
    {
        public HybridDictionary WordFrequency { get; set; }

        public HybridDictionary MetaTagsFrequency { get; set; }

        public List<string> ExternalLinks { get; set; }

    }
}
