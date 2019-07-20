using Account_Manager.ViewModels;
using System.Windows;

namespace Account_Manager.Views {
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window {
        public SignUpWindow() {
            InitializeComponent();
            MasterUsernameTbox.Focus();
            DataContext = new SignUpWindowViewModel();
        }
    }
}
