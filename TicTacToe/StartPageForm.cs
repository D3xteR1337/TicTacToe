using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class StartPageForm : Form
    {
        public StartPageForm()
        {
            InitializeComponent();
            playerVsBotRadio.Checked = true;
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (getBoardSize() == -1 || getGameType() == -1)
                MessageBox.Show("Не выбран размер поля или стиль игры!");
            else 
                GameStarting.startGame(getBoardSize(), getGameType());
        }
        
        public int getBoardSize()
        {
            if (smallSizeBoardRadio.Checked)
                return 1;
            else if (bigSizeBoardRadio.Checked)
                return 2;
            else return -1;
        }

        public int getGameType()
        {
            if (playerVsBotRadio.Checked)
                return 1;
            else if (playerVsPlayerRadio.Checked)
                return 2;
            else if (botVsBotRadio.Checked)
                return 3;
            else return -1;

        }
    }
}
