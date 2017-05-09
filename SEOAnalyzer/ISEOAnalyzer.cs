using SEOAnalyzer.Models;

namespace SEOAnalyzer
{
    public interface ISEOAnalyzer
    {
        SEOAnalyzerResult Process();
        bool IsValid();
    }
}
