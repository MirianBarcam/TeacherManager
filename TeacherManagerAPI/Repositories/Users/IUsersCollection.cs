using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherManager.API.Models.Users
{
    interface IUsersCollection
    {
        Task InsertUsers(Users users);
        Task UpdateUsers(Users users);

        Task DeleteUsers(string id);
        Task<List<Users>> GetAllUsers();

        Task<Users> GetUsersById(string Id);
        Task<Users> GetUsersByEmail(string name);
    }
}
