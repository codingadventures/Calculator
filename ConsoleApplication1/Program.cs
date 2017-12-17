using System;
using System.Collections.Generic;


namespace ConsoleApplication1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calculator!");

            Console.WriteLine("Please Insert your operation and press enter");

            var parser = new Parser();

            parser.NumberInserted += (sender, eventArgs) => Console.WriteLine("\b");
            parser.OperatorInserted += (sender, s) =>
            {
                if (parser.IsResultAvalable)
                {
                    Console.WriteLine("------");
                    Console.WriteLine(parser.CalculateResult());
                }
                Console.WriteLine(s);

            };
            parser.OperatorReplaced += (sender, s) =>
            {
                Console.WriteLine("\b");
                Console.SetCursorPosition(0, Console.CursorTop - 2);
            };
            
            parser.InvalidChar += (sender, eventArgs) => Console.Write("\b");
            parser.MoreThanOneDotInserted+= (sender, eventArgs) => Console.Write("\b");
            
            parser.EnterInserted += (sender, eventArgs) =>
            {
                Console.WriteLine("------");
                Console.WriteLine(parser.CalculateResult());
            };
            
            while (true)
            {
                var console = Console.Read();
                
                parser.Add((byte)console);
            }
        }
    }
}