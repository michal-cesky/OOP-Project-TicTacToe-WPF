using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_TicTacToe
{
    internal class Lastgameplayer
    {
        private String path = @"Data\Lastgameplayer.txt";
        public void Lastgameplayersave(String player1, String player2)
        {
            try
            {
                File.WriteAllText(path, $"{player1};{player2}");

            }
            catch (System.IO.FileNotFoundException)
            {

                throw new System.IO.FileNotFoundException("File not found");
            }

        }
    }
}
