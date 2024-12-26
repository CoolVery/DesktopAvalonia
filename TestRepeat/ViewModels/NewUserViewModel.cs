using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using TestRepeat.Models;
using TestRepeat.ViewModels.ApiRequest;
using TestRepeat.Views;

namespace TestRepeat.ViewModels
{
	public partial class NewUserViewModel : ViewModelBase
	{
		[ObservableProperty] User newUser = new User();
        [ObservableProperty] Logined newLogin = new Logined();
		[ObservableProperty] List<Gender> listGender;
        [ObservableProperty] List<Role> listRole;
        [ObservableProperty] bool isUserCreated = false;
        [ObservableProperty] Bitmap imgUser;
        [ObservableProperty] string passwordContent;

        DateTimeOffset birthDateNewUser = DateTimeOffset.MinValue;
        public DateTimeOffset BirthDateNewUser
        {
            get => birthDateNewUser;
            set
            {
                NewUser.BirthDate = new DateTime(value.Year, value.Month, value.Day);
            }
        }
        public NewUserViewModel()
		{
			listGender = MainWindowViewModel.Db_context.Genders.ToList();
            listRole = MainWindowViewModel.Db_context.Roles.ToList();
        }
        
        public async void CreateNewUserAndLogin()
		{
            Models.NewUser newUser = new Models.NewUser();
            
            NewLogin.Password = MD5.HashData(Encoding.ASCII.GetBytes(PasswordContent));
            
            newUser.User = NewUser;
            newUser.Logined = NewLogin;
            HttpResponseMessage response;
            response = await AddNewRequest.InsertNewUser(newUser);



        }
        public void BackToListUser()
        {
            MainWindowViewModel.Instance.Uc = new InfoUsersDate(MainWindowViewModel.Db_context.Users.ToList());
        }
        public void BackToAuth()
        {
            MainWindowViewModel.Instance.Uc = new Authorization();
        }
        public async void AddImgUser()
        {
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
                desktop.MainWindow?.StorageProvider is not { } provider)
                throw new NullReferenceException("Missing StorageProvider instance.");

            var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                Title = "Выберите файл с изображением пользователя",
                AllowMultiple = false
            });
            await using var readStream = await files[0].OpenReadAsync();
            byte[] buffer = new byte[10000000];
            var bytes = readStream.ReadAtLeast(buffer, 1);
            Array.Resize(ref buffer, bytes);
            NewUser.ImgUser = buffer;
            ImgUser = new Bitmap(new MemoryStream(buffer));
        }
    }

}