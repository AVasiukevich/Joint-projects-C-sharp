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
        private List<Image> _list_picture;
        private SubTaskViewModel _subTaskVM;

        public SubTaskViewModel SubTaskVM
        {
            get
            {
                if (_subTaskVM == null)
                    _subTaskVM = new SubTaskViewModel();
                return _subTaskVM;
            }
            set
            {
                _subTaskVM = value;
            }
        }     
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

        private RelayCommand _addSubTask;
        public ICommand AddSubTask
        {
            get
            {
                if (_addSubTask == null)
                    _addSubTask = new RelayCommand(ExecuteAddSubTask);
                return _addSubTask;
            }
        }
        private void ExecuteAddSubTask(object obj)
        {
            SubTaskWindow _window = new SubTaskWindow();
            _window.DataContext = SubTaskVM;
            if(_window.ShowDialog() == true)
            {
                CurrentTask.List_subTasks.Add(_subTaskVM.СurrentSubTask);
                _subTaskVM.СurrentSubTask = null;
            }
        }
    }
}
