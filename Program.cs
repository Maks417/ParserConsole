using System;

namespace ParserConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("svetlanatex.ru");
            var domains = parser.GetDomains();

            Console.WriteLine("Common numbers of domains: {0}",domains.Result.Count);
            Console.ReadKey();
        }
    }
}
