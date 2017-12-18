using Diary.Infrastructure;
using Diary.Model;
using Diary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
