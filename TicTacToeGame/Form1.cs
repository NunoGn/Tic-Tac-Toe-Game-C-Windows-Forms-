using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class frmPainelJogo : Form
    {

        //DECLARATION OF VARIABLES

        int xWins, xDraws, xDefeats, oWins, oDraws, oDefeats, round = 0;
        bool shift = true;
        bool endGame = false;
        string[] game = new string[9];



        public frmPainelJogo()
        {
            InitializeComponent();
        }

        private void frmPainelJogo_Load(object sender, EventArgs e)
        {
            DefaultValues();
        }

        public void DefaultValues()
        {
            //DEFAULT VALUES

            lblXwins.Text = "0";
            lblOwins.Text = "0";          
            lblDraws.Text = "0";
            lblXdefeats.Text = "0";
            lblOdefeats.Text = "0";
        }

        private void btPos1_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender; //reference for all buttons   
            int buttonIndex = btn.TabIndex;

            if (btn.Text == "" && endGame == false)
            {
                if (shift)
                {
                    btn.Text = "X";
                    game[buttonIndex] = btn.Text;
                    round++;
                    shift = !shift;
                    PlayerTurn(1);
                }
                else
                {
                    btn.Text = "O";
                    game[buttonIndex] = btn.Text;
                    round++;
                    shift = !shift;
                    PlayerTurn(2);
                }
            }
        }

        public void Winner(int WinnerPlayer) // Will check Winner
        {
            endGame = true;

            if (WinnerPlayer == 1)
            {

                xWins++;
                lblXwins.Text = Convert.ToString(xWins);
                oDefeats++;
                lblOdefeats.Text = Convert.ToString(oDefeats);
                MessageBox.Show("Player X Wons!");
                shift = true;
            }
            else
            {
                oWins++;
                lblOwins.Text = Convert.ToString(oWins);
                xDefeats++;
                lblXdefeats.Text = Convert.ToString(xDefeats);
                MessageBox.Show("Player O Wons!");
                shift = false;
            }
        }



        public void PlayerTurn(int CheckPlayer) //method will check who plays
        {
            string symbol = "";

            if (CheckPlayer == 1)
            {
                symbol = "X";
            }
            else
            {
                symbol = "O";
            } //finish who plays

            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (symbol == game[horizontal]) //will check horizontally
                {
                    if (game[horizontal] == game[horizontal + 1] && game[horizontal] == game[horizontal + 2])
                    {
                        Winner(CheckPlayer);
                        return;
                    }
                }
            }   //finish horizontally loop

            //will check vertical
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (symbol == game[vertical]) //will check vertical
                {
                    if (game[vertical] == game[vertical + 3] && game[vertical] == game[vertical + 6])
                    {
                        Winner(CheckPlayer);
                        return;
                    }
                }
            } // finish vertical loop

            //Check Diagonal

            if (game[0] == symbol)
            {
                if (game[0] == game[4] && game[0] == game[8])
                {
                    Winner(CheckPlayer);
                    return;
                }
            }
            if (game[2] == symbol)
            {
                if (game[2] == game[4] && game[2] == game[6])
                {
                    Winner(CheckPlayer);
                    return;
                }
            }

            if (round == 9 && endGame == false) //will check a draw
            {

                MessageBox.Show("Draw");
                endGame = true;
                return;
            }
        }
    }
}
