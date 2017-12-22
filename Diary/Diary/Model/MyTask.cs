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
    public class MyTask
    {
        private string name;
        private DateTime? dateEnd;
        private DateTime? dateStart;
        private byte[] picture;
        private ObservableCollection<SubTask> list_subTasks;

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
            }
        }       
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public DateTime? DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }
        public DateTime? DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }
        public MyTask()
        {}
        //public MyTask(string name) : this(name, null, null)
        //{}
        //public MyTask(string name, DateTime date) : this(name, date, null)
        //{}
        //public MyTask(string name, DateTime? dateStart, DateTime? dateEnd)
        //{
        //    this.name = name;
        //    this.dateStart = dateStart;
        //    this.dateEnd = dateEnd;
        //}
        public override string ToString()
        {
            return String.Format($"{name}: {dateStart} - {dateEnd}");
        }
    }
}
