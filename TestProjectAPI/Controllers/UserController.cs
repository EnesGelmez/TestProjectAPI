using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProjectAPI.Data;
using TestProjectAPI.Models;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace TestProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UsersDbContext _usersDbContext;

        public UserController(UsersDbContext usersDbContext)
        {
            this._usersDbContext = usersDbContext;
        }

        [HttpGet]
        [Route("hi")]
        public string SayHi()
        {
            try
            {
                throw new LobitekException();
            }
            catch (Exception ex)
            {

                throw;
            }
            return "Hi";
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usersDbContext.Users.ToListAsync());
        }

        [HttpGet]
        [Route("GetWorkers")]
        public async Task<IActionResult> GetWorkers()
        {
            return Ok(await _usersDbContext.Workers.ToListAsync());
        }

        [HttpGet]
        [Route("GetUser/{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            User user = await _usersDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<IActionResult> AddUsers(AddUserRequest addUserRequest)
        {

            User user = new User()
            {
                Id = Guid.NewGuid(),
                Address = addUserRequest.Address,
                Email = addUserRequest.Email,
                Name = addUserRequest.Name,
                Surname = addUserRequest.Surname,
                Phone = addUserRequest.Phone,
                Password = EncryptPassword.HashPassword(addUserRequest.Password),
            };
            await _usersDbContext.Users.AddAsync(user);
            await _usersDbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        [Route("UpdateUser/{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, AddUserRequest addUserRequest)
        {
            User user = await _usersDbContext.Users.FindAsync(id);
            if (user != null)
            {
                user.Name = addUserRequest.Name;
                user.Surname = addUserRequest.Surname;
                user.Phone = addUserRequest.Phone;
                user.Email = addUserRequest.Email;
                user.Address = addUserRequest.Address;
                user.Password = EncryptPassword.HashPassword(addUserRequest.Password);
                await _usersDbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("DeleteUser/{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            User user = await _usersDbContext.Users.FindAsync(id);
            if (user != null)
            {
                _usersDbContext.Remove(user);
                await _usersDbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<bool> Login([FromBody] LoginRequest loginRequest)
        {
            User user = null;
            if (!String.IsNullOrEmpty(loginRequest.Email))
                user = await _usersDbContext.Users.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
            else
                return false;
            if (user != null)
            {
                if (EncryptPassword.CheckPassword(loginRequest.Password, user.Password))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }


        }
    }
}
