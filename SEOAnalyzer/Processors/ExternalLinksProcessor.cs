using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEOAnalyzer.Processors
{
    public class ExternalLinksProcessor
    {
        private IEnumerable<char> invalidChars = new List<char> { '@', '(', ')' };

        public List<string> ProcessExternalLinks(string url, HtmlDocument document)
        {
            var externalLinks = new List<string>();
            var uri = new Uri(url);
            var domain = uri.Host;
            var body = document.DocumentNode.SelectSingleNode("//body");
            var links = body.SelectNodes("//a").Select(h => h.GetAttributeValue("href", "#"));
            foreach (var anchor in links)
            {
                if (!anchor.Contains(domain) && !invalidChars.Any(anchor.Contains) && anchor.IndexOf('/') != 0 && anchor.IndexOf('#') != 0)
                {
                    externalLinks.Add(anchor);
                }
            }

            return externalLinks;
        }
    }
}
