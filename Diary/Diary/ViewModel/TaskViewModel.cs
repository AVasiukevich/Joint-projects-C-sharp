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

namespace Diary.ViewModel
{
    public class TaskViewModel : ViewModelBase
    {
        private MyTask _selectedTask;
        private SubTaskViewModel _subTaskVM;
        private SubTask _selectedSubTask;

        public SubTask SelectedSubTask
        {
            get
            {
                return _selectedSubTask;
            }
            set
            {
                _selectedSubTask = value;
                OnPropertyChanged();
            }
        }
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
        public MyTask SelectedTask
        {
            get
            {
                return _selectedTask;
            }
            set
            {
                _selectedTask = value;               
                OnPropertyChanged();
            }
        }
        
        private RelayCommand _changeReady;
        public ICommand ChangeReady
        {
            get
            {
                if (_changeReady == null)
                    _changeReady = new RelayCommand(ExecuteChangeReady);
                return _changeReady;
            }
        }
        private void ExecuteChangeReady(object parameter)
        {
            var image = parameter as Image;
            if (image != null && ReferenceEquals(image.Source, ImagesReady.Ready))
                image.Source = ImagesReady.Unready;
            else
                image.Source = ImagesReady.Ready;

            SelectedTask.RefreshOfCompletion();
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
            if (_window.ShowDialog() == true)
            {
                SelectedTask.List_subTasks.Add(_subTaskVM.СurrentSubTask);
                _subTaskVM.СurrentSubTask = null;
            }
        }

        private RelayCommand _deleteSubTask;
        public ICommand DeleteSubTask
        {
            get
            {
                if (_deleteSubTask == null)
                    _deleteSubTask = new RelayCommand(ExecuteDeleteSubTask, CanExecuteDeleteSubTask);
                return _deleteSubTask;
            }
        }
        private bool CanExecuteDeleteSubTask(object obj)
        {
            if (_selectedSubTask == null)
                return false;
            return true;
        }
        private void ExecuteDeleteSubTask(object obj)
        {
            SelectedTask.List_subTasks.Remove(_selectedSubTask);
        }

        private RelayCommand _editSubTask;
        public ICommand EditSubTask
        {
            get
            {
                if (_editSubTask == null)
                    _editSubTask = new RelayCommand(ExecuteEditSubTask, CanExecuteEditSubTask);
                return _editSubTask;
            }
        }
        private bool CanExecuteEditSubTask(object obj)
        {
            if (_selectedSubTask == null)
                return false;
            return true;
        }
        private void ExecuteEditSubTask(object obj)
        {
            SubTaskWindow _window = new SubTaskWindow();
            SubTaskVM.СurrentSubTask = _selectedSubTask;
            _window.DataContext = SubTaskVM;
            if (_window.ShowDialog() == true)
            {
                _subTaskVM.СurrentSubTask = null;
            }
        }

        private RelayCommand _editTask;
        public ICommand EditTask
        {
            get
            {
                if (_editTask == null)
                    _editTask = new RelayCommand(ExecuteEditTask);
                return _editTask;
            }
        }
        private void ExecuteEditTask(object parameter)
        {
            TaskWindow _window = parameter as TaskWindow;
            if(_window != null)
            {
                GroupItem control = _window.FindName("grp_items") as GroupItem;
                ControlTemplate template = _window.FindResource("edit_task_template") as ControlTemplate;
                if(control != null && template != null)
                {
                    control.Template = template;
                }
            }
        }
    }
}
