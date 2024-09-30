using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using TestRepeat.Views;

namespace TestRepeat.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty] UserControl uc = new Authorization();
        public static MainWindowViewModel Instance;
        public MainWindowViewModel()
        {
            Instance = this; // Задайте ссылку на себя
        }
    }
}
