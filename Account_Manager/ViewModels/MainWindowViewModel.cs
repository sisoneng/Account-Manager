using Account_Manager.Models;
using Account_Manager.ViewModels.Commands;
using Account_Manager.Views;
using System;
using System.Collections.ObjectModel;
using FontAwesome;
using System.Windows;

namespace Account_Manager.ViewModels {

    public class MainWindowViewModel : ViewModelBase {

        #region Fields
        private ObservableCollection<Account> accounts;
        #endregion
        #region Exposed Properties
        public Account Account { get; set; }
        /// <summary>
        /// Holds the list of account to be displayed
        /// </summary>
        public ObservableCollection<Account> Accounts {
            get { return accounts; }
            set {
                if (accounts != value) {
                    accounts = value;
                    NotifyPropertyChanged("Accounts");
                }
            }
        }
        public RelayCommand<MainWindowViewModel> LoadAddAccountWinCommand { get; set; }
        public RelayCommand<MainWindowViewModel> UpdateAccountListCommand { get; set; }
        public RelayCommand<MainWindowViewModel> AboutCommand { get; set; }
        public RelayCommand<MainWindowViewModel> GotFocusCommand { get; set; }
        public RelayCommand<Window> LogoutCommand { get; set; }
        #endregion

        #region Constructor
        public MainWindowViewModel() {
            LoadAddAccountWinCommand = new RelayCommand<MainWindowViewModel>(param => LoadAddAccountWin());
            UpdateAccountListCommand = new RelayCommand<MainWindowViewModel>(param => UpdateAccountList());
            AboutCommand = new RelayCommand<MainWindowViewModel>(param => LoadAboutWindow());
            GotFocusCommand = new RelayCommand<MainWindowViewModel>(param => GotFocus());
            LogoutCommand = new RelayCommand<Window>(Logout);
            Account = new Account();
            Accounts = Account.LoadAccounts();
        }
        #endregion

        #region Commands
        public void LoadAddAccountWin() {
            AddAccountWindow AddAccWin = new AddAccountWindow();
            AddAccWin.Show();
        }
        public void UpdateAccountList() {
            Accounts.Clear();
            Account.LoadAccounts();
            Accounts = Account.Accounts;
        }
        public void LoadAboutWindow() {
            AboutWindow about = new AboutWindow();
            about.Show();
        }
        private void GotFocus()
        {
            Accounts = null;
            Account.LoadAccounts();
            Accounts = Account.Accounts;
        }
        public void Logout(Window window) {
            window.Hide();
            MasterWindow masterwindow = new MasterWindow();
            masterwindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            masterwindow.Show();
            CurrentSession.SessionMasterUsername = null;
        }
        #endregion
    }
}