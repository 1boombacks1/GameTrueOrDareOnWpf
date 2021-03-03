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
    public partial class SettingsWindow : Window
    {
        byte countPlayers = 1;
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = new ControlViewModel();
            ((ControlViewModel)DataContext).Items.Add(new ItemVievModel());
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            Close();
        }

        private void addPlayerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (countPlayers < 10)
            {
                ((ControlViewModel)DataContext).Items.Add(new ItemVievModel());
                countPlayers++;
            }
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(ItemVievModel el in ((ControlViewModel)DataContext).Items)
            {
                ListsForGame.playersList.Add(el.Text);
            }
            if (countPlayers != 0)
            {
                PlayWindow playWindow = new PlayWindow(rndChecked.IsChecked.Value);
                playWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                playWindow.Show();
                Close();
            }
            else if(countPlayers == 0)
            {
                MessageBox.Show("Добавьте хотя бы одного игрока!");
            }
        }

        private void removePlayer_Click(object sender, RoutedEventArgs e)
        {
            ItemVievModel el = (ItemVievModel)((Button)sender).DataContext;
            ((ControlViewModel)DataContext).Items.Remove(el);
            countPlayers--;
        }
    }
}
