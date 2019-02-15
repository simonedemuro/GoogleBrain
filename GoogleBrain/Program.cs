using System;

namespace GoogleBrain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GbrainAPI g = new GbrainAPI();

            long colombo = g.GetNumerOfResults("chi ha scoperto l'america?", "Colombo");
            Console.WriteLine("chi ha scoperto l'america?, Colombo ("+ colombo + ")");

            long micky = g.GetNumerOfResults("chi ha scoperto l'america?", "Miky Mouse");
            Console.WriteLine("chi ha scoperto l'america?, Miky Mouse(" + micky + ")");

            Console.WriteLine();

            while (true)
            {
                string input = Console.ReadLine();
                long resNum = g.GetNumerOfResults(input);
                Console.WriteLine(resNum);
            }

            Console.Read();
        }
    }
}
