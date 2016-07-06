using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ParserConsoleApplication
{
    public class Parser
    {
        public byte[] _page { get; private set; }
        public Parser(string path)
        {
            Init(path);
        }
        private async void Init(string path)
        {
            _page = await DownloadPage(path);
        }
        public async Task<List<string>> GetDomains()
        {
            if (_page != null)
            {
                List<string> domains = new List<string>();

                string result = System.Text.Encoding.UTF8.GetString(_page);

                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(result);
                foreach (var item in html.DocumentNode.SelectNodes("//*[@class='domain']"))
                {
                    domains.Add(item.InnerHtml);
                    Console.WriteLine(item.InnerHtml);
                }
                return domains;
            }
            Console.WriteLine("No domains");
            return null;
        }
        private async Task<byte[]> DownloadPage(string path)
        {
            var client = new WebClient();
            var link = "https://direct.yandex.ru/search?text=" + path;
            Uri uri = new Uri(link);
            var page = client.DownloadDataTaskAsync(uri);
            return page.Result;
        }
    }
}
