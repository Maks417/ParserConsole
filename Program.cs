using System;
using System.Linq;

namespace ParserConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Get domain name from file
            Console.WriteLine("Please, insert concrete domain:");
            var input = Console.ReadLine();

            var parser = new Parser(input);
            var ads = parser.GetAds();

            //TODO: Add select distinct(?) and save to file
            Console.WriteLine("{1}Number of ads: {0}{1}", ads.Count(), Environment.NewLine);
            foreach (var domain in ads)
            {
                Console.WriteLine(domain);
            }
            Console.WriteLine("{0}Press any key to close app...", Environment.NewLine);
            Console.ReadKey();
        }
    }
}
