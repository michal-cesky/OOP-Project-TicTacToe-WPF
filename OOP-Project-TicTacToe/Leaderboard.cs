using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project_TicTacToe
{
    internal class Leaderboard
    {
        private String path = @"Data\Leaderboard.txt";
        private Dictionary<string, int> path1 = new Dictionary<string, int>();
        int currentload;
        public void SavePlayers(String player1, int Player1_wincountsave, String player2, int Player2_wincountsave)
        {
            try
            {
                if (path1.ContainsKey(player1))
                {
                    path1.TryGetValue(player1, out currentload);
                    path1[player1] = currentload + Player1_wincountsave;
                }
                else
                {
                    path1.Add(player1, Player1_wincountsave);
                }
                if (path1.ContainsKey(player2))
                {
                    path1.TryGetValue(player2, out currentload);
                    path1[player1] = currentload + Player1_wincountsave;
                }
                else
                {
                    path1.Add(player2, Player2_wincountsave);
                }
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, int> kvp in path1)
                {
                    sb.AppendLine(string.Format($"{0};{1}", kvp.Key, kvp.Value));
                }

                using (StreamWriter file = new StreamWriter(path))
                    foreach (var entry in path1)
                        file.WriteLine($"{0},{1}", entry.Key, entry.Value);
            }
            catch (System.IO.FileNotFoundException)
            {

                throw new System.IO.FileNotFoundException("File not found");
            }



        }



    }
}
