using Avalonia.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestRepeat.Models;

namespace TestRepeat.ViewModels.ApiRequest
{
    public class AuthRequest
    {
        public static async Task<Logined> AuthInSystem(string login, string password)
        {
            string route = string.Format("login/{0}/{1}", login, password);
            HttpResponseMessage message = await MainWindowViewModel.Client.GetAsync(route); // отправляем запрос к серверу
            string str = await message.Content.ReadAsStringAsync(); // считываем его
            Logined loginUser = JsonConvert.DeserializeObject<Logined>(str);
            return loginUser;
        }
    }
}
