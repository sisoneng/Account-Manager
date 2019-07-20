using Account_Manager.ViewModels;
using System.Windows;

namespace Account_Manager.Views {
    /// <summary>
    /// Interaction logic for MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window {
        public MasterWindow() {
            InitializeComponent();
            MasterUsername.Focus();
            DataContext = new MasteraccountViewModel();
        }

        private void MasterWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
