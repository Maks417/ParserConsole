using System;
using System.Net;
using System.Collections.Generic;

using HtmlAgilityPack;

namespace ParserConsoleApplication
{
    /// <summary>
    /// Parser of Yandex Direct Search page
    /// </summary>
    public class Parser
    {
        private byte[] Page { get; set; }
        private readonly string yandexDirectLink = "https://direct.yandex.ru/search?text=";
        private readonly string selector = "//div[@class='path organic__path']//a[1]";

        /// <summary>
        /// Parser constructor
        /// </summary>
        /// <param name="path">Name of domain (e.g. https:/yandex.ru/)</param>
        public Parser(string path)
        {
            Page = DownloadPage(path);
        }

        /// <summary>
        /// Extraction of domains related with Direct Ad
        /// </summary>
        /// <returns>Collection of domains</returns>
        public IEnumerable<string> GetAds()
        {
            if (Page == null) throw new ArgumentNullException();

            var ads = new List<string>();
            var result = System.Text.Encoding.UTF8.GetString(Page);

            var html = new HtmlDocument();
            html.LoadHtml(result);
            var nodes = html.DocumentNode.SelectNodes(selector);
            if (nodes != null)
            {
                foreach (var node in nodes) ads.Add(node.InnerText);
            }
            
            return ads;            
        }

        private byte[] DownloadPage(string path)
        {
            using (var client = new WebClient())
            {
                var uri = new Uri(yandexDirectLink + path);
                var pageData = client.DownloadData(uri);
                return pageData;
            }
        }
    }
}
