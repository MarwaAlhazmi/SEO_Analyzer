using SEOAnalyzer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEOAnalysisWeb
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static JSONResult Analyze(bool meta, bool link, string url, string text)
        //{
           
        //}

        protected void btnAnalyze_ServerClick(object sender, System.EventArgs e)
        {
            SEOAnalyzerCriteria criteria = new SEOAnalyzerCriteria();
            SEOAnalyzer.SEOAnalyzer analyzer;
            criteria.ExternalLinks = Convert.ToBoolean(hflink.Value);
            criteria.MetaData = Convert.ToBoolean(hfmeta.Value);
            if (!String.IsNullOrWhiteSpace(text.Value) || !String.IsNullOrWhiteSpace(url.Value))
            {
                if (!String.IsNullOrWhiteSpace(text.Value))
                    analyzer = new SEOAnalyzer.TextSEOAnalyzer(text.Value, criteria);
                else
                    analyzer = new SEOAnalyzer.WebSEOAnalyzer(url.Value, criteria);
                var result = analyzer.Process();
                CreateLinksTable(result);
                CreateWordsTable(result);
                CreateMetaTable(result);
            }
        }

        protected void CreateLinksTable(SEOAnalyzerResult result)
        {
            string tableTag = "";
            tableTag += "<table id=\"links\" class=\"table\"><thead><tr><th>Links</th></tr></thead><tbody>";
            foreach (var u in result.ExternalLinks)
            {
                tableTag += "<tr><td>" + u + "</tr></td>";

            }
            tableTag += "</tbody> </table>";

            divLinks.InnerHtml = tableTag;
            LinksDiv.Visible = true;
        }

        protected void CreateWordsTable(SEOAnalyzerResult result)
        {
            string tableTag = "";
            tableTag += "<table id=\"words\" class=\"table\"><thead><tr><th>Word</th><th>Frequency</th></tr></thead><tbody>";
            foreach (DictionaryEntry u in result.WordFrequency)
            {
                tableTag += "<tr><td>" + u.Key + "</td><td>"+u.Value+"</td></tr>";

            }
            tableTag += "</tbody> </table>";

            DivWords.InnerHtml = tableTag;
            WordsDiv.Visible = true;
        }

        protected void CreateMetaTable(SEOAnalyzerResult result)
        {
            string tableTag = "";
            tableTag += "<table id=\"meta\" class=\"table\"><thead><tr><th>Meta Keywords</th><th>Frequency</th></tr></thead><tbody>";
            foreach (DictionaryEntry u in result.MetaTagsFrequency)
            {
                tableTag += "<tr><td>" + u.Key + "</td><td>" + u.Value + "</td></tr>";

            }
            tableTag += "</tbody> </table>";

            DivMeta.InnerHtml = tableTag;
            MetaDiv.Visible = true;
        }
    }
}