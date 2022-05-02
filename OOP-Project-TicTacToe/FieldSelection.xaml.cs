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
    /// Interakční logika pro FieldSelection.xaml
    /// </summary>
    public partial class FieldSelection : Window
    {

        public FieldSelection()
        {
            InitializeComponent();
        }

        private void ButtonBack(object sender, EventArgs e)
        {
            MainWindow f1 = new MainWindow();
            this.Hide();
            f1.ShowDialog();
            this.Close();
        }

        private void Button3x3(object sender, EventArgs e)
        {
            Game3x3 field3x3 = new Game3x3();
            this.Hide();
            field3x3.ShowDialog();
            this.Close();
        }

        private void Button4x4(object sender, RoutedEventArgs e)
        {
            Game4x4 field4x4 = new Game4x4();
            this.Hide();
            field4x4.ShowDialog();
            this.Close();
        }
    }
}
