using System.Numerics;
using System;
using System.Collections;
namespace Lab01_EstuardoVilleda_1003519
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string regexp = Console.ReadLine();
                Scanner scanner = new Scanner(regexp);
                Parser parser = new Parser();
                Console.WriteLine(parser.Parse(regexp));
                Console.WriteLine("OK");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
             
          
        }
    }
}
