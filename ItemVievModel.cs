using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class ItemVievModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }


    }
    public class ControlViewModel
    {
        public ObservableCollection<ItemVievModel> Items { get; } = new ObservableCollection<ItemVievModel>();
    }
}
