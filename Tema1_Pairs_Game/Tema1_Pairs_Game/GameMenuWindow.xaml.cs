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
using System.Xml;

namespace Tema1_Pairs_Game
{
    public partial class GameMenuWindow : Window
    {
        MainWindow backToLogin;
        string currentUser;
        public GameMenuWindow(MainWindow login, string user)
        {
            InitializeComponent();
            this.backToLogin = login;
            currentUser = user;
        }

        private void StandardGame(object sender, RoutedEventArgs e)
        {
            GameWindow newGame = new GameWindow(4, 6, currentUser, false);
            this.Close();
            newGame.Show();
        }

        private void CustomGame(object sender, RoutedEventArgs e)
        {
            if (rowsTextBox.Text == "" || colsTextBox.Text == "")
                MessageBox.Show("Please enter the number of rows and columns!");
            else if (int.Parse(rowsTextBox.Text) * int.Parse(colsTextBox.Text) % 2 != 0)
                MessageBox.Show("The number of rows and columns must be even!");
            else if (int.Parse(rowsTextBox.Text) * int.Parse(colsTextBox.Text) < 6)
                MessageBox.Show("Must have at least 6 cards!");
            else if (int.Parse(rowsTextBox.Text) * int.Parse(colsTextBox.Text) > 40)
                MessageBox.Show("Board is too big!");
            else
            {
                GameWindow newGame = new GameWindow(int.Parse(rowsTextBox.Text), int.Parse(colsTextBox.Text), currentUser, false);
                this.Close();
                newGame.Show();
            }
        }

        private void OpenGame(object sender, RoutedEventArgs e)
        {
            GameWindow newGame = new GameWindow(0, 0, currentUser, true);
            this.Close();
            newGame.Show();
        }

        private void GetStatistics(object sender, RoutedEventArgs e)
        {
            StatisticsWindow stats = new StatisticsWindow(currentUser);
            stats.Show();
        }

        private void Help(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("For more info ask: Biserica Maria \nGroup: 10LF211 \nSpecialization: Informatica", "About");
            return;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            backToLogin.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
