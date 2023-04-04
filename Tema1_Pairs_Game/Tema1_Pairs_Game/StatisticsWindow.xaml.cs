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

namespace Tema1_Pairs_Game
{
    public partial class StatisticsWindow : Window
    {
        string currentUser;
        public StatisticsWindow(string user)
        {
            InitializeComponent();

            currentUser = user;
        }

        private void GetMyData(object sender, RoutedEventArgs e)
        {
            myData.Text = "";
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string username = line.Split(' ')[0];
                if (username == currentUser)
                {
                    int playedGames = int.Parse(line.Split(' ')[2]);
                    int wonGames = int.Parse(line.Split(' ')[3]);
                    myData.Text = "User: " + username + "\nPlayed games: " + playedGames + "\nWon games: " + wonGames;
                    break;
                }
            }
            myData.Visibility = Visibility.Visible;
        }

        private void GetAllData(object sender, RoutedEventArgs e)
        {
            allData.Text = "";
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string username = line.Split(' ')[0];
                string playedGames = line.Split(' ')[2];
                string wonGames = line.Split(' ')[3];
                allData.Text += "\nUser: " + username + "\nPlayed games: " + playedGames + "\nWon games: " + wonGames + "\n-------------------\n";
            }
            allData.Visibility = Visibility.Visible;
        }
    }
}
