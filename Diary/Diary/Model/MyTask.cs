using Diary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Diary.Model
{
    [Serializable]
    public class MyTask : ViewModelBase
    {
        private string name;
        private DateTime? dateEnd;
        private DateTime? dateStart;
        private byte[] picture;
        private ObservableCollection<SubTask> list_subTasks;
        private decimal? _percentOfCompletion;

        public decimal? PercentOfCompletion
        {
            get
            {
                if (_percentOfCompletion == null && List_subTasks.Count != 0)
                    RefreshOfCompletion();
                return _percentOfCompletion;
            }
            set
            {
                _percentOfCompletion = value;
                OnPropertyChanged();
            }

        }
        public ObservableCollection<SubTask> List_subTasks
        {
            get
            {
                if (list_subTasks == null)
                    list_subTasks = new ObservableCollection<SubTask>();
                return list_subTasks;
            }
            set
            {
                list_subTasks = value;
                //OnPropertyChanged();
            }
        }
        public byte[] Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
                OnPropertyChanged();
            }
        }       
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public DateTime? DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; OnPropertyChanged(); }
        }
        public DateTime? DateStart
        {
            get { return dateStart; }
            set { dateStart = value; OnPropertyChanged(); }
        }
        public MyTask()
        {}

        public override string ToString()
        {
            return String.Format($"{name}: {dateStart} - {dateEnd}");
        }
        public void RefreshOfCompletion()
        {
            PercentOfCompletion = list_subTasks.Where(i => i.IsReady).Count() / (decimal)list_subTasks.Count();
        }
    }
}
