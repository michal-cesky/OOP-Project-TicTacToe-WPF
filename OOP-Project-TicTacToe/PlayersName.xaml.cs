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
    /// Interakční logika pro PlayersName.xaml
    /// </summary>
    public partial class PlayersName : Window
    {
        public PlayersName()
        {
            InitializeComponent();
        }

        private void buttonFieldSelection(object sender, EventArgs e)   //pro uložení jemn a oteření okna výběr pole
        {
            FieldSelection tabFieldSelection = new FieldSelection();
            this.Hide();
            Game3x3.setPlayerNames(textboxPlayer1.Text, textboxPlayer2.Text);
            tabFieldSelection.ShowDialog();
            this.Close();
        }

        private void ButtonBack(object sender, EventArgs e)         //vrácení do hlavní nabýdky
        {
            MainWindow tabNewGame = new MainWindow();
            this.Hide();
            tabNewGame.ShowDialog();
            this.Close();
        }

        private void textboxNamePlayer1(object sender, EventArgs e)
        {

        }

    }
}
