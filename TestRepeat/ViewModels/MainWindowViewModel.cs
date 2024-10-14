using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using TestRepeat.Models;
using TestRepeat.Views;
using TestRepeat.Models;

namespace TestRepeat.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] UserControl uc = new Authorization();
        public static MainWindowViewModel Instance;
        public static _41pKyklevContext Db_context;
        public MainWindowViewModel()
        {
            Instance = this;
            Db_context = new _41pKyklevContext();
            Initialize();
        }
        private void Initialize()
        {

        }
    }
}
