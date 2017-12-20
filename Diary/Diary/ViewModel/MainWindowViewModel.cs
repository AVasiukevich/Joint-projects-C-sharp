using Diary.Infrastructure;
using Diary.Model;
using Diary.Parser;
using Diary.Parser.habrahabr;
using Diary.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diary.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region NEWS

        ObservableCollection<New> _news;
        ParserWorker<string[]> _parser = new ParserWorker<string[]>(new ParserHabra());
        private RelayCommand _showNews;

        public ObservableCollection<New> News
        {
            get
            {
                if (_news == null)
                    _news = new ObservableCollection<New>();
                return _news;
            }
        }

        public ICommand ShowNews
        {
            get
            {
                if (_showNews == null)
                    _showNews = new RelayCommand(ExecuteAddModel, CanExecuteAddModel);
                return _showNews;
            }
        }

        public void ExecuteAddModel(object parameter)
        {
            _parser.OnCompleted += Parser_OnCompleted;
            _parser.OnNewData += Parser_OnNewData;
            _parser.Settings = new SettingsHabra(1, 2);
            _parser.Start();
        }

        public bool CanExecuteAddModel(object parameter)
        {
            return true;
        }
        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (var item in arg2)
            {
                News.Add(new New(item));
            }
        }
        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }
        #endregion
        #region MY_TASKS
        private DateTime _selectedData;
        public DateTime SelectedData
        {
            get
            {
                if (_selectedData == DateTime.MinValue)
                    _selectedData = DateTime.Today;
                return _selectedData;
            }
            set
            {
                _selectedData = value;
                OnPropertyChanged();
            }
        }

        private AddTaskViewModel _addTaskVM;
        public AddTaskViewModel AddTaskVM
        {
            get
            {
                if (_addTaskVM == null)
                    _addTaskVM = new AddTaskViewModel();
                return _addTaskVM;
            }

            set
            {
                _addTaskVM = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MyTask> _list_tasks;
        public ObservableCollection<MyTask> List_tasks
        {
            get
            {
                if (_list_tasks == null)
                    _list_tasks = MyTaskRepository.Repository;
                return _list_tasks;
            }
            set
            {
                _list_tasks = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addTask;
        public ICommand AddTask
        {
            get
            {
                if (_addTask == null)
                    _addTask = new RelayCommand(ExecuteAddTsk, CanExecuteAddTask);
                return _addTask;
            }
        }


        private bool CanExecuteAddTask(object parameter)
        {
            return true;
        }
        private void ExecuteAddTsk(object parameter)
        {
            AddTaskWindow add_window = new AddTaskWindow();
            AddTaskVM.CurrentTask.DateStart = SelectedData;
            add_window.DataContext = AddTaskVM;
            if(add_window.ShowDialog() == true)
            {
                List_tasks.Add(AddTaskVM.CurrentTask);
                AddTaskVM.CurrentTask = null;
            }

            //string test = "";
            //foreach (var item in List_tasks)
            //{
            //    test += item.ToString() + " ";
            //}
            //MessageBox.Show(test);
        }

        #endregion
        protected override void OnDispose()
        {
            
        }
    }
}
