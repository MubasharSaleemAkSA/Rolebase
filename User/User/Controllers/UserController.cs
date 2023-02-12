using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;
using User.Context;
using User.Helpers;
using User.Models;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _authcontext;
        public UserController(UserDbContext userDbContext)
        {

            _authcontext = userDbContext;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserData userobj)
        {
            if (userobj == null)

                return BadRequest();

            var user = await _authcontext.users.FirstOrDefaultAsync(x => x.email == userobj.email);
            var role = await _authcontext.Role.FirstOrDefaultAsync(x => x.roleid == user.Fid);

            if (user == null)
                return BadRequest(new
                { Message = "User Not Found" }); ;

            if (!PasswordHasher.VerifyPassword(userobj.password, user.password))
            {
                return BadRequest(new
                {
                    Message = "Password is incorrect"
                });
            }


            user.token = CreatJwt(user,role);
            
           
            return Ok(new
            {
                Token = user.token,
                Role = role.rolename,
                Message = "Login Success"
             
              
            }) ;

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserData userobj)
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
            userobj.password = PasswordHasher.HashPassword(userobj.password);

            await _authcontext.users.AddAsync(userobj);
              await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Register!"
            });
        }
        private async Task<bool> CheckEmailExistAsync(string Email)
        {
            return await _authcontext.users.AnyAsync(x => x.email == Email);
        }
       static private string CreatJwt(UserData user,Role role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
           
            var identity = new ClaimsIdentity(new Claim[]
            {
                
                   new Claim(ClaimTypes.Role,role.rolename),
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

        public async Task<List<JoinData>> GetAllUsers()
        {
            List<JoinData> users= new List<JoinData>(); 
            var obj = (from u in _authcontext.users
                       join rl in _authcontext.Role on u.Fid equals rl.roleid
                       select new
                       {
                           u.userid,
                           u.username,
                           u.date,
                           u.email,
                           rl.rolename
                       }).ToList();
            foreach (var item in obj)
            {
                users.Add(new JoinData
                {
                    username = item.username,
                    email = item.email,
                    date= item.date,
                    userid=item.userid,
                    role=item.rolename,
                });  
            }

            return users;
        }
        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserData>> GetUserData(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            return await _authcontext.users.FindAsync(id);


        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserData>> DeleteUserData(int id)
        {
            var data = await _authcontext.users.FindAsync(id);
            if (data == null)
            {
                return BadRequest(new
                {
                    Message = "Wrong Id"
                });
            }

            _authcontext.users.Remove(data);
            await _authcontext.SaveChangesAsync();

            return Ok(new
            {
                Message = "User delete"
            });

        }
        //update data

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserData(int id, [FromBody] UserData user)
        {


            if (id != user.userid)
            {

                return BadRequest(new
                {
                    Message = "User Not Found"
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
