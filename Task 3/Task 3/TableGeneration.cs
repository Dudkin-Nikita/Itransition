using System.Collections.Generic;
using ConsoleTables;

namespace Task_3
{
    public static class TableGeneration
    {
        public static string CreateTable(GameLogic gameLogic, string[] moves)
        {
            List<string> list = new List<string>();
            list.Add("PC/USER");
            list.AddRange(moves);

            var table = new ConsoleTable(list.ToArray());

            FillTable(table, gameLogic, moves);

            return table.ToString();

        }
        private static void FillTable(ConsoleTable table, GameLogic gameLogic, string[] moves)
        {
            foreach (var move in gameLogic.Elements)
            {
                string computerMove = move;
                List<string> row = new List<string>();
                row.Add(computerMove);

                for (int i = 0; i < moves.Length; i++)
                {
                    string result = gameLogic.Winner(moves[i],computerMove);
                    if (result == "win")
                    {
                        row.Add("WIN");
                    }
                    if (result == "lose")
                    {
                        row.Add("LOSE");
                    }
                    if (result == "draw")
                    {
                        row.Add("DRAW");
                    }
                }
                table.AddRow(row.ToArray());
            }
        }
    }
}
