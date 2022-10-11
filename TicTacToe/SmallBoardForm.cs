using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TicTacToe.GameLogic;

namespace TicTacToe
{
    public partial class SmallBoardForm : Form
    {
        //какой игрок/бот ходит
        public int currentPlayerMove;
        int moveCounter = 0;
        Random random = new Random();
        public SmallBoardForm()
        {
            InitializeComponent();
        }

        private void pos11_Click(object sender, EventArgs e) { placeMarker(pos11); pos11.Enabled = false; }

        private void pos12_Click(object sender, EventArgs e) { placeMarker(pos12); pos12.Enabled = false; }

        private void pos13_Click(object sender, EventArgs e) { placeMarker(pos13); pos13.Enabled = false; }

        private void pos21_Click(object sender, EventArgs e) { placeMarker(pos21); pos21.Enabled = false; }

        private void pos22_Click(object sender, EventArgs e) { placeMarker(pos22); pos22.Enabled = false; }

        private void pos23_Click(object sender, EventArgs e) { placeMarker(pos23); pos23.Enabled = false; }

        private void pos31_Click(object sender, EventArgs e) { placeMarker(pos31); pos31.Enabled = false; }

        private void pos32_Click(object sender, EventArgs e) { placeMarker(pos32); pos32.Enabled = false; }

        private void pos33_Click(object sender, EventArgs e) { placeMarker(pos33); pos33.Enabled = false; }

        public void placeMarker(Label position)
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
                    if (moveCounter++ < 4)
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

        public byte[,] getGameBoard()
        {
            var gameBoard = new byte[3,3];
            gameBoard[0, 0] = textSymbolToNum(pos11.Text);
            gameBoard[0, 1] = textSymbolToNum(pos12.Text);
            gameBoard[0, 2] = textSymbolToNum(pos13.Text);
            gameBoard[1, 0] = textSymbolToNum(pos21.Text);
            gameBoard[1, 1] = textSymbolToNum(pos22.Text);
            gameBoard[1, 2] = textSymbolToNum(pos23.Text);
            gameBoard[2, 0] = textSymbolToNum(pos31.Text);
            gameBoard[2, 1] = textSymbolToNum(pos32.Text);
            gameBoard[2, 2] = textSymbolToNum(pos33.Text);
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

        public void BotMakeMove(byte[] pos, string Symbol)
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
                    }
                    break;
            }
        }

        private void SmallBoardForm_Activated(object sender, EventArgs e)
        {
            Task.Delay(random.Next(1000)).GetAwaiter().GetResult();
            if (currentPlayerMove == 2 && gameTypes["playerVsBot"] == currentGameType)
            {
                BotMakeMove(Bot.getBotMove(getGameBoard(), 1), "X");
            }
            else if (gameTypes["botVsBot"] == currentGameType)
            {
                while (moveCounter++ < 5)
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
