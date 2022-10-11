using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameLogic
    {
        public static Dictionary<string, int> gameTypes = new Dictionary<string, int>
        {
            {"playerVsBot", 1 },
            {"playerVsPlayer", 2 },
            {"botVsBot", 3 }
        };

        public static Dictionary<string, int> boardSizes = new Dictionary<string, int>
        {
            {"smallBoard", 1},
            {"bigBoard", 2}
        };

        public static int currentBoardSize { get; set; }
        public static int currentGameType { get; set; }


        /// <summary>
        /// Проверка окончания игры
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <returns>0 - ничья, 1 - победа первого, 2 - победа второго, 100 - игра не закончена</returns>
        public static byte IsGameEnded(byte[,] gameBoard)
        {
            byte gameResult = 100;

            if (IsPlayerWon(gameBoard, 1))
                return 1;
            if (IsPlayerWon(gameBoard, 2))
                return 2;


            foreach (var cell in gameBoard)
            {
                if (cell != 0)
                    gameResult = 0;
                else
                {
                    gameResult = 100;
                    break;
                }
            }
            return gameResult;
        }

        public static void BotMove()
        {

        }

        public static bool IsPlayerWon(byte[,] gameBoard, byte symbol)
        {
            int rowLength = Convert.ToInt32(Math.Sqrt(gameBoard.Length));
            bool isWon = false;
            //проверка строк
            for (int i = 0; i < rowLength; i++)
            {
                for (int k = 0; k < rowLength; k++)
                {
                    if (gameBoard[i, k] == symbol)
                        isWon = true;
                    else
                    {
                        isWon = false;
                        break;
                    }
                }
                if (isWon)
                    return isWon;
            }

            //проверка столбцов
            for (int i = 0; i < rowLength; i++)
            {
                for (int k = 0; k < rowLength; k++)
                {
                    if (gameBoard[k, i] == symbol)
                        isWon = true;
                    else
                    {
                        isWon = false;
                        break;
                    }
                }
                if (isWon)
                    return isWon;
            }

            //проверка диагоналей
            for (int i = 0; i < rowLength; i++)
            {
                if (gameBoard[i, i] == symbol)
                    isWon = true;
                else
                {
                    isWon = false;
                    break;
                }
            }
            if (isWon)
                return isWon;

            for (int i = rowLength; i > 0; i--)
            {
                if (gameBoard[rowLength - i, i - 1] == symbol)
                    isWon = true;
                else
                {
                    isWon = false;
                    break;
                }
            }
            if (isWon)
                return isWon;


            return false;
        }
    }
}
