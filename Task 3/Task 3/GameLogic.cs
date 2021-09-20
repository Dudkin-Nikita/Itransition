using System.Linq;

namespace Task_3
{
    public class GameLogic
    {
        public string[] Elements { get; set; }

        public GameLogic(string[] elements)
        {
            Elements = elements;
        }
        public bool IsCorrect()
        {
            if (Elements.Length % 2 == 0 || Elements.Length < 3)
                return false;
            if (Elements.Length != Elements.Distinct().Count())
            {
                return false;
            }
            return true;
        }
        public string Winner(string playerMove, string computerMove)
        {
            int playerIndex = 0, computerIndex = 0;
            for(int i = 0; i < Elements.Length; i++)
            {
                if (playerMove == Elements[i])
                {
                    playerIndex = i;
                }
                if (computerMove == Elements[i])
                {
                    computerIndex = i;
                }
            }

            if(playerIndex == computerIndex) return "draw";
            if(playerIndex > computerIndex)
            {
                return (playerIndex - Elements.Length / 2) > computerIndex ? "lose" : "win";
            }
            else
            {
                return (computerIndex - Elements.Length / 2) > playerIndex ? "win" : "lose";
            }
        }
    }
}
