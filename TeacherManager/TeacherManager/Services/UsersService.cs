using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TeacherManager.API.Models.Users;


namespace TeacherManager.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httClient) 
        {
            _httpClient = httClient;
        }
        public async Task DeleteUser(string id)
        {
          await _httpClient.DeleteAsync($"api/users/{id}");
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Users>>
            (await _httpClient.GetStreamAsync($"api/users"),
            new JsonSerializerOptions(){PropertyNameCaseInsensitive = true });
        }

        public async Task<Users> GetUserDetails(string id)
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync<Users>
            (await _httpClient.GetStreamAsync($"api/users/{id}"),
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task SaveUser(Users user)
        {
            var userJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(user),
                Encoding.UTF8, "application/json");
            if (user.Id == string.Empty)
            {
                await _httpClient.PostAsync("api/product", userJson);
            }
            else
                await _httpClient.PutAsync($"api/users/{user.Id}", userJson);

            
        }
    }
}
