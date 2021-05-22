using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherManager.API.Models.Users;

namespace TeacherManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    

    public class UsersController : Controller
    {
        private IUsersCollection db = new UsersCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await db.GetAllUsers());
        }


        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetUsersDetails(string id)
        {
            return Ok(await db.GetUsersById(id));
        }*/

        [HttpGet("{Email}")]
        public async Task<IActionResult> GetUsersDetailsByName(string email)
        {
            return Ok(await db.GetUsersByEmail(email));
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

        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsers([FromBody] Users user, string id) //Genero un usuario desde el Json de entrada
        {
            if (user == null)
                return BadRequest();
            if (user.Email == string.Empty)
            {
                ModelState.AddModelError("Email", "The user shouldn`t be empty");
            }


            user.Id = new MongoDB.Bson.ObjectId(id);  //le asigno el id que tiene de base de datos el usuario conrrespondiente al objeto que he creado en la entrada
            await db.UpdateUsers(user);
            return Created("Modificated User", true);
        }*/

        //genero un usuario desde el JSON de entrada
        //Le asigno el id que tiene de base de datos el usuario correcpondiente al objeto que he creado en la entrada
        //guardo el objeto de la entrada sustituyendo el existente

        /*
        1.me traigo el usuario de la base de datos
        2.Actualizo mi usuario de base de datos con los dato rellenos en el user que me viene
        3.Guardo el objeto de la entrada sustituyendo el existente
         */
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsers([FromBody] Users user, string id)
        {

            Users userBD = db.GetUsersById(id).Result; 
            if (string.IsNullOrEmpty(user.Email))
            {
                user.Email = userBD.Email;
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                user.Password = userBD.Password;
            }
            user.Id = id;
            await db.UpdateUsers(user);
            return Created("Modificated User", true);

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(string id)
        {
            await db.DeleteUsers(id);
            return NoContent();
        }
    }
}
