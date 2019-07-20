using Account_Manager.Models;
using Account_Manager.ViewModels.Commands;
using System.Windows;

namespace Account_Manager.ViewModels {
    public class SignUpWindowViewModel : ViewModelBase {

        #region Fields
        private string _signupmasteruser;
        private string _signupmasterpass;
        private MasterAccount MasterAccount { get; set; }
        #endregion

        #region Exposed Properties
        public interface ICloseable {
            void Close();
        }
        public string SignUp_MasterUsername {
            get {
                return _signupmasteruser;
            }
            set {
                if (_signupmasteruser != value) {
                    _signupmasteruser = value;
                    NotifyPropertyChanged("Signup_MasterUsername");
                }
            }
        }
        public string SignUp_MasterPassword {
            get {
                return _signupmasterpass;
            }
            set {
                if (_signupmasterpass != value) {
                    _signupmasterpass = value;
                    NotifyPropertyChanged("SignUp_MasterPassword");
                }
            }
        }
        public RelayCommand<Window> SignUpCommand { get; set; }
        #endregion

        #region Constructor
        public SignUpWindowViewModel() {
            SignUpCommand = new RelayCommand<Window>(SignUp);
        }
        #endregion

        #region Commands
        public void SignUp(Window window) {
            MasterAccount = new MasterAccount();
            if (MasterAccount.IsAddMasterAccountSuccess(this)) {
                MessageBox.Show("Successful");
                window.Close();
            } else {
                MessageBox.Show("Failed to register");
            }
        }
        #endregion
    }
}
