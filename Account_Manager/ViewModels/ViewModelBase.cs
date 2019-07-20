using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account_Manager.ViewModels {
    public abstract class ViewModelBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName) {
            NotifyPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void NotifyPropertyChanged(PropertyChangedEventArgs args) {
            var handler = PropertyChanged;
            handler?.Invoke(this, args);
        }
    }
}
