using System;

namespace ParserConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region [.input domain from keyboard - Replace to file parser]
            Console.WriteLine("Please, insert concrete domain:");
            var input = Console.ReadLine();
            Console.WriteLine(); 
            #endregion
            
            var parser = new Parser(input);
            var domains = parser.GetDomains();

            //TODO: Add select distinct(?) and save to file

            Console.WriteLine("{1}Common numbers of domains: {0}",domains.Result.Count, System.Environment.NewLine);
            Console.ReadKey();
        }
    }
}
