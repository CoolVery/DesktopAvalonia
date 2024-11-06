using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestRepeat.Models;
using TestRepeat.Views;

namespace TestRepeat.ViewModels
{
    public partial class DateUserViewModel : ViewModelBase
    {
        [ObservableProperty] User userForPage;
        [ObservableProperty] string dateString;
        [ObservableProperty] List<Gender> genders;
        [ObservableProperty] bool isAdmin = false;
        [ObservableProperty] Bitmap imgUser;
        [ObservableProperty] List<Threat> idThreats;
        [ObservableProperty] bool isCanDeleteThreat = false;
        [ObservableProperty] Threat selectedItem;
        [ObservableProperty] List<Threat> idNotThreats;
        [ObservableProperty] Threat selectedThreat;
        public DateUserViewModel() { }
        public DateUserViewModel(User user)
        {
            idNotThreats = MainWindowViewModel.Db_context.Threats.ToList().Except(user.IdThreats).ToList();
            userForPage = user;
            genders = MainWindowViewModel.Db_context.Genders.ToList();
            dateString = userForPage.BirthDate.ToString();
            IdThreats = user.IdThreats.ToList();
            imgUser = new Bitmap(new MemoryStream(user.ImgUser));
            if (InfoUsersDate.CurrentUser != null)
            {
                isAdmin = true;
            }
        }
        public async void ChangeImg()
        {
            if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
                desktop.MainWindow?.StorageProvider is not { } provider)
                throw new NullReferenceException("Missing StorageProvider instance.");

            var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                Title = "Выберите файл с изображением пользователя",
                AllowMultiple = false
            });
            if (files.Count == 0)
            {

                return;
            }
            await using var readStream = await files[0].OpenReadAsync();
            byte[] buffer = new byte[10000000];
            var bytes = readStream.ReadAtLeast(buffer, 1);
            Array.Resize(ref buffer, bytes);
            UserForPage.ImgUser = buffer;
            ImgUser = new Bitmap(new MemoryStream(buffer));
        }
        public void SaveChange()
        {
            MainWindowViewModel.Db_context.SaveChanges();
        }
        public DateTimeOffset NewDate
        {
            get => new DateTimeOffset((DateTime)UserForPage.BirthDate, TimeSpan.Zero);
            set
            {
                UserForPage.BirthDate = new DateTime(value.Year, value.Month, value.Day);
                DateString = value.ToString();
            }
        }
        public void BackToAuth()
        {
            InfoUsersDate.CurrentUser = null;

            MainWindowViewModel.Instance.Uc = new Authorization();
        }
        public void BackToListUser()
        {
            MainWindowViewModel.Instance.Uc = new InfoUsersDate(MainWindowViewModel.Db_context.Users.ToList());
        }
        public void DeleteThreatUser()
        {
            if (SelectedItem != null)
            {
                
                UserForPage.IdThreats.Remove(SelectedItem);
                SaveChange();
                MainWindowViewModel.Instance.Uc = new DateUser(UserForPage);
            }
            else
            {
                IsCanDeleteThreat = true;
            }
        }
        public void AddThreat()
        {
            if (SelectedThreat != null)
            {
                UserForPage.IdThreats.Add(SelectedThreat);
                SaveChange();
                MainWindowViewModel.Instance.Uc = new DateUser(UserForPage);
            }
        }
    }
}