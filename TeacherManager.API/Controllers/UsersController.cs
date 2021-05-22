using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherManager.API.Models.Users;

namespace TeacherManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : Controller
    {
        private IUsersCollection db = new UsersCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await db.GetAllUsers());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersDetails(string id)
        {
            return Ok(await db.GetUsersById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers([FromBody] Users user)
        {
            if (user == null)
                return BadRequest();
            if (user.Email == string.Empty)
            {
                ModelState.AddModelError("Name", "The user shouldn`t be empty");
            }
            if (user.Password == string.Empty)
            {
                ModelState.AddModelError("Password", "The password shouldn`t be empty");
            }


            await db.InsertUsers(user);
            return Created("Login created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsers([FromBody] Users user, string id)
        {
            if (user == null)
                return BadRequest();
            if (user.Email == string.Empty)
            {
                ModelState.AddModelError("Email", "The user shouldn`t be empty");
            }


            user.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateUsers(user);
            return Created("Modificated User", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(string id)
        {
            await db.DeleteUsers(id);
            return NoContent();//todo salío bien en el borrado
        }
    }
}
