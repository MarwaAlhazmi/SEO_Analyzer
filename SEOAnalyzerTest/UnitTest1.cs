using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEOAnalyzer;
using SEOAnalyzer.Models;
using System.Collections;

namespace SEOAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SEOAnalyzerCriteria tt = new SEOAnalyzerCriteria();
            tt.ExternalLinks = true;
            tt.MetaData = true;
            ISEOAnalyzer t = new WebSEOAnalyzer("https://www.tensorflow.org/", tt);
            var y = t.Process();
            
        }
    }
}
