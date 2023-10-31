using BoardLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeGui
{
    public partial class Form1 : Form
    {

        Board game = new Board();
        Button[] buttons = new Button[9];
        private EventHandler handleButtonclick;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            //add a common click to each button
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += HandleButtonclick;
                buttons[i].Tag = i;
            }
            
        }

        private void HandleButtonclick(object sender, EventArgs e)
        {

            Button clickedButton = (Button) sender;
            //MessageBox.Show("button "+ clickedButton.Tag + " was clicked.");

            int gameSquareNumber = (int)clickedButton.Tag;

            game.Grid[gameSquareNumber] = 1;

            UpdateBoard();

            if (game.isBoardFull() == true)
            {
                MessageBox.Show("Its a Tie, Unlucky");
                disableAllButtons();
            } else if (game.checkForWinner() == 1)
            {
                MessageBox.Show("You Win, Congratulations!!");
                disableAllButtons();
            }
         else
        {
            //Computer 
            computerChoose();
        }   

        }

        private void disableAllButtons()
        {
           foreach (var item in buttons)
            {
                item.Enabled = true;
            }
        }

        private void computerChoose()
        {
            // computer picks a random number. Update game.Grid for choice
            int computerTurn = rand.Next(9);
            //don't allow the computer to choose an already occupied square
            while (computerTurn == -1 || game.Grid[computerTurn] != 0)
            {
                computerTurn = rand.Next(9);

                Console.WriteLine("Computer Chooses " + computerTurn);
            }
            game.Grid[computerTurn] = 2;
            UpdateBoard();

            //Check for winners
            //Check to see if the board is full.
            if (game.isBoardFull() == true)
            {
                MessageBox.Show("The Board is full.");
                disableAllButtons();
            }
             else if (game.checkForWinner() == 2)
            {
                MessageBox.Show("The Computer Has Won, Better Luck next time");
                disableAllButtons();
            }
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            //Assign X or O to the text of each button

            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                    buttons[i].Enabled = true;
                    buttons[i].ForeColor = Color.Black; 
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].Enabled = false;
                    buttons[i].ForeColor = Color.Green;
                } 
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false;
                    buttons[i].ForeColor = Color.Red;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            EnabledAllButtons();
        }

        private void EnabledAllButtons()
        {
            foreach (var items in buttons)
            {
                items.Enabled = true;
            }

            UpdateBoard();

        }
    }
}