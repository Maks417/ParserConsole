﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ParserConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var page = DownloadPage("garpix.ru");
            var domains = GetDomains(page.Result);

            Console.WriteLine("Common numbers of domains: {0}",domains.Result.Count);
            Console.ReadKey();
        }

        private static async Task<List<string>> GetDomains(byte[] page)
        {
            if (page != null)
            {
                List<string> domains = new List<string>();

                string result = System.Text.Encoding.UTF8.GetString(page);

                HtmlDocument html = new HtmlDocument();
                html.LoadHtml(result);
                foreach (var item in html.DocumentNode.SelectNodes("//*[@class='domain']"))
                {
                    domains.Add(item.InnerHtml);
                }
                return domains;
            }
            Console.WriteLine("No domains");
            return null;
        }

        private static async Task<byte[]> DownloadPage(string path)
        {
            var client = new WebClient();
            var link = "https://direct.yandex.ru/search?text=" + path;
            Uri uri = new Uri(link);            
            var page = client.DownloadDataTaskAsync(uri);
            return page.Result;
        }
    }
}