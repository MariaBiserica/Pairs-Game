using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.LinkLabel;

namespace Tema1_Pairs_Game
{
    public partial class GameWindow : Window
    {
        List<int> usedIndexes = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15, 16, 16, 17, 17, 18, 18, 19, 19, 20, 20 };
        List<List<string>> cards = new List<List<string>>();
        List<string> usedCards = new List<string>();
        Button button1 = new Button();
        Button button2 = new Button();
        string picA = "";
        string picB = "";

        System.Timers.Timer timer;
        static int counter = 0;

        int r, c;
        int level = 0;
        bool gameOver = false;
        bool openSavedGame;

        string currentUser;

        public GameWindow(int rows, int cols, string user, bool openSavedGame)
        {
            InitializeComponent();

            r = rows;
            c = cols;
            currentUser = user;
            this.openSavedGame = openSavedGame;
            this.DataContext = new Card(rows, cols);

            if (openSavedGame)
            {
                string file = @"../../game.txt";
                string[] lines = System.IO.File.ReadAllLines(file);
                int l = 0;
                
                foreach(string line in lines)
                {
                    if (l == 0)
                    {
                        currentUser = line.Split(' ')[0].ToString();
                    }
                    else if (l == 1)
                    {
                        r = int.Parse(line.Split(' ')[0]);
                        c = int.Parse(line.Split(' ')[1]);
                    }
                    else if (l == 2)
                    {
                        List<string> configuration = line.Split(' ').ToList();
                        usedCards = configuration;
                    }
                    else if (l == 3)
                    {
                        level = int.Parse(line.Split(' ')[0].ToString());
                    }
                    else if (l == 4)
                    {
                        counter = int.Parse(line.Split(' ')[0].ToString());
                    }
                    l++;
                }
            }
            else
            {
                MessageBox.Show("You have 2 minutes!", "New Game");
            }

            UpdateUserPicture();
            AssignImages(r, c);
            DisableUsedCards();

            StartTimer();
        }

        private void AssignImages(int rows, int cols)
        {
            //get images sample
            List<int> images = usedIndexes.GetRange(0, rows * cols);

            for (int i = 0; i < rows; i++)
            {
                List<string> card = new List<string>();

                for (int j = 0; j < cols; j++)
                {
                    var random = new Random();
                    int index = random.Next(images.Count);
                    card.Add("card" + images[index] + ".jpg");
                    images.Remove(images[index]);
                }
                cards.Add(card);
            }
        }

        private void CardPicked(object sender, RoutedEventArgs e)
        {
            if (gameOver)
            {
                GameWindow restartGame = new GameWindow(r, c, currentUser, false);
                this.Close();
                restartGame.Show();
            }
            else
            {
                //change button image source to the corresponding item from cards list
                string row = ((string)((Button)sender).Tag).Substring(0, 1);
                string col = ((string)((Button)sender).Tag).Substring(1, ((string)((Button)sender).Tag).Length - 1);
                string cardIndex = cards[Int32.Parse(row)][Int32.Parse(col)];

                Image pic = new Image();
                pic.Source = new BitmapImage(new Uri(@"/cards/" + cardIndex, UriKind.Relative));
                ((Button)sender).Content = pic;

                if (picA == "")
                {
                    picA = (string)((Button)sender).Tag;
                    button1 = sender as Button;
                }
                else if (picB == "")
                {
                    picB = (string)((Button)sender).Tag;
                    button2 = sender as Button;
                    CheckPictures(picA, picB);

                    //emtpy choices
                    picA = "";
                    picB = "";
                    button1 = new Button();
                    button2 = new Button();
                }
            }
            
        }

        private void CheckPictures(string picA, string picB)
        {
            char row1 = picA.First();
            char col1 = picA.Last();
            string card1 = cards[row1 - '0'][col1 - '0'];

            char row2 = picB.First();
            char col2 = picB.Last();
            string card2 = cards[row2 - '0'][col2 - '0'];

            if (card1 == card2)
                level++;
            else
                level = 0;

            levelLabel.Content = "Level: " + level;

            if (level == 0)
            {
                MessageBox.Show("Mismatched pictures!");
                ChangeButtonPictures();
            }
            else
            {
                MessageBox.Show("Matched pictures!");
                usedCards.Add(button1.Tag.ToString());
                usedCards.Add(button2.Tag.ToString());
                button1.Visibility = Visibility.Hidden;
                button2.Visibility = Visibility.Hidden;
                button1.IsEnabled = false;
                button2.IsEnabled = false;
            }

            if (level == 3)
            {
                MessageBox.Show("Congratulations, You Won!");
                UpdateUserData(1);
                this.Close();
            }
        }
        
        private void ChangeButtonPictures()
        {
            Image pic1 = new Image();
            pic1.Source = new BitmapImage(new Uri(@"/cards/card0.jpg", UriKind.Relative));
            button1.Content = pic1;

            Image pic2 = new Image();
            pic2.Source = new BitmapImage(new Uri(@"/cards/card0.jpg", UriKind.Relative));
            button2.Content = pic2;
        }

        private void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; //1s
            timer.Elapsed += OnTimerEvent;
            timer.Start();
        }

        private void OnTimerEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter++;
            timeLabel.Dispatcher.Invoke(() =>
            {
                timeLabel.Content = "Time Passed: " + counter + " seconds";
            });
            if(counter == 120 && level != 3)
            {
                timer.Stop();
                MessageBox.Show("Time's Up, You Lost!");
                UpdateUserData(0);
                counter = 0;
                level = 0;
                gameOver = true;
            }
        }

        private void UpdateUserPicture()
        {
            int avatarIndex = 0;
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                string username = line.Split(' ')[0];
                if (username == currentUser)
                {
                    avatarIndex = int.Parse(line.Split(' ')[1]);
                    break;
                }
            }
            avatarHolder.Source = new BitmapImage(new Uri(@"/avatarImages/avatar" + avatarIndex + ".jpg", UriKind.Relative));
        }

        private void UpdateUserData(int won)
        {
            string file = @"../../username.txt";
            string[] lines = System.IO.File.ReadAllLines(file);
            string copyFile = "";
            foreach (string line in lines)
            {
                string username = line.Split(' ')[0];

                if (username == currentUser)
                {
                    int picIndex = int.Parse(line.Split(' ')[1]);
                    int playedGames = int.Parse(line.Split(' ')[2]);
                    int wonGames = int.Parse(line.Split(' ')[3]);
                    string newLine = username + " " + picIndex + " " + (playedGames + 1) + " " + (wonGames + won);
                    copyFile += newLine + Environment.NewLine;
                }
                else
                {
                    copyFile += line + Environment.NewLine;
                }
            }
            System.IO.File.WriteAllText(file, copyFile);
        }

        private void SaveGame(object sender, RoutedEventArgs e)
        {
            //save game configuration in file
            string file = @"../../game.txt";

            System.IO.File.AppendAllText(file, currentUser);
            System.IO.File.AppendAllText(file, Environment.NewLine + r + " " + c + Environment.NewLine);
            foreach (string item in usedCards)
            {
                System.IO.File.AppendAllText(file, item + " ");
            }
            System.IO.File.AppendAllText(file, Environment.NewLine + level);
            System.IO.File.AppendAllText(file, Environment.NewLine + counter);

            MessageBox.Show("Game Saved!");
            this.Close();
        }

        private void DisableUsedCards()
        {
            /*List<Button> buttons = grid.Children.OfType<Button>().ToList();
            foreach (string item in usedCards)
            {
                foreach (Button button in buttons)
                {
                    if (button != null)
                    {
                        if(button.Tag.ToString() == item)
                        {
                            button.Visibility = Visibility.Hidden;
                            button.IsEnabled = false;
                        }
                    }
                }
            }*/
        }
    }
}
