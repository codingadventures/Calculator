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

			List<string> numbers = new List<string>();
			List<byte> acc = new List<byte> ();
			//Stack<byte> accumulator = new Stack<byte>;

			float sum = 0;
					
			while(true)
			{
				int console = Console.Read ();
				if (console <= 57 && console >= 48 || console == 46) {
					//number 0..9 and .
					acc.Add ((byte)console);
					continue;
				}

				if (console == 43) // Add
				{
					Console.WriteLine ("\b"); //cancel + and create a new line
					var res = System.Text.ASCIIEncoding.ASCII.GetString (acc.ToArray());
					acc.Clear ();
					numbers.Add (res);
					float value;
					float.TryParse (res, out value);
					sum += value;

					if(numbers.Count > 1)
					Console.WriteLine (sum);
					Console.WriteLine ('+');
					
					continue;
				}

				if (console == 10 || console == 61) { 
					//enter or equal
					var res = System.Text.ASCIIEncoding.ASCII.GetString (acc.ToArray ());
					acc.Clear ();
					numbers.Add (res);
					foreach (var number in numbers) {
						float value;
						float.TryParse (number, out value);
						sum += value;
					}
					numbers.Clear ();
					Console.WriteLine (sum);
					continue;
				}
				Console.Write ("\b");
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