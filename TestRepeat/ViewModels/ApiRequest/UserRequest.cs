using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestRepeat.Models;
using TestRepeat.Views;

namespace TestRepeat.ViewModels.ApiRequest
{
    internal class UserRequest
    {
        public static async Task<User> GetUser(int id)
        {
            string route = string.Format("login/{0}", id);
            HttpResponseMessage message = await MainWindowViewModel.Client.GetAsync(route); // отправляем запрос к серверу
            string str = await message.Content.ReadAsStringAsync(); // считываем его
            User user = JsonConvert.DeserializeObject<User>(str);
            return user;
        }

        public static async Task<List<User>> GetAllUser()
        {
            string route = string.Format("users");
            HttpResponseMessage message = await MainWindowViewModel.Client.GetAsync(route); // отправляем запрос к серверу
            string str = await message.Content.ReadAsStringAsync(); // считываем его
            List<User> user = JsonConvert.DeserializeObject<List<User>>(str);
            return user;
        }

        public static async Task<HttpResponseMessage> DeleteUser(User user)
        {
            JsonContent jsonContent = JsonContent.Create(user);
            string json = string.Format("deleteUser/{0}", jsonContent);
            HttpResponseMessage message = await MainWindowViewModel.Client.DeleteAsync("deleteUser"); // отправляем запрос к серверу
            return message;

        }
    }
}
