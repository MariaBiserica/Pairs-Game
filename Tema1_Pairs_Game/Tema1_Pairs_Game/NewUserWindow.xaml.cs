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
    public partial class NewUserWindow : Window
    {
        int avatarIndex = 1;
        public NewUserWindow()
        {
            InitializeComponent();
        }

        private void prevAvatar_Click(object sender, RoutedEventArgs e)
        {
            avatarIndex--;

            if (avatarIndex < 1)
                avatarIndex = 17;

            avatarHolder.Source = new BitmapImage(new Uri(@"/avatarImages/avatar" + avatarIndex + ".jpg", UriKind.Relative));
        }

        private void nextAvatar_Click(object sender, RoutedEventArgs e)
        {
            avatarIndex++;

            if (avatarIndex > 17)
                avatarIndex = 1;

            avatarHolder.Source = new BitmapImage(new Uri(@"/avatarImages/avatar" + avatarIndex + ".jpg", UriKind.Relative));
        }

        private void addNewUser_Click(object sender, RoutedEventArgs e)
        {
            if(newUsernameTextBox.Text == string.Empty){
                MessageBox.Show("Please enter some text!", "Error.No username entered");
                return;
            }
                
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string username = line.Split(' ')[0];
                if (username == newUsernameTextBox.Text)
                {
                    MessageBox.Show("Username already exists!", "Error.Duplicate username");
                    return;
                }
            }
 
            //add the new user in the txt file
            //username + picindex + played games + won games
            System.IO.File.AppendAllText(file, Environment.NewLine + newUsernameTextBox.Text + " " + avatarIndex + " " + 0 + " " + 0);
            MainWindow backToLogin = new MainWindow();
            this.Close();
            backToLogin.Show();
        }
    }
}
