using Account_Manager.Models;

namespace Account_Manager.ViewModels {
    public class AboutWindowViewModel : ViewModelBase {

        public string TextSource { get; set; }
        public AboutWindowViewModel() {
            TextSource = "Version 1.0.0";
        }

    }
}
