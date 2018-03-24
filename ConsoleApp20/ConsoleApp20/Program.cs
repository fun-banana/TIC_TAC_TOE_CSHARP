using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
			ConsoleKeyInfo YesOrNo;
			ConsoleKeyInfo Level;

			Console.WriteLine("Select difficulty level [ Easy ( e ) or  Medium ( m ) or Hard ( h ) ]");
			Level = Console.ReadKey();


			do
			{
				string Cells = "  ╔═╦═╦═╗\n  ║1║2║3║\n  ╠═╬═╬═╣\n  ║4║5║6║\n  ╠═╬═╬═╣\n  ║7║8║9║\n  ╚═╩═╩═╝";
				int[,] WinsCombinations = new int[8, 3] { { 2, 5, 8 }, { 3, 5, 7 }, { 1, 5, 9 }, { 4, 5, 6 }, { 1, 2, 3 }, { 1, 4, 7 }, { 7, 8, 9 }, { 3, 6, 9 } };
				int[] FreeCells = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
				int[] Player = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
				int[] Bot = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
				int NumberCell;
				int test = 0;
				int check = 0;
				int introduced = 0;
				bool finish = false;
				ConsoleKeyInfo NumCell;

				//Console.Clear();
				//Console.WriteLine("Select difficulty level [ Easy ( e ) or  Medium ( m ) or Hard ( h ) ]");
				//Level = Console.ReadKey();
				Console.Clear();
				Console.WriteLine(Cells);

				while (true) // One game
				{
					// Input player progress
					while (true)
					{
						try
						{
							do
							{
								NumCell = Console.ReadKey();
								if (Convert.ToInt32(NumCell.Key) < 65)
									NumberCell = Convert.ToInt32(NumCell.Key) - 48;
								else
									NumberCell = Convert.ToInt32(NumCell.Key) - 96;
								Console.Clear();
								Console.WriteLine(Cells);
							}
							while (NumberCell != FreeCells[NumberCell - 1]);
							break;
						}
						catch (Exception)
						{
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Clear();
							Console.WriteLine("Enter Number 1-9");
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine(Cells);
						}
					}
					//

					//
					introduced++;
					string str = Convert.ToString(NumberCell);
					Cells = Cells.Replace(str, "x");
					FreeCells[NumberCell - 1] = 0;
					Player[NumberCell - 1] = NumberCell;
					//

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
							Thread.Sleep(1500);
							//Console.ReadKey();
							finish = true;
							break;
						}
						test = 0;
					}
					//

					// Check whether the party is over
					if (introduced == 9)
					{
						Console.Clear();
						Console.WriteLine(Cells);
						break;
					}
					//

					Console.Clear();
					Console.WriteLine(Cells);

					// Check whether anyone has won
					if (finish == true) { break; }
					//

					// generation of bot progress
					do
					{
						bool find = false;

						//
						if (Level.Key == ConsoleKey.M || Level.Key == ConsoleKey.H)
						{
							//
							for (int k = 2; k > 0; k--)
							{
								if (find == true)
									break;

								if (k == 1)
								{
									///
									for (int x = 0; x < 8; x++)
									{
										test = 0;
										for (int z = 0; z < 3; z++)
										{
											if (WinsCombinations[x, z] == Player[WinsCombinations[x, z] - 1])
											{
												test++;
											}
										}
										if (test == 2)
										{
											for (int z = 0; z < 3; z++)
											{
												if (WinsCombinations[x, z] == FreeCells[WinsCombinations[x, z] - 1])
												{
													NumberCell = WinsCombinations[x, z];
													find = true;
													break;
												}
											}
										}

										if (find == true)
											break;

										test = 0;

									}
									///
								}

								for (int j = 0; j < 8; j++)
								{
									int free = 0;
									check = 0;
									for (int z = 0; z < 3; z++)
									{
										if (WinsCombinations[j, z] == Bot[WinsCombinations[j, z] - 1])
										{
											check++;
										}
									}

									if (k == check)
									{
										for (int y = 0; y < 3; y++)
										{
											if (WinsCombinations[j, y] == FreeCells[WinsCombinations[j, y] - 1])
											{
												free++;
											}
										}
									}
									if (free == 3 - k)
									{
										//Console.WriteLine(find);
										//Console.ReadKey();
										Random random = new Random();
										for (int a = 0; a < 3; a++)
										{
											NumberCell = WinsCombinations[j, a];
											if (NumberCell == FreeCells[NumberCell - 1])
											{
												find = true;
												break;
											}
										}
									}
								}

								if (find == true)
								{
									break;
								}
							}
						}
							if (find == false)
							{
								Random random = new Random();
								NumberCell = random.Next(1, 9);
								//Console.WriteLine("Random");
							}
					}
					
					//
					while (NumberCell != FreeCells[NumberCell - 1]);
					//

					//
					introduced++;
					Console.WriteLine(NumberCell);
					str = Convert.ToString(NumberCell);
					Cells = Cells.Replace(str, "o");
					FreeCells[NumberCell - 1] = 0;
					Bot[NumberCell - 1] = NumberCell;
					Console.WriteLine(Cells);
					test = 0;
					//

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
							//Console.ReadKey();
							Thread.Sleep(1500);
							finish = true;
							break;
						}
						test = 0;
					}
					//
					Console.Clear();
					Console.WriteLine(Cells);

					// Check whether anyone has won
					if (finish == true) { break; }
					//

				} // game

				if (finish == false)
				{
					Console.WriteLine("Draw");
					Thread.Sleep(1500);
					//Console.ReadKey();
				}

				Console.Clear();
				Console.WriteLine(Cells);
				Console.WriteLine("Continue? (y/n)");
				YesOrNo = Console.ReadKey();
			}
			while (YesOrNo.Key != ConsoleKey.N);
		}
	}
}
