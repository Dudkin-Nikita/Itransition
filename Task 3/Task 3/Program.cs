using System;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic gameLogic = new GameLogic(args);
            if(gameLogic.IsCorrect() == false)
            {
                Console.WriteLine("Mistake");
            }
            else
            {
                string key = Generator.KeyGenerator();
                string computerMove = Generator.MoveGenerator(args);
                string hmac = Generator.HMACGenerator(computerMove, key);

                Console.WriteLine("HMAC: " + hmac);

                ShowCommands(gameLogic.Elements);

                string playerMove;
                int move;
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "?")
                    {
                        PrintTable(gameLogic, args);
                    }
                    else if (input == "0")
                    {
                        return;
                    }
                    else
                    {  
                        try
                        {
                            move = Int32.Parse(input);
                            if (move <= gameLogic.Elements.Length)
                            {
                                playerMove = gameLogic.Elements[move - 1];
                                break;
                            }
                            Console.WriteLine("Error. Try again");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Incorrect input");
                        }
                    }
                }
                Console.WriteLine("Your move: " + playerMove);
                Console.WriteLine("Computers move: " + computerMove);
                Console.WriteLine(gameLogic.Winner(playerMove, computerMove));

                Console.WriteLine("Key: " + key);
            }
        }

        public static void ShowCommands(string[] moves)
        {
            Console.WriteLine("Available moves: ");
            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine((i+1) + " - " + moves[i]);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }
        public static void PrintTable(GameLogic gameLogic, string[] moves)
        { 
            Console.WriteLine(TableGeneration.CreateTable(gameLogic, moves)); 
        }
    }
}
