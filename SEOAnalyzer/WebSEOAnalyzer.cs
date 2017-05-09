using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using SEOAnalyzer.Models;
using SEOAnalyzer.Processors;

namespace SEOAnalyzer
{
    public class WebSEOAnalyzer : SEOAnalyzer
    {
        private MetatagProcessor MetaTagsProcessor;
        private ExternalLinksProcessor ExternalLinkProcessor;

        public WebSEOAnalyzer(string text, SEOAnalyzerCriteria criteria) : base(text, criteria)
        {
            PlainTextProcessor = new TextProcessor();
            MetaTagsProcessor = new MetatagProcessor();
            ExternalLinkProcessor = new ExternalLinksProcessor();
        }

        public override bool IsValid()
        {
            return Uri.IsWellFormedUriString(Text, UriKind.Absolute);
        }

        public override SEOAnalyzerResult Process()
        {
            AnalyzerResult = new SEOAnalyzerResult();
            if (IsValid())
            {
                // get the webpage content;
                ResultMessage Result = new ResultMessage();
                var Document = GetWebPageContent(ref Result);
                var WebText = GetWebPageText(Document);

                AnalyzerResult.WordFrequency = PlainTextProcessor.ProcessText(WebText);
                AnalyzerResult.MetaTagsFrequency = MetaTagsProcessor.ProcessMetaKeywordsFrequency(Document, AnalyzerResult.WordFrequency);
                AnalyzerResult.ExternalLinks = ExternalLinkProcessor.ProcessExternalLinks(Text, Document);
            }
            return AnalyzerResult;
        }

        private HtmlDocument GetWebPageContent(ref ResultMessage result)
        {
            string urlAddress = Text;
            var document = new HtmlDocument();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();

                    document.LoadHtml(data);
                }
                catch (Exception ex)
                {
                    result.Status = StatusType.Error;
                    result.Message = ex.Message;
                }
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                result.Status = StatusType.Error;
                result.Message = "Webpage not found";
            }

            return document;
        }

        private string GetWebPageText(HtmlDocument document)
        {
            var body = document.DocumentNode.SelectSingleNode("//body");
            var text = body.InnerText;
            return text;
        }
    }
}
