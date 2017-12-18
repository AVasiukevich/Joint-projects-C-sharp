using Diary.Infrastructure;
using Diary.Model;
using Diary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Diary.ViewModel
{
    class AddTaskViewModel : ViewModelBase
    {
        private MyTask _currentTask;
        public MyTask CurrentTask
        {
            get
            {
                if (_currentTask == null)
                    _currentTask = new MyTask();
                return _currentTask;
            }
            set
            {
                _currentTask = value;
                OnPropertyChanged();
            }
        }

        private List<Image> _list_picture;
        public List<Image> List_Picture
        {
            get
            {
                if (_list_picture == null)
                    _list_picture = new List<Image>() { new Image() { Source = new BitmapImage(new Uri("../Image/dancer_64.png", UriKind.Relative)) },
                                                        new Image() { Source = new BitmapImage(new Uri("../Image/dumbbell_64.png", UriKind.Relative)) },
                                                        new Image() { Source = new BitmapImage(new Uri("../Image/english_64.png", UriKind.Relative)) },
                                                        new Image() { Source = new BitmapImage(new Uri("../Image/sea_64.png", UriKind.Relative)) },
                                                        new Image() { Source = new BitmapImage(new Uri("../Image/card_64.png", UriKind.Relative)) }};
                return _list_picture;
            }
            set
            {
                _list_picture = value;
            }
        }
        

        private RelayCommand _addTask_Ok;
        public ICommand AddTask_Ok
        {
            get
            {
                if (_addTask_Ok == null)
                    _addTask_Ok = new RelayCommand(ExecuteAddTaskOk, CanExecuteAddTaskOk);
                return _addTask_Ok;
            }
        }
        private bool CanExecuteAddTaskOk(object obj)
        {
            if (String.IsNullOrEmpty(_currentTask.Name) || _currentTask.DateStart == null || _currentTask.DateEnd == null)
                return false;
            return true;
        }
        private void ExecuteAddTaskOk(object obj)
        {
            AddTaskWindow taskWindow = obj as AddTaskWindow;
            if (taskWindow != null)
            {
                taskWindow.DialogResult = true;
                taskWindow.Close();
            }
        }
    }
}
