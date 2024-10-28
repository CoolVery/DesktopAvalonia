using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using TestRepeat.Models;
using TestRepeat.Views;
using TestRepeat.Models;
using TestRepeat.ViewModels;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System;
using TestRepeat.ViewModels.AuthorizationViewModel;

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
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string path = Directory.GetCurrentDirectory();
            using SHA256Managed hash = new SHA256Managed();
            string nameFile = Regex.Replace(Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(userName))), @"[\/:*?""<>|]", "");
            string fullPath = path + "\\" + nameFile + ".bin";
            if (File.Exists(fullPath))
            {
                string[] loginAndPassword = AuthorizationVMAdditionalMethods.ReadFile(fullPath);
                if (loginAndPassword != null)
                {
                    AuthorizationViewModel.AuthorizationViewModel auth = new AuthorizationViewModel.AuthorizationViewModel(loginAndPassword[0], loginAndPassword[1]);
                }
                else
                {
                    string[] filePaths = System.IO.Directory.GetFiles(@path, "*.bin");
                    foreach (string file in filePaths) { 
                        File.Delete(file);
                    }
                }
            }
            else
            {
                string[] filePaths = System.IO.Directory.GetFiles(@path, "*.bin");
                foreach (string file in filePaths)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
