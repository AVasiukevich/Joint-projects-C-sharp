using AccountDoors.Infrastructure;
using AccountDoors.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AccountDoors.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ModelDoor currentModelDoor;
        private ObservableCollection<ModelDoor> modelsDoors;
        public ModelDoor CurrentModelDoor
        {
            get
            {
                if (currentModelDoor == null)
                    currentModelDoor = new ModelDoor();
                return currentModelDoor;
            }
            set
            {
                currentModelDoor = value;
                OnPropertyChanged("CurrentModelDoor");
            }
        }

        public ObservableCollection<ModelDoor> ModelsDoors
        {
            get
            {
                if (modelsDoors == null)
                {
                    modelsDoors = ModelDoorRepository.Repository;
                }
                return modelsDoors;
            }
        }

        private RelayCommand addModelCommand;
        public ICommand addModel
        {
            get
            {
                if (addModelCommand == null)
                    addModelCommand = new RelayCommand(ExecuteAddModel, CanExecuteAddModel);
                return addModelCommand;
            }
        }
        public void ExecuteAddModel(object parameter)
        {
            ModelsDoors.Add(CurrentModelDoor);
            CurrentModelDoor = null;
        }
        public bool CanExecuteAddModel(object parameter)
        {
            if (String.IsNullOrEmpty(CurrentModelDoor.Name) || String.IsNullOrEmpty(CurrentModelDoor.Picture))
                return false;
            return true;
        }
        protected override void OnDispose()
        {
            this.ModelsDoors.Clear();
        }
    }
}
