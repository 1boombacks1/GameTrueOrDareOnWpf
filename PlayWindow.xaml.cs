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


namespace CourseWork
{
    public partial class PlayWindow : Window
    {
        Random rnd = new Random();
        int maxPlayers = ListsForGame.playersList.Count;
        byte currentPlayer = 0;
        string player;

        TypeQuest type;
        bool isRndPlayer;

        public PlayWindow(bool isRndPlayer)
        {
            this.isRndPlayer = isRndPlayer;

            InitializeComponent();

            choicePlayer();

        }

        private void trueBtn_Click(object sender, RoutedEventArgs e)
        {
            type = TypeQuest.TrueQuest;
            startGame(type);
        }

        private void actionBtn_Click(object sender, RoutedEventArgs e)
        {
            type = TypeQuest.ActionQuest;
            startGame(type);
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            ListsForGame.playersList.Clear();

            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            Close();
        }

        private void startGame(TypeQuest typeQuest)
        {
            MainPlayWindow mainPlayWindow = new MainPlayWindow(typeQuest, player, this);
            mainPlayWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainPlayWindow.Show();
            Hide();

            choicePlayer();
        }
        private void choicePlayer()
        {
            if (isRndPlayer)
                player = ListsForGame.playersList[rnd.Next(0, maxPlayers)];
            else
            {
                player = ListsForGame.playersList[currentPlayer++];
                if (currentPlayer == maxPlayers)
                    currentPlayer = 0;
            }
            playerNicknameText.Text = player;
        }
    }
}
