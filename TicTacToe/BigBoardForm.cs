using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TicTacToe.GameLogic;

namespace TicTacToe
{
    public partial class BigBoardForm : Form
    {
        //какой игрок/бот ходит
        public int currentPlayerMove;
        int moveCounter = 0;
        Random random = new Random();

        public BigBoardForm()
        {
            InitializeComponent();
        }

        private void pos11_Click(object sender, EventArgs e) { placeMarker(pos11); }

        private void pos12_Click(object sender, EventArgs e) { placeMarker(pos12); }

        private void pos13_Click(object sender, EventArgs e) { placeMarker(pos13); }

        private void pos14_Click(object sender, EventArgs e) { placeMarker(pos14); }

        private void pos15_Click(object sender, EventArgs e) { placeMarker(pos15); }

        private void pos21_Click(object sender, EventArgs e) { placeMarker(pos21); }

        private void pos22_Click(object sender, EventArgs e) { placeMarker(pos22); }

        private void pos23_Click(object sender, EventArgs e) { placeMarker(pos23); }

        private void pos24_Click(object sender, EventArgs e) { placeMarker(pos24); }

        private void pos25_Click(object sender, EventArgs e) { placeMarker(pos25); }

        private void pos31_Click(object sender, EventArgs e) { placeMarker(pos31); }

        private void pos32_Click(object sender, EventArgs e) { placeMarker(pos32); }

        private void pos33_Click(object sender, EventArgs e) { placeMarker(pos33); }

        private void pos34_Click(object sender, EventArgs e) { placeMarker(pos34); }

        private void pos35_Click(object sender, EventArgs e) { placeMarker(pos35); }

        private void pos41_Click(object sender, EventArgs e) { placeMarker(pos41); }

        private void pos42_Click(object sender, EventArgs e) { placeMarker(pos42); }

        private void pos43_Click(object sender, EventArgs e) { placeMarker(pos43); }

        private void pos44_Click(object sender, EventArgs e) { placeMarker(pos44); }

        private void pos45_Click(object sender, EventArgs e) { placeMarker(pos45); }

        private void pos51_Click(object sender, EventArgs e) { placeMarker(pos51); }

        private void pos52_Click(object sender, EventArgs e) { placeMarker(pos52); }

        private void pos53_Click(object sender, EventArgs e) { placeMarker(pos53); }

        private void pos54_Click(object sender, EventArgs e) { placeMarker(pos54); }

        private void pos55_Click(object sender, EventArgs e) { placeMarker(pos55); }


        public void placeMarker(Label position)
        {
            if (position.Text == " ")
            {
                if (currentGameType == gameTypes["playerVsBot"])
                {
                    if (currentPlayerMove == 2)
                    {
                        position.Text = "O";
                        IsOver();
                        BotMakeMove(Bot.getBotMove(getGameBoard(), 1), "X");
                        IsOver();
                    }
                    else
                    {
                        position.Text = "X";
                        IsOver();
                        if (moveCounter++ < 12)
                        {
                            BotMakeMove(Bot.getBotMove(getGameBoard(), 2), "O");
                            IsOver();
                        }
                    }
                }
                else if (currentGameType == gameTypes["playerVsPlayer"])
                {
                    if (currentPlayerMove == 1)
                    {
                        position.Text = "X";
                        IsOver();
                        currentPlayerMove = 2;
                    }
                    else
                    {
                        position.Text = "O";
                        IsOver();
                        currentPlayerMove = 1;
                    }
                }
            }
        }

        public byte[,] getGameBoard()
        {
            var gameBoard = new byte[5, 5];
            gameBoard[0, 0] = textSymbolToNum(pos11.Text);
            gameBoard[0, 1] = textSymbolToNum(pos12.Text);
            gameBoard[0, 2] = textSymbolToNum(pos13.Text);
            gameBoard[0, 3] = textSymbolToNum(pos14.Text);
            gameBoard[0, 4] = textSymbolToNum(pos15.Text);
            gameBoard[1, 0] = textSymbolToNum(pos21.Text);
            gameBoard[1, 1] = textSymbolToNum(pos22.Text);
            gameBoard[1, 2] = textSymbolToNum(pos23.Text);
            gameBoard[1, 3] = textSymbolToNum(pos24.Text);
            gameBoard[1, 4] = textSymbolToNum(pos25.Text);
            gameBoard[2, 0] = textSymbolToNum(pos31.Text);
            gameBoard[2, 1] = textSymbolToNum(pos32.Text);
            gameBoard[2, 2] = textSymbolToNum(pos33.Text);
            gameBoard[2, 3] = textSymbolToNum(pos34.Text);
            gameBoard[2, 4] = textSymbolToNum(pos35.Text);
            gameBoard[3, 0] = textSymbolToNum(pos41.Text);
            gameBoard[3, 1] = textSymbolToNum(pos42.Text);
            gameBoard[3, 2] = textSymbolToNum(pos43.Text);
            gameBoard[3, 3] = textSymbolToNum(pos44.Text);
            gameBoard[3, 4] = textSymbolToNum(pos45.Text);
            gameBoard[4, 0] = textSymbolToNum(pos51.Text);
            gameBoard[4, 1] = textSymbolToNum(pos52.Text);
            gameBoard[4, 2] = textSymbolToNum(pos53.Text);
            gameBoard[4, 3] = textSymbolToNum(pos54.Text);
            gameBoard[4, 4] = textSymbolToNum(pos55.Text);
            return gameBoard;
        }

        public byte textSymbolToNum(string text)
        {
            byte num = 0;
            if (text == "X")
                num = 1;
            else if (text == "O")
                num = 2;
            return num;
        }

        public bool IsOver()
        {
            byte res = IsGameEnded(getGameBoard());
            if (res != 100)
            {
                if (res == 1 || res == 2)
                {

                    var winner = res == 2 ? "\"ноликов\"!" : "\"крестиков\"!";
                    MessageBox.Show($"Победа {winner}");
                }
                else if (res == 0)
                    MessageBox.Show("Ничья!");
                this.Close();
            }
            return false;
        }

        private void BotMakeMove(byte[] pos, string Symbol)
        {
            switch (pos[0])
            {
                case 0:
                    switch (pos[1])
                    {
                        case 0:
                            pos11.Text = Symbol;
                            break;
                        case 1:
                            pos12.Text = Symbol;
                            break;
                        case 2:
                            pos13.Text = Symbol;
                            break;
                        case 3:
                            pos14.Text = Symbol;
                            break;
                        case 4:
                            pos15.Text = Symbol;
                            break;
                    }
                    break;
                case 1:
                    switch (pos[1])
                    {
                        case 0:
                            pos21.Text = Symbol;
                            break;
                        case 1:
                            pos22.Text = Symbol;
                            break;
                        case 2:
                            pos23.Text = Symbol;
                            break;
                        case 3:
                            pos24.Text = Symbol;
                            break;
                        case 4:
                            pos25.Text = Symbol;
                            break;
                    }
                    break;
                case 2:
                    switch (pos[1])
                    {
                        case 0:
                            pos31.Text = Symbol;
                            break;
                        case 1:
                            pos32.Text = Symbol;
                            break;
                        case 2:
                            pos33.Text = Symbol;
                            break;
                        case 3:
                            pos34.Text = Symbol;
                            break;
                        case 4:
                            pos35.Text = Symbol;
                            break;
                    }
                    break;
                case 3:
                    switch (pos[1])
                    {
                        case 0:
                            pos41.Text = Symbol;
                            break;
                        case 1:
                            pos42.Text = Symbol;
                            break;
                        case 2:
                            pos43.Text = Symbol;
                            break;
                        case 3:
                            pos44.Text = Symbol;
                            break;
                        case 4:
                            pos45.Text = Symbol;
                            break;
                    }
                    break;
                case 4:
                    switch (pos[1])
                    {
                        case 0:
                            pos51.Text = Symbol;
                            break;
                        case 1:
                            pos52.Text = Symbol;
                            break;
                        case 2:
                            pos53.Text = Symbol;
                            break;
                        case 3:
                            pos54.Text = Symbol;
                            break;
                        case 4:
                            pos55.Text = Symbol;
                            break;
                    }
                    break;
            }
        }

        private void BigBoardForm_Activated(object sender, EventArgs e)
        {
            Task.Delay(random.Next(1000)).GetAwaiter().GetResult();
            if (currentPlayerMove == 2 && gameTypes["playerVsBot"] == currentGameType)
            {
                BotMakeMove(Bot.getBotMove(getGameBoard(), 1), "X");
            }
            else if (gameTypes["botVsBot"] == currentGameType)
            {
                while (moveCounter++ < 13)
                {
                    Task.Delay(random.Next(500, 1000)).GetAwaiter().GetResult();
                    BotMakeMove(Bot.getBotMove(getGameBoard(), 1), "X");
                    IsOver();
                    Task.Delay(random.Next(500, 1000)).GetAwaiter().GetResult();
                    BotMakeMove(Bot.getBotMove(getGameBoard(), 2), "O");
                    IsOver();
                }
            }
        }
    }
}
