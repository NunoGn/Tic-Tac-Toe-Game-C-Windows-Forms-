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

        int xWins, xDefeats, oWins, draws, oDefeats, round = 0;
        bool shift = true;
        bool endGame = false;
        string[] game = new string[9];



        public frmPainelJogo()
        {
            InitializeComponent();
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Start new game? ", "Information", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                NewGame();
            }

           
        }

        private void btLeaveGame_Click(object sender, EventArgs e)
        {
             var result = MessageBox.Show("Leave the game? ", "Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }            
        }

        private void frmPainelJogo_Load(object sender, EventArgs e)
        {
            
        }

        private void btReset_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Reset Score and current game? ", "Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DefaultValues();
            }
           
        }

        public void NewGame() // reset the board // array and the numer off rounds but not the score
        {
            //CLEAN BOARD
            btPos1.Text = "";
            btPos2.Text = "";
            btPos3.Text = "";
            btPos4.Text = "";
            btPos5.Text = "";
            btPos6.Text = "";
            btPos7.Text = "";
            btPos8.Text = "";
            btPos9.Text = "";

            //CLEAND ARRAY
            for (int i = 0; i < 9; i++)
            {
                game[i] = "";
            }

            //RESET NUMBER OF ROUNDS
            round = 0;
            endGame = false;
            shift = true;
        }

        public void DefaultValues() //Only for reset entire game
        {
            //DEFAULT VALUES

            lblXwins.Text = "0";
            lblOwins.Text = "0";          
            lblDraws.Text = "0";
            lblXdefeats.Text = "0";
            lblOdefeats.Text = "0";

            NewGame();
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
                draws++;
                lblDraws.Text = Convert.ToString(draws);
                MessageBox.Show("Draw!");
                endGame = true;
                return;
            }
        }
    }
}
