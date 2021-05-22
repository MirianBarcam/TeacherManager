using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeacherManager.API.Models.Users;

namespace TeacherManager.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsers();
        Task<Users> GetUserDetails(string id);

        Task SaveUser(Users user);
        Task DeleteUser(string id);
    }
}
