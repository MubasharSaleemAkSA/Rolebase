using EmpAuthApi.Context;
using EmpAuthApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using EmpAuthApi.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace EmpAuthApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EmpDbContext _authcontext;
        public UserController(EmpDbContext empDbContext)
        {

            _authcontext = empDbContext;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userobj)
        {
            if (userobj == null)

                return BadRequest();

            var user = await _authcontext.Users.FirstOrDefaultAsync(x => x.email == userobj.email);
            if (user == null)
                return BadRequest(new
                { Message = "User Not Found" }); ;

            if (!PasswordHaser.VerifyPassword(userobj.password, user.password))
            {
                return BadRequest(new
                {
                    Message = "Password is incorrect"
                });
            }


            user.token = CreatJwt(user);
            return Ok(new
            {
                Token = user.token,
                Message = "Login Success"
            });

        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userobj)
        {
            if (userobj == null)
            {

                return BadRequest();
            }
            //check Email
            if (await CheckEmailExistAsync(userobj.email))
            {
                return BadRequest(new
                {
                    Message = "Email Already Exist"
                });
            }
            userobj.password = PasswordHaser.HashPassword(userobj.password);
         
            await _authcontext.Users.AddAsync(userobj);
            await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Register!"
            });
        }
        private async Task<bool> CheckEmailExistAsync(string Email)
        {
            return await _authcontext.Users.AnyAsync(x => x.email == Email);
        }
        private string CreatJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
               
                 new Claim(ClaimTypes.Email,user.email),
                        new Claim(ClaimTypes.Name,user.username),

            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,

            };
            var Token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(Token);

        }
        [Authorize]
        [HttpGet]

        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authcontext.Users.ToListAsync());
        }
        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserData(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            return await _authcontext.Users.FindAsync(id);


        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserData(int id)
        {
            var data = await _authcontext.Users.FindAsync(id);
            if (data == null)
            {
                return BadRequest(new
                {
                    Message = "Wrong Id"
                });
            }
               
                _authcontext.Users.Remove(data);
            await _authcontext.SaveChangesAsync();

            return Ok(new
            {
                Message="User delete"
            });

        }
        //update data
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserData(int id, [FromBody] User user)
        {
             

            if (id != user.userid)
            {

                return BadRequest(new
                {
                    Message="User Not Found"
                });
            }

            _authcontext.Entry(user).State = EntityState.Modified;
            await _authcontext.SaveChangesAsync();
           

            return Ok(new
            {
                StatusCode = 200,
                Message = "User Updated "
            });
        }







    }
}

