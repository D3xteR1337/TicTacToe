using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameStarting
    {
        private static int currentGameNum = 0;
        public static void startGame(int gameSize, int gameType)
        {
            GameLogic.currentGameType = gameType;
            GameLogic.currentBoardSize = gameSize;


            if (gameSize == GameLogic.boardSizes["smallBoard"])
            {
                SmallBoardForm f = new SmallBoardForm();
                f.currentPlayerMove = currentGameNum % 2 + 1;
                f.Show();
            }
            else
            {
                BigBoardForm f = new BigBoardForm();
                f.currentPlayerMove = currentGameNum % 2 + 1;
                f.Show();
            }

            currentGameNum++;
        }
    }
}
