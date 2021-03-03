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
    public partial class EditWindow : Window
    {
        private TypeQuest type = TypeQuest.None;

        public EditWindow()
        {
            InitializeComponent();
        }


        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindow.Show();
            Close();
        }

        private void trueBtn_Click(object sender, RoutedEventArgs e)
        {
            activeColor(trueBtn, actionBtn) ;
            type = TypeQuest.TrueQuest;
        }

        private void actionBtn_Click(object sender, RoutedEventArgs e)
        {
            activeColor(actionBtn, trueBtn);
            type = TypeQuest.ActionQuest;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (type == TypeQuest.ActionQuest)
            {
                if (!ListsForGame.actionList.Contains(textQuest.Text))
                    ListsForGame.actionList.Add(textQuest.Text);
            }
            else if (type == TypeQuest.TrueQuest)
            {
                if (!ListsForGame.trueList.Contains(textQuest.Text))
                    ListsForGame.trueList.Add(textQuest.Text);
            }
            else if (type == TypeQuest.None)
                MessageBox.Show("Выберете тип задания");

            textQuest.Text = "";
        }

        private void activeColor(Button activeBtn, Button notActiveBtn)
        {
            Brush sourceColor = activeBtn.Background;
            if (sourceColor != Brushes.Violet)
            {
                activeBtn.Background = Brushes.Violet;
                notActiveBtn.Background = sourceColor;
            }
        }
    }
}
