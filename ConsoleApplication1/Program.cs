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
			 
		//	
			List<string> numbers = new List<string>();// = operations.Split('+').ToList();
			List<byte> acc = new List<byte> ();
					
			while( true)
			{

				int console = Console.Read ();
				if (console <= 57 && console >= 48) {
					//number
					acc.Add ((byte)console);
					//Console.Write (System.Text.ASCIIEncoding.ASCII.GetString (new byte [] {(byte) console }));
				}

				if (console == 43) // Add
				{
					Console.WriteLine ("\b");
					var res = System.Text.ASCIIEncoding.ASCII.GetString (acc.ToArray());
					acc.Clear ();
					numbers.Add (res);
					if (numbers.Count == 2) {
						float sum = 0;
						foreach (var number in numbers) {
							float value;
							float.TryParse (number, out value);
							sum += value;
						}
						numbers.Clear ();
						Console.WriteLine (sum);
					}
					Console.Write ('+');
					
					Console.WriteLine ();
				}
			}

			//if (!numbers.All (p => int.TryParse (p, out int i) || float.TryParse(p, out float f)))
			//{
			//	Console.WriteLine ("Letters are not allowed");
			//	Console.Clear ();
			//	goto REDO;
			//}

			//if (numbers.Count > 2) 
			//{
			//	int buffer = 0;
			//	for (int i = 0; i < numbers.Count ; i++) 
			//	{
			//		Console.Write ("Sum of " + buffer + " and " + numbers [i] + "is: ");
					 
			//		buffer += int.Parse (numbers [i]) - 1;

			//		Console.WriteLine (buffer);
			//	}
			//}else
   //         	Console.WriteLine($"The sum is: {numbers.Select(int.Parse).Sum()}");
            
			//Console.ReadLine();
        }
    }
}