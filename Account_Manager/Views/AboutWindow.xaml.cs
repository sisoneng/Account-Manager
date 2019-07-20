using Account_Manager.ViewModels;
using System.Windows;

namespace Account_Manager.Views {
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window {
        public AboutWindow() {
            InitializeComponent();
            DataContext = new AboutWindowViewModel();
        }
    }
}
