using Account_Manager.ViewModels;
using System.Windows;

namespace Account_Manager.Views {

    /// <summary>
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window {

        public AddAccountWindow() {
            InitializeComponent();
            Username.Focus();
            DataContext = new AddWindowViewModel();
        }
    }
}