using Diary.Infrastructure;
using Diary.Model;
using Diary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diary.ViewModel
{
    class SubTaskViewModel : ViewModelBase
    {
        private SubTask _currentSubTask;
        public SubTask СurrentSubTask
        {
            get
            {
                if (_currentSubTask == null)
                    _currentSubTask = new SubTask();
                return _currentSubTask;
            }
            set
            {
                _currentSubTask = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addSubTask_Ok;
        public ICommand AddSubTask_Ok
        {
            get
            {
                if (_addSubTask_Ok == null)
                    _addSubTask_Ok = new RelayCommand(ExecuteAddSubTaskOk, CanExecuteAddSubTaskOk);
                return _addSubTask_Ok;
            }
        }
        private bool CanExecuteAddSubTaskOk(object obj)
        {
            if (String.IsNullOrEmpty(_currentSubTask.Description))
                return false;
            return true;
        }
        private void ExecuteAddSubTaskOk(object obj)
        {
            SubTaskWindow _window = obj as SubTaskWindow;
            if (_window != null)
            {
                _window.DialogResult = true;
                _window.Close();
            }
        }
    }
}
