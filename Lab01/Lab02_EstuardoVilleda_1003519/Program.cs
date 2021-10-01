using System.Numerics;
using System;
using System.Collections;
namespace Lab01_EstuardoVilleda_1003519
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            do
            {
                try
                {                
                    
                        Console.WriteLine("Ingresa la cadena de operaciones");
                        string regexp = Console.ReadLine();
                        Scanner scanner = new Scanner(regexp);

                        Console.WriteLine(parser.Parse(regexp));
                        Console.WriteLine("OK");                

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                   
                }
                Console.WriteLine("Deseas Continuar? Y/N");
            } while (Console.ReadLine().ToLower().Equals("y") ? true : false);
            
             
          
        }
    }
}
