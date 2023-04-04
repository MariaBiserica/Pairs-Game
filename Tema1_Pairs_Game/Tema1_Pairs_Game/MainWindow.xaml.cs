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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tema1_Pairs_Game
{
    public partial class MainWindow : Window
    {
        int avatarIndex = 1;
        public MainWindow()
        {
            InitializeComponent();
            
            //initializare list box
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines){
                loginNameList.Items.Add(line.Split(' ')[0]);
            }

            //delete user e inactiv pana cand selectam un user din list box
            deleteUserButton.IsEnabled = false;
            playButton.IsEnabled = false;
        }

        private void LoginNameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string username = line.Split(' ')[0];
                if (username == loginNameList.SelectedItem.ToString())
                {
                    avatarIndex = int.Parse(line.Split(' ')[1]);
                    break;
                }
            }
            avatarHolder.Source = new BitmapImage(new Uri(@"/avatarImages/avatar" + avatarIndex + ".jpg", UriKind.Relative));

            deleteUserButton.IsEnabled = true;
            playButton.IsEnabled = true;
        }

        private void OpenNewUserWindow(object sender, RoutedEventArgs e)
        {
            NewUserWindow newUserWindow = new NewUserWindow();
            this.Close();
            newUserWindow.Show();
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            string newFile = "";
            foreach (string line in lines)
                if (!line.Contains(loginNameList.SelectedItem.ToString()))
                    newFile += line + Environment.NewLine;
            System.IO.File.WriteAllText(file, newFile);

            MainWindow reloadLogin = new MainWindow();
            this.Close();
            reloadLogin.Show();
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            GameMenuWindow gameMenu = new GameMenuWindow(this, loginNameList.SelectedItem.ToString());
            this.Visibility = Visibility.Hidden;
            gameMenu.Show();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
