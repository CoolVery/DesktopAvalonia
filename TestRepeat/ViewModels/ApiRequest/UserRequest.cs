using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestRepeat.Models;

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
    }
}
