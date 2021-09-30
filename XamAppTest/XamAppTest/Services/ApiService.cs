using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamAppTest.Models;
using Xamarin.Essentials;

namespace XamAppTest.Services
{
    class ApiService
    {
        public static async Task<bool> RegisterUser(string name, string email, string password)
        {
            var register = new Register()
            {
                Name = name,
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/accounts/register", content);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public static async Task<bool> Login(string email, string password)
        {
            var login = new Login()
            {
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/accounts/login", content);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.AccessToken);
            Preferences.Set("userId", result.UserId);
            Preferences.Set("userName", result.UserName);
            Preferences.Set("tokenExpirationTime", result.ExpirationTime);
            return true;
        }
    }
}
