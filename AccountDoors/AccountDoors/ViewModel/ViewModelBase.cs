using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDoors.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged , IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName)); //[CallerMemberName]string propertyName = ""
            }
        }

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {}
    }
}
