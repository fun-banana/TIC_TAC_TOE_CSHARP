using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
	class Program
	{

			//int[] win1 = new int[3] { 2, 5, 8 }; 
			//int[] win2 = new int[3] { 3, 5, 7 };
			//int[] win3 = new int[3] { 1, 5, 9 };
			//int[] win4 = new int[3] { 4, 5, 6 };
			//int[] win5 = new int[3] { 1, 2, 3 };
			//int[] win6 = new int[3] { 1, 4, 7 };
			//int[] win7 = new int[3] { 7, 8, 9 };
			//int[] win8 = new int[3] { 3, 6, 9 };

			//Console.WriteLine("╔═╦═╦═╗");
			//Console.WriteLine("║1║2║3║");
			//Console.WriteLine("╠═╬═╬═╣");
			//Console.WriteLine("║4║5║6║");
			//Console.WriteLine("╠═╬═╬═╣");
			//Console.WriteLine("║7║8║9║");
			//Console.WriteLine("╚═╩═╩═╝");


		static void Main(string[] args)
		{
			string Cells = "╔═╦═╦═╗\n║1║2║3║\n╠═╬═╬═╣\n║4║5║6║\n╠═╬═╬═╣\n║7║8║9║\n╚═╩═╩═╝";
			int[,] WinsCombinations = new int[8, 3] { { 2, 5, 8 }, { 3, 5, 7 }, { 1, 5, 9 }, { 4, 5, 6 }, { 1, 2, 3 }, { 1, 4, 7 }, { 7, 8, 9 }, { 3, 6, 9 } };
			int[] FreeCells = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			int[] Player = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			int[] Bot = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			int NumberCell;
			int test = 0;
			int introduced = 0;
			bool finish = false;

			Console.WriteLine(Cells);

			while(true)
			{
				//
				while (true)
				{
					try
					{
						do
						{
							NumberCell = int.Parse(Console.ReadLine());
						}
						while (NumberCell != FreeCells[NumberCell - 1]);
						break;
					}
					catch (Exception)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Enter Number 1-9");
						Console.ForegroundColor = ConsoleColor.White;
					}
				}

				introduced++;
				string str = Convert.ToString(NumberCell);
				Cells = Cells.Replace(str, "x");
				FreeCells[NumberCell - 1] = 0;
				Player[NumberCell - 1] = NumberCell;
				
				// Check whether the player has won
				for (int j = 0; j < 8; j++)
				{
					for (int z = 0; z < 3; z++)
					{
						if (WinsCombinations[j, z] == Player[WinsCombinations[j, z] - 1])
						{
							test++; 
						}
					}
					if (test == 3)
					{
						Console.Clear();
						Console.WriteLine(Cells);
						Console.WriteLine("Player Won");
						Console.ReadKey();
						finish = true;
						break;
					}
					test = 0;
				}
				//

				if (introduced == 9)
				{
					Console.Clear();
					Console.WriteLine(Cells);
					break;
				}

				Console.Clear();
				Console.WriteLine(Cells);

				if (finish == true) { break; }

				//Console.Clear();
				//Console.WriteLine(Cells);

				
				do
				{
					Random random = new Random();
					NumberCell = random.Next(1, 9);
				}
				while (NumberCell != FreeCells[NumberCell - 1]);

				introduced++;
				Console.WriteLine(NumberCell);
				str = Convert.ToString(NumberCell);
				Cells = Cells.Replace(str, "o");
				FreeCells[NumberCell - 1] = 0;
				Bot[NumberCell - 1] = NumberCell;
				Console.WriteLine(Cells);
				////

				// Check whether the bot has won
				for (int j = 0; j < 8; j++)
				{
					for (int z = 0; z < 3; z++)
					{
						if (WinsCombinations[j, z] == Bot[WinsCombinations[j, z] - 1])
						{
							test++;
						}
					}
					if (test == 3)
					{

						Console.Clear();
						Console.WriteLine(Cells);
						Console.WriteLine("Bot Won");
						Console.ReadKey();
						finish = true;
						break;
					}
					test = 0;
				}
				//
				Console.Clear();
				Console.WriteLine(Cells);

				if (finish == true) { break; }
			}
			if (finish == false)
			{
				Console.WriteLine("Draw"); 
			}
			Console.WriteLine("FINISH");
			Console.ReadKey();
		}
	}
}
