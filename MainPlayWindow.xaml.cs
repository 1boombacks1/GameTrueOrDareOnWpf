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
    public partial class MainPlayWindow : Window
    {
        Random rnd = new Random();
        int countTrueList = ListsForGame.trueList.Count;
        int countActionList = ListsForGame.actionList.Count;
        List<string> selectedTrueQuest = new List<string>();
        List<string> selectedActionQuest = new List<string>();
        PlayWindow eventMaster;
        TypeQuest typeQuest;

        public MainPlayWindow(TypeQuest type, string player, PlayWindow gameMaster)
        {
            eventMaster = gameMaster;
            typeQuest = type;

            InitializeComponent();

            playerNicknameText.Text = player;
            if(type == TypeQuest.ActionQuest)
            {
                string quest = ListsForGame.actionList[rnd.Next(0,countActionList)];
                selectedActionQuest.Add(quest);
                questTextblock.Text = quest;
            }
            else if(type == TypeQuest.TrueQuest)
            {
                string quest = ListsForGame.trueList[rnd.Next(0,countTrueList)];
                selectedTrueQuest.Add(quest);
                questTextblock.Text = quest;
            }
        }

        private void changeQuestBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> exceptActionList = ListsForGame.actionList.Except(selectedActionQuest).ToList();
            List<string> exceptTrueList = ListsForGame.trueList.Except(selectedTrueQuest).ToList();

            if (exceptActionList.Count == 1)
                selectedActionQuest.Clear();
            if (exceptTrueList.Count == 1)
                selectedTrueQuest.Clear();

            if(typeQuest == TypeQuest.ActionQuest)
            {
                string quest = exceptActionList[rnd.Next(0, exceptActionList.Count)];
                selectedActionQuest.Add(quest);
                questTextblock.Text = quest;
            }
            else if (typeQuest == TypeQuest.TrueQuest)
            {
                string quest = exceptTrueList[rnd.Next(0, exceptTrueList.Count)];
                selectedTrueQuest.Add(quest);
                questTextblock.Text = quest;
            }
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            eventMaster.Show();
            Close();
        }
    }
}
