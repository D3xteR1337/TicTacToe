using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Bot
    {
        // словари позиций элементов на диагонали (ключ - строка, значение - столбец)
        private static Dictionary<int, int> bigDiagonalPos = new Dictionary<int, int>
        {
            { 0, 0 },
            { 1, 1 },
            { 2, 2 },
            { 3, 3 },
            { 4, 4 },
        };

        private static Dictionary<int, int> bigDiagonalNeg = new Dictionary<int, int>
        {

            { 0, 4 },
            { 1, 3 },
            { 2, 2 },
            { 3, 1 },
            { 4, 0 }
        };

        private static Dictionary<int, int> smallDiagonalPos = new Dictionary<int, int>
        {
            { 0, 0 },
            { 1, 1 },
            { 2, 2 },
        };

        private static Dictionary<int, int> smallDiagonalNeg = new Dictionary<int, int>
        {
            { 0, 2 },
            { 1, 1 },
            { 2, 0 },
        };



        public static byte[] getBotMove(byte[,] gameBoard, int currSymbol)
        {
            Random randSameRateCellSelector = new Random();
            var pos = new byte[2];
            var maxValue = 0;
            var rateTable = new int[gameBoard.GetLength(0), gameBoard.GetLength(1)];
            if (GameLogic.currentBoardSize == GameLogic.boardSizes["smallBoard"])
                rateTable = CalculateRateSmall(gameBoard, (byte)currSymbol);
            else
                rateTable = CalculateRateBig(gameBoard, (byte)currSymbol);

            for (int i = 0; i < rateTable.GetLength(0); i++)
            {
                for (int k = 0; k < rateTable.GetLength(1); k++)
                {
                    if (rateTable[i, k] > maxValue)
                    {
                        
                        pos[0] = (byte)i;
                        pos[1] = (byte)k;
                        maxValue = rateTable[i, k];
                    }
                    if (rateTable[i, k] == maxValue && randSameRateCellSelector.Next(10) > 5)
                    {
                        pos[0] = (byte)i;
                        pos[1] = (byte)k;
                    }
                }
            }


            return pos;
        }

        private static int[,] CalculateRateSmall(byte[,] gameBoard, byte currSymbol)
        {
            byte oppositeSymbol = (byte)(currSymbol == 1 ? 2 : 1);

            var rate = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            for (int i = 0; i < 3; i++)
            {
                var currRow = GetRow(gameBoard, i);
                for (int k = 0; k < 3; k++)
                {
                    //проверка на пустоту поля
                    if (gameBoard[i, k] == 0)
                        rate[i, k] += 1;
                    else
                        continue;

                    
                    if (currRow.Contains(currSymbol))
                    {
                        if (currRow.IndexOf(currSymbol) == currRow.LastIndexOf(currSymbol))
                            rate[i, k] += 100;
                        else
                            rate[i, k] += 100000;
                    }

                    if (currRow.Contains(oppositeSymbol))
                    {
                        if (currRow.IndexOf(oppositeSymbol) == currRow.LastIndexOf(oppositeSymbol))
                            rate[i, k] += 1000;
                        else
                            rate[i, k] += 10000;
                    }

                    if (GetColumn(gameBoard, k).Contains(currSymbol))
                    {
                        if (GetColumn(gameBoard, k).IndexOf(currSymbol) == GetColumn(gameBoard, k).LastIndexOf(currSymbol))
                            rate[i, k] += 100;
                        else
                            rate[i, k] += 100000;
                    }

                    if (GetColumn(gameBoard, k).Contains(oppositeSymbol))
                    {
                        if (GetColumn(gameBoard, k).IndexOf(oppositeSymbol) == GetColumn(gameBoard, k).LastIndexOf(oppositeSymbol))
                            rate[i, k] += 1000;
                        else
                            rate[i, k] += 10000;
                    }



                    if (smallDiagonalPos[i] == k)
                    {
                        var posDiagonalList = new List<byte>();
                        posDiagonalList.Add(gameBoard[0, smallDiagonalPos[0]]);
                        posDiagonalList.Add(gameBoard[1, smallDiagonalPos[1]]);
                        posDiagonalList.Add(gameBoard[2, smallDiagonalPos[2]]);

                        if (posDiagonalList.Contains(currSymbol))
                        {
                            if (posDiagonalList.IndexOf(currSymbol) == posDiagonalList.LastIndexOf(currSymbol))
                                rate[i, k] += 100;
                            else
                                rate[i, k] += 100000;
                        }

                        if (posDiagonalList.Contains(oppositeSymbol))
                        {
                            if (posDiagonalList.IndexOf(oppositeSymbol) == posDiagonalList.LastIndexOf(oppositeSymbol))
                                rate[i, k] += 1000;
                            else
                                rate[i, k] += 10000;
                        }
                        rate[i, k] += 1;
                    }

                    if (smallDiagonalNeg[i] == k)
                    {
                        var negDiagonalList = new List<byte>();
                        negDiagonalList.Add(gameBoard[0, smallDiagonalNeg[0]]);
                        negDiagonalList.Add(gameBoard[1, smallDiagonalNeg[1]]);
                        negDiagonalList.Add(gameBoard[2, smallDiagonalNeg[2]]);

                        if (negDiagonalList.Contains(currSymbol))
                        {
                            if (negDiagonalList.IndexOf(currSymbol) == negDiagonalList.LastIndexOf(currSymbol))
                                rate[i, k] += 100;
                            else
                                rate[i, k] += 100000;
                        }

                        if (negDiagonalList.Contains(oppositeSymbol))
                        {
                            if (negDiagonalList.IndexOf(oppositeSymbol) == negDiagonalList.LastIndexOf(oppositeSymbol))
                                rate[i, k] += 1000;
                            else
                                rate[i, k] += 10000;
                        }
                        rate[i, k] += 1;
                    }
                }
            }
            return rate;
        }

        private static int[,] CalculateRateBig(byte[,] gameBoard, byte currSymbol)
        {
            byte oppositeSymbol = (byte)(currSymbol == 1 ? 2 : 1);

            var rate = new int[,] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            for (int i = 0; i < 5; i++)
            {
                var currRow = GetRow(gameBoard, i);
                for (int k = 0; k < 5; k++)
                {
                    //проверка на пустоту поля
                    if (gameBoard[i, k] == 0)
                        rate[i, k] += 1;
                    else
                        continue;


                    if (currRow.Contains(currSymbol))
                    {
                        switch (currRow.Where(x => x.Equals(currSymbol)).Count())
                        {
                            case 1:
                                rate[i, k] += 100;
                                break;
                            case 2:
                                rate[i, k] += 1000;
                                break;
                            case 3:
                                rate[i, k] += 10000;
                                break;
                            case 4:
                                rate[i, k] += 500000;
                                break;
                        }
                    }

                    if (currRow.Contains(oppositeSymbol))
                    {
                        switch (currRow.Where(x => x.Equals(oppositeSymbol)).Count())
                        {
                            case 1:
                                rate[i, k] += 500;
                                break;
                            case 2:
                                rate[i, k] += 5000;
                                break;
                            case 3:
                                rate[i, k] += 50000;
                                break;
                            case 4:
                                rate[i, k] += 100000;
                                break;
                        }
                    }

                    if (GetColumn(gameBoard, k).Contains(currSymbol))
                    {
                        switch (GetColumn(gameBoard, k).Where(x => x.Equals(currSymbol)).Count())
                        {
                            case 1:
                                rate[i, k] += 100;
                                break;
                            case 2:
                                rate[i, k] += 1000;
                                break;
                            case 3:
                                rate[i, k] += 10000;
                                break;
                            case 4:
                                rate[i, k] += 500000;
                                break;
                        }
                    }

                    if (GetColumn(gameBoard, k).Contains(oppositeSymbol))
                    {
                        switch (GetColumn(gameBoard, k).Where(x => x.Equals(oppositeSymbol)).Count())
                        {
                            case 1:
                                rate[i, k] += 500;
                                break;
                            case 2:
                                rate[i, k] += 5000;
                                break;
                            case 3:
                                rate[i, k] += 50000;
                                break;
                            case 4:
                                rate[i, k] += 100000;
                                break;
                        }
                    }



                    if (bigDiagonalPos[i] == k)
                    {
                        var bigDiagonalList = new List<byte>();
                        bigDiagonalList.Add(gameBoard[0, bigDiagonalPos[0]]);
                        bigDiagonalList.Add(gameBoard[1, bigDiagonalPos[1]]);
                        bigDiagonalList.Add(gameBoard[2, bigDiagonalPos[2]]);
                        bigDiagonalList.Add(gameBoard[3, bigDiagonalPos[3]]);
                        bigDiagonalList.Add(gameBoard[4, bigDiagonalPos[4]]);

                        if (bigDiagonalList.Contains(currSymbol))
                        {
                            switch (bigDiagonalList.Where(x => x.Equals(currSymbol)).Count())
                            {
                                case 1:
                                    rate[i, k] += 100;
                                    break;
                                case 2:
                                    rate[i, k] += 1000;
                                    break;
                                case 3:
                                    rate[i, k] += 10000;
                                    break;
                                case 4:
                                    rate[i, k] += 500000;
                                    break;
                            }
                        }

                        if (bigDiagonalList.Contains(oppositeSymbol))
                        {
                            switch (bigDiagonalList.Where(x => x.Equals(oppositeSymbol)).Count())
                            {
                                case 1:
                                    rate[i, k] += 500;
                                    break;
                                case 2:
                                    rate[i, k] += 5000;
                                    break;
                                case 3:
                                    rate[i, k] += 50000;
                                    break;
                                case 4:
                                    rate[i, k] += 100000;
                                    break;
                            }
                        }
                        rate[i, k] += 1;
                    }

                    if (bigDiagonalNeg[i] == k)
                    {
                        var bigDiagonalList = new List<byte>();
                        bigDiagonalList.Add(gameBoard[0, bigDiagonalNeg[0]]);
                        bigDiagonalList.Add(gameBoard[1, bigDiagonalNeg[1]]);
                        bigDiagonalList.Add(gameBoard[2, bigDiagonalNeg[2]]);
                        bigDiagonalList.Add(gameBoard[3, bigDiagonalNeg[3]]);
                        bigDiagonalList.Add(gameBoard[4, bigDiagonalNeg[4]]);

                        if (bigDiagonalList.Contains(currSymbol))
                        {
                            switch (bigDiagonalList.Where(x => x.Equals(currSymbol)).Count())
                            {
                                case 1:
                                    rate[i, k] += 100;
                                    break;
                                case 2:
                                    rate[i, k] += 1000;
                                    break;
                                case 3:
                                    rate[i, k] += 10000;
                                    break;
                                case 4:
                                    rate[i, k] += 500000;
                                    break;
                            }
                        }

                        if (bigDiagonalList.Contains(oppositeSymbol))
                        {
                            switch (bigDiagonalList.Where(x => x.Equals(oppositeSymbol)).Count())
                            {
                                case 1:
                                    rate[i, k] += 500;
                                    break;
                                case 2:
                                    rate[i, k] += 5000;
                                    break;
                                case 3:
                                    rate[i, k] += 50000;
                                    break;
                                case 4:
                                    rate[i, k] += 100000;
                                    break;
                            }
                        }
                        rate[i, k] += 1;
                    }
                }
            }
            return rate;
        }


        private static List<byte> GetRow(byte[,] mtrx, int rowNumber)
        {
            return Enumerable.Range(0, mtrx.GetLength(1)).Select(x => mtrx[rowNumber, x]).ToList();
        }

        private static List<byte> GetColumn(byte[,] mtrx, int columnNumber)
        {
            return Enumerable.Range(0, mtrx.GetLength(0)).Select(x => mtrx[x, columnNumber]).ToList();
        }
    }
}
