using System;
using System.Collections.Generic;


namespace ConsoleApplication1
{
	class Program
	{
		enum Operation
		{
			None,
			Add,
			Sub,
			Mul,
			Div,
			Perc
		}
		static void Main (string [] args)
		{
			Console.WriteLine ("Welcome to Calculator!");

			Console.WriteLine ("Please Insert your operation and press enter");

			var operations = new Queue<string> ();


			//List<string> numbers = new List<string>();
			List<byte> numberAccumulator = new List<byte> ();
			//Stack<byte> accumulator = new Stack<byte>;

			float intermediateResult = 0;

			while (true) {
				int console = Console.Read ();
				if (console <= 57 && console >= 48 ) {
					//number 0..9 and .
					numberAccumulator.Add ((byte)console);
					continue;
				}
				if (console == 46) {
					if (numberAccumulator.Contains (46)) {
					Console.Write("\b"); //cancel
					}
					else
						numberAccumulator.Add ((byte)console);
					continue;
				}

				if (console == 43) // Add
				{
					Console.WriteLine ("\b"); //cancel + and create a new line
					var number = System.Text.ASCIIEncoding.ASCII.GetString (numberAccumulator.ToArray ());
					numberAccumulator.Clear ();
					operations.Enqueue (number);

					if (operations.Count == 3) // means it needs an intermidiate result
					{
						intermediateResult = Parse (operations);
						Console.WriteLine (intermediateResult);
						operations.Enqueue (intermediateResult.ToString ());
					}
					operations.Enqueue ("Add");

					Console.WriteLine ('+');

					continue;
				}

				if (console == 10 || console == 61) {
					var number = System.Text.ASCIIEncoding.ASCII.GetString (numberAccumulator.ToArray ());
					numberAccumulator.Clear ();
					operations.Enqueue (number);
					Console.WriteLine (Parse(operations));
					continue;
				}

				if (console == 42) { 
					Console.WriteLine ("\b"); //cancel + and create a new line
					var number = System.Text.ASCIIEncoding.ASCII.GetString (numberAccumulator.ToArray ());
					numberAccumulator.Clear ();
					operations.Enqueue (number);

					if (operations.Count == 3) // means it needs an intermidiate result
					{
						intermediateResult = Parse (operations);
						Console.WriteLine (intermediateResult);
						operations.Enqueue (intermediateResult.ToString ());
					}
					operations.Enqueue ("Mul");

					Console.WriteLine ('*');

					continue;
				}

				if (console == 47) {
					Console.WriteLine ("\b"); //cancel + and create a new line
					var number = System.Text.ASCIIEncoding.ASCII.GetString (numberAccumulator.ToArray ());
					numberAccumulator.Clear ();
					operations.Enqueue (number);

					if (operations.Count == 3) // means it needs an intermidiate result
					{
						intermediateResult = Parse (operations);
						Console.WriteLine (intermediateResult);
						operations.Enqueue (intermediateResult.ToString ());
					}
					operations.Enqueue ("Div");

					Console.WriteLine ('/');

					continue;
				}

				if (console == 45) //sub
				{
					Console.WriteLine ("\b"); //cancel - and create a new line
					var number = System.Text.ASCIIEncoding.ASCII.GetString (numberAccumulator.ToArray ());
					numberAccumulator.Clear ();
					operations.Enqueue (number);

					if (operations.Count == 3) // means it needs an intermidiate result
					{
						intermediateResult = Parse (operations);
						Console.WriteLine (intermediateResult);
						operations.Enqueue (intermediateResult.ToString());
					}
					operations.Enqueue ("Sub");
					
					Console.WriteLine ('-');
					continue;
				}
				Console.Write ("\b");
			}
		}

		static float Parse (Queue<string> operations)
		{
			float [] result = new float [2];
			int index = 0;
			Operation type = Operation.None;

			while (operations.Count >0) {
				string operation = operations.Dequeue ();
				float intermRes;
				if (float.TryParse (operation, out intermRes)) {
					result [index++] = intermRes;
				} else {
					//it's an operator
					type = (Operation)Enum.Parse (typeof (Operation), operation);
				}
			}

			switch (type) {
			case Operation.Add:
				return result [0] + result [1];
			case Operation.Sub:
				return result [0] - result [1];
			case Operation.Mul:
				return result [0] * result [1];
			case Operation.Div:
				return result [0] / result [1];
			case Operation.Perc:
				break;
			}

			throw new Exception ("No operation available");
		}
	}
}