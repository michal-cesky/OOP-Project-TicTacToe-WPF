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
        private Dictionary<string, int> names = new Dictionary<string, int>();
        int currentload;

        private lboard lb = new lboard();
        public void SavePlayers(String player1, int Player1_wincountsave, String player2, int Player2_wincountsave)
        {
            try
            {
                foreach (var line in File.ReadLines(path))
                {
                    string[] val = line.Split(',');
                    names.Add(val[0], int.Parse(val[1]));
                }

                if (names.ContainsKey(player1))
                {
                    names.TryGetValue(player1, out currentload);
                    names[player1] = currentload + Player1_wincountsave;
                }
                else
                {
                    names.Add(player1, Player1_wincountsave);
                }
                if (names.ContainsKey(player2))
                {
                    names.TryGetValue(player2, out currentload);
                    names[player2] = currentload + Player1_wincountsave;
                }
                else
                {
                    names.Add(player2, Player2_wincountsave);
                }
                StringBuilder sb = new StringBuilder();
                using (StreamWriter file = new StreamWriter(path))
                    foreach (var entry in names)
                        file.WriteLine("{0},{1}", entry.Key, entry.Value);
            }
            catch (System.IO.FileNotFoundException)
            {

                throw new System.IO.FileNotFoundException("File not found");
            }



        }

        public void loadleaderboard()
        {
            //var lines = names.Select(kv => kv.Key + ": " + kv.Value.ToString());
          

            lb.labelLeaderboard.Content = File.ReadAllText(path);

        }
        
    }

}

