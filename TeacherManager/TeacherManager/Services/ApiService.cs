using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeacherManager.API.Models.Users;
using TeacherManager.Models;

namespace TeacherManager.Services
{
    class ApiService
    {


         public async Task<Users> GetUser(
            string urlBase,
            string username)
         {
             try
             {
                 var client = new HttpClient();
                 client.BaseAddress = new Uri(urlBase);
                 var response = await client.GetAsync(username);
                 var resultJSON = await response.Content.ReadAsStringAsync();
                 Users result = JsonConvert.DeserializeObject<Users>(
                     resultJSON);
                 return result;
             }
             catch
             {
                 return null;
             }
         }






    }
}
