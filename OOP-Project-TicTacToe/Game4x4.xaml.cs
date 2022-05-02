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
    /// Interakční logika pro Game4x4.xaml
    /// </summary>
    public partial class Game4x4 : Window
    {
        bool turn = true;   //      = true start always with X
        bool turnplayer;
        int turn_count = 0;
        static String player1 = null;
        static String player2 = null;
        int Player1_wincountsave = 0;
        int Player2_wincountsave = 0;

        static String currentPlayer;
        //private Lastgameplayer save = new Lastgameplayer();

        private Leaderboard leaderboard = new Leaderboard();

        public Game4x4()
        {
            InitializeComponent();
            randomFirstplayer();
            var random = new Random();
            turnplayer = random.Next(2) == 1;
        }

        public static void setPlayerNames(String Player1, String Player2)
        {
            if (string.IsNullOrEmpty(Player1) || string.IsNullOrEmpty(Player2))         //set default names
            {
                player1 = "Player1";
                player2 = "Player2";
            }
            else
            {
                player1 = Player1;
                player2 = Player2;
            }

        }

        private void PlayersName_Load(object sender, EventArgs e)
        {
            textboxPlayer1.Content = player1;
            textboxPlayer2.Content = player2;
        }

        public void loadPlayersNamesLastgameplayer()
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
            if (!turnplayer)
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

            if ((Z0.Content == Z1.Content) && (Z1.Content == Z2.Content) && (Z2.Content == Z3.Content) && (!Z0.IsEnabled))
                winner = true;
            else if ((A0.Content == A1.Content) && (A1.Content == A2.Content) && (A2.Content == A3.Content) && (!A0.IsEnabled))              //horizontálně
                winner = true;
            else if ((B0.Content == B1.Content) && (B1.Content == B2.Content) && (B2.Content == B3.Content) && (!B0.IsEnabled))
                winner = true;
            else if ((C0.Content == C1.Content) && (C1.Content == C2.Content) && (C2.Content == C3.Content) && (!C0.IsEnabled))
                winner = true;

            else if ((Z0.Content == A0.Content) && (A0.Content == B0.Content) && (B0.Content == C0.Content) && (!Z0.IsEnabled))
                winner = true;
            else if ((Z1.Content == A1.Content) && (A1.Content == B1.Content) && (B1.Content == C1.Content) && (!Z1.IsEnabled))         //vertikálně
                winner = true;
            else if ((Z2.Content == A2.Content) && (A2.Content == B2.Content) && (B2.Content == C2.Content) && (!Z2.IsEnabled))
                winner = true;
            else if ((Z3.Content == A3.Content) && (A3.Content == B3.Content) && (B3.Content == C3.Content) && (!Z3.IsEnabled))
                winner = true;

            else if ((Z0.Content == A1.Content) && (A1.Content == B2.Content) && (B2.Content == C3.Content) && (!Z0.IsEnabled))         //diagonálně
                winner = true;
            else if ((Z3.Content == A2.Content) && (A2.Content == B1.Content) && (B1.Content == C0.Content) && (!C0.IsEnabled))
                winner = true;

            if (winner)
            {
                disableButtons();
                String winnername = "";
                if (turnplayer)
                {
                    winnername = player2;
                    Player2_wincount.Content = (Int32.Parse((string)Player2_wincount.Content) + 1).ToString();
                    Player2_wincountsave = Player2_wincountsave + 1;
                }
                else
                {
                    winnername = player1;
                    Player1_wincount.Content = (Int32.Parse((string)Player1_wincount.Content) + 1).ToString();
                    Player1_wincountsave = Player1_wincountsave + 1;
                }

                MessageBox.Show(winnername + " Wins \nNeeded turns: " + turn_count, "WIN!!!!!!!!!!!");
                restartgameButton();
            } // end if
            else
            {
                if (turn_count == 16)
                {
                    //draw_count.Text = (Int32.Parse((string)draw_count.Text) + 1).ToString();
                    MessageBox.Show("Draw \nReached max turns: " + turn_count, "DRAEW :(");
                    restartgameButton();
                }

            }
        }

        private void button_click(object sender, EventArgs e)       //po kliknutí vypíše do dlačítka zank
        {
            Button b = (Button)sender;
            if (turnplayer)         ///
            {
                b.Content = "X";
            }
            else
            {
                b.Content = "O";
            }
            turnplayer = !turnplayer;      ///////////                 //pro přepnutí kola na druhho hráče
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
            Z0.IsEnabled = false;
            Z1.IsEnabled = false;
            Z2.IsEnabled = false;
            Z3.IsEnabled = false;
            A0.IsEnabled = false;
            A1.IsEnabled = false;
            A2.IsEnabled = false;
            A3.IsEnabled = false;
            B0.IsEnabled = false;
            B1.IsEnabled = false;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            C0.IsEnabled = false;
            C1.IsEnabled = false;
            C2.IsEnabled = false;
            C3.IsEnabled = false;
            //reset_btn.Enabled = true;


        }

        private void restartgameButton()
        {
            Z0.IsEnabled = true;
            Z1.IsEnabled = true;
            Z2.IsEnabled = true;
            Z3.IsEnabled = true;
            A0.IsEnabled = true;
            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            B0.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            C0.IsEnabled = true;
            C1.IsEnabled = true;
            C2.IsEnabled = true;
            C3.IsEnabled = true;
            turn_count = 0;
            //       turnplayer = true;            ///////////
            Z0.Content = "";
            Z1.Content = "";
            Z2.Content = "";
            Z3.Content = "";
            A0.Content = "";
            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B0.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C0.Content = "";
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
                if (turnplayer)         /////////////////
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            leaderboard.SavePlayers(player1, Player1_wincountsave, player2, Player2_wincountsave);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow tabNewGame = new MainWindow();
            this.Hide();
            tabNewGame.ShowDialog();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
