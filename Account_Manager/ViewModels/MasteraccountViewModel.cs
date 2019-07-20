using Account_Manager.Models;
using Account_Manager.ViewModels.Commands;
using Account_Manager.Views;
using System.Windows;

namespace Account_Manager.ViewModels {
    public class MasteraccountViewModel : ViewModelBase {

        #region Exposed Properties  
        /// <summary>
        /// Properties that is accessible to the View
        /// </summary>
        public MasterAccount MA { get; }
        public RelayCommand<MasteraccountViewModel> ValidateCommand { get; set; }

        public RelayCommand<MasteraccountViewModel> LoadSignWinCommand { get; set; }

        private string _credUsername;
        private string _credPassword;
        private string _visibility = "Visible";

        public string Visibility {
            get {
                return _visibility;
            }
            set {
                _visibility = value;
                NotifyPropertyChanged("Visibility");
            }
        }

        public string CredUsername {
            get { return _credUsername; }
            set {
                if (_credUsername != value) {
                    _credUsername = value;
                    NotifyPropertyChanged("InputUsername");
                }
            }
        }
        public string CredPassword {
            get { return _credPassword; }
            set {
                if (_credPassword != value) {
                    _credPassword = value;
                    NotifyPropertyChanged("InputPassword");
                }
            }
        }
        #endregion

        #region Constructor
        public MasteraccountViewModel() {
            MA = new MasterAccount();
            ValidateCommand = new RelayCommand<MasteraccountViewModel>(param => Validate(), param => IsLogInAvail());
            LoadSignWinCommand = new RelayCommand<MasteraccountViewModel>(param => LoadSignUpWin());
        }
        #endregion

        #region Commands 
        public void LoadSignUpWin() {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
        }

        public bool IsLogInAvail() {
            return !string.IsNullOrWhiteSpace(_credUsername) && !string.IsNullOrWhiteSpace(_credPassword);
        }

        private void Validate() {
            MA.GetMasterAccount(CredUsername, CredPassword);
            if (MA.IsLoginSuccess()) {
                Visibility = "Hidden";
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            } else {
                MessageBox.Show("Login Fail");
            }
        }
        #endregion
    }
}
