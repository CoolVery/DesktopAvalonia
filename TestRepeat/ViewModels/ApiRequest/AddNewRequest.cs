using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestRepeat.Models;

namespace TestRepeat.ViewModels.ApiRequest
{
    public class AddNewRequest
    {
        public static async Task<HttpResponseMessage> InsertNewUser(NewUser newUser)
        {
            JsonContent jsonContent = JsonContent.Create(newUser);
            HttpResponseMessage httpResponseMessage = await MainWindowViewModel.Client.PostAsync("/newuser", jsonContent);
            return httpResponseMessage;
        }
    }
}
