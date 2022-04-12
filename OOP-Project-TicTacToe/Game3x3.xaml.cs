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
        bool turn;   // true = hráč s X, false = hráč a Y;
        bool turnplayer;
        int turn_count = 0;
        static String player1 = null;
        static String player2 = null;

        static String currentPlayer;
        private Lastgameplayer save = new Lastgameplayer();


        public Game3x3()
        {
            InitializeComponent();
            randomFirstplayer();
            save.Lastgameplayersave(player1, player2);
        }

        public static void setPlayerNames(String Player1, String Player2)
        {
            player1 = Player1;
            player2 = Player2;
        }

        private void PlayersName_Load(object sender, EventArgs e)
        {  
                textboxPlayer1.Content = player1;
                textboxPlayer2.Content = player2;
        }

        public void setPlayersNamesLastgameplayer()
        {
            (String p1, String p2) = Lastgameplayer.Lastgameplayerload();
            player1 = p1;
            player2 = p2;
        }

        public void labelWhoisonturn_Load(object sender, EventArgs e)
        {
            textboxWhoisonturn.Content = currentPlayer;
        }

        public void randomFirstplayer()                              //random vybere hráče
        {
            var random = new Random();
            turnplayer = random.Next(2) == 1;
            if (turnplayer)
            {
                textboxWhoisonturn.Content = player2;
                currentPlayer = player2;
            }
            else
            {
                textboxWhoisonturn.Content = player1;
                currentPlayer = player1;
            }
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
                if (turnplayer)
                {
                    winnername = player2;
                    Player2_wincount.Content = (Int32.Parse((string)Player2_wincount.Content) + 1).ToString();
                }
                else
                {
                    winnername = player1;
                    Player1_wincount.Content = (Int32.Parse((string)Player1_wincount.Content) + 1).ToString();
                }

                MessageBox.Show(winnername + " Wins \nNeeded turns: " + turn_count, "WIN!!!!!!!!!!!");
                restartgameButton();
            } // end if
            else
            {
                if (turn_count == 9)
                {
                    //draw_count.Text = (Int32.Parse((string)draw_count.Text) + 1).ToString();
                    MessageBox.Show("Draw \nReached max turns: " + turn_count, "DRAEW :(");
                    restartgameButton();
                }

            }
        }

      /*  private void setPlayersNameDefault(object sender, EventArgs e)
        {
            player1 = "Player1";
            player2 = "Player2";
            textboxPlayer1.Content = player1;
            textboxPlayer2.Content = player2;
        }*/

        private void button_click(object sender, EventArgs e)       //po kliknutí vypíše do dlačítka zank
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Content = "X";
            }
            else
            {
                b.Content = "O";
            }
            turn = !turn;                       //pro přepnutí kola na druhho hráče
            b.IsEnabled = false;
            turn_count++;

            CheckWinner();
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
            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C1.Content = "";
            C2.Content = "";
            C3.Content = "";
            randomFirstplayer();
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

    }
}
