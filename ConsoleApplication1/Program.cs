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
		REDO:
            Console.WriteLine("Please Insert your operation and press enter");

            string operations = Console.ReadLine();

			var numbers = operations.Split('+').ToList();

			if (!numbers.All (p => int.TryParse (p, out int i)))
			{
				Console.WriteLine ("Letters are not allowed");
				Console.Clear ();
				goto REDO;
			}

			if (numbers.Count > 2) 
			{
				int buffer = 0;
				for (int i = 0; i < numbers.Count ; i++) 
				{
					Console.Write ("Sum of " + buffer + " and " + numbers [i] + "is: ");
					 
					buffer += int.Parse (numbers [i]) - 1;

					Console.WriteLine (buffer);
				}
			}else
            	Console.WriteLine($"The sum is: {numbers.Select(int.Parse).Sum()}");
            
			Console.ReadLine();
        }
    }
}