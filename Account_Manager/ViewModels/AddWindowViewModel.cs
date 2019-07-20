using Account_Manager.Models;
using Account_Manager.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Account_Manager.ViewModels {
    public class AddWindowViewModel : ViewModelBase, INotifyPropertyChanged {

        #region Fields
        private string _username;
        private string _password;
        private string _accountSource;
        private string _email;
        private string _additionalInfo;
        #endregion

        #region Exposed Properties
        public Account Account { get; set; }
        public RelayCommand<Window> AddAccountCommand { get; set; }
        
        
        public string Username {
            get {
                return _username;
            }
            set {
                if (_username != value) {
                    _username = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }
        public string Password {
            get {
                return _password;
            }
            set {
                if (_password != value) {
                    _password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }
        public string Email {
            get {
                return _email;
            }
            set {
                if (_email != value) {
                    _email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }
        public string AccountSource {
            get {
                return _accountSource;
            }
            set {
                if (_accountSource != value) {
                    _accountSource = value;
                    NotifyPropertyChanged("AccountSource");
                }
            }
        }
        public string AdditionalInfo {
            get {
                return _additionalInfo;
            }
            set {
                if (_additionalInfo != value) {
                    _additionalInfo = value;
                    NotifyPropertyChanged("AdditionalInfo");
                }
            }
        }
        #endregion

        #region Constructor
        public AddWindowViewModel() {
            Account = new Account();
            AddAccountCommand = new RelayCommand<Window>(AddNewAccount);
        }
        #endregion

        #region Commands
        public void AddNewAccount(Window window) {
            if (Account.AddAccount(this)) {
                Username = Password = Email = AccountSource = AdditionalInfo = string.Empty;
                window.Hide();
            } else {
                MessageBox.Show("Please fill the required entries");
            }
        }
        #endregion
    }
}
