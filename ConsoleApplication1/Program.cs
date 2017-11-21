using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calculator!");
            Console.WriteLine("Please Insert your operation and press enter");

            string operations = Console.ReadLine();

            var numbers = operations.Split('+').ToList();


            Console.WriteLine($"The sum is: {numbers.Select(int.Parse).Sum()}2+ ");
            Console.ReadLine();
        }
    }
}