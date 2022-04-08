using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP_Project_TicTacToe
{
    /// <summary>
    /// Interakční logika pro Game3x3.xaml
    /// </summary>
    public partial class Game3x3 : Window
    {
        bool turn = true;                   // true = hráč s X, false = hráč a Y;
        int turn_count = 0;
        static String player1, player2;
        string currentPlayer;
      

        public Game3x3()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)       //po kliknutí vypíše do dlačítka zank
        {
        
            Button b = (Button)sender;
            if (turn)
                b.Content = "X";
            else
                b.Content = "O";

            turn = !turn;                       //pro přepnutí kola na druhho hráče
            b.IsEnabled = false;
            turn_count++;

            CheckWinner();
            //   label2.Focus();
        }
        public static void setPlayerNames(String Player1, String Player2)
        {
           
            player1 = Player1;
            player2 = Player2;
        }

        private void CheckWinner()       //kontrola zda jsou X nebo O 3x vedel sebe
        {
            bool winner = false;

            if ((A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A1.IsEnabled))              //horizontálně
                winner = true;
            else if ((B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B1.IsEnabled))
                winner = true;
            else if ((C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C1.IsEnabled))
                winner = true;

            else if ((A1.Content == B1.Content) && (B1.Content == C1.Content) && (!A1.IsEnabled))         //vertikálně
                winner = true;
            else if ((A2.Content == B2.Content) && (B2.Content == C2.Content) && (!A2.IsEnabled))
                winner = true;
            else if ((A3.Content == B3.Content) && (B3.Content == C3.Content) && (!A3.IsEnabled))
                winner = true;

            else if ((A1.Content == B2.Content) && (B2.Content == C3.Content) && (!A1.IsEnabled))         //diagonálně
                winner = true;
            else if ((A3.Content == B2.Content) && (B2.Content == C1.Content) && (!C1.IsEnabled))
                winner = true;

            if (winner)
            {
                         disableButtons();
                
                String winnername = "";
                if (turn)
                {
                    winnername = currentPlayer;
                    Player2_wincount.Content = (Int32.Parse((string)Player2_wincount.Content) + 1).ToString();
                }
                else
                {
                    winnername = currentPlayer;
                    Player1_wincount.Content = (Int32.Parse((string)Player1_wincount.Content) + 1).ToString();
                }

                MessageBox.Show(winnername + " Wins \nNeeded turns: " + turn_count, "WIN!!!!!!!!!!!");
                restartgameButton();
            } // end if
            else
            {
                if (turn_count == 9)
                {
                    //draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Draw \nReached max turns: " + turn_count, "DRAEW :(");
                    restartgameButton();
                }

            }
        }

         private void disableButtons()           //znemožnění použití tlačítek
         {
            /* try
             {
                foreach (Control c in controls)
                 {
                     Button b = (Button)c;
                     b.IsEnabled = false;
                 }
             }
             catch { }*/

           

            A1.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            C1.IsEnabled = false;
            C2.IsEnabled = false;
            C3.IsEnabled = false;
            //reset_btn.Enabled = true;
            

        }

        private void restartgameButton()
        {
            

            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            C1.IsEnabled = true;
            C2.IsEnabled = true;
            C3.IsEnabled = true;
            turn_count = 0;
            turn = true;

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.IsEnabled)
            {
                if (turn)
                    b.Content = "X";
                else
                    b.Content = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.IsEnabled)
            {
                b.Content = "";
            }
        }

        private void ButtonNewGame(object sender, EventArgs e)
        {

        }


        private void Game3x3_Load(object sender, EventArgs e)
        {
           
        }

        private void PlayersName_Load(object sender, EventArgs e)
        {
            randomnumber();
            textboxPlayer1.Content = player1;
            textboxPlayer2.Content = player2;
        }


        //private void setPlayerDefaultsToolStripMenuItem_Click(object sender, EventArgs e);

        /* private void newGameToolStripMenuItem(object sender, EventArgs e)
         {
             turn = true;
             turn_count = 0;

             foreach (Control c in Controls)
             {
                 try
                 {
                     Button b = (Button)c;
                     b.IsEnabled = true;
                     b.Content = "";
                 } // end try
                 catch { }
             } // end foreach
         }*/

        public void randomnumber()                              //random vybere hráče
        {
            var random = new Random();
            turn = random.Next(2) == 1; 
            if (turn) 
                currentPlayer = player1;
            else
                currentPlayer = player2;

        }

    }
}
