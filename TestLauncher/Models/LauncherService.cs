using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestLauncher.Views.Pages;

namespace TestLauncher.Models
{
    internal class LauncherService : User
    {
        private const string ApiUrl = "https://example.com/api/users";

        public static async Task<User> GetUser(string username)
        {
            
            try
            {
                using (WebClient client = new WebClient())
                {
                    string apiUrl = $"{ApiUrl}/{username}";
                    string response = await client.DownloadStringTaskAsync(apiUrl);
                    User user = JsonConvert.DeserializeObject<User>(response);
                    return user;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed connect to API");
                return null;
            }
        }
    }

}

