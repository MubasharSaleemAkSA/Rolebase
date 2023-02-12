using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using User.Context;
using User.Helpers;
using User.Models;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleActivitiesController : ControllerBase
    {
        private readonly UserDbContext _context;

        public RoleActivitiesController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/RoleActivities

        [HttpGet]
        public async Task<List<Permission>> GetRoleActivity()
        {
            List<Permission> users = new List<Permission>();
            var obj = from a in _context.Activities
                         join ra in _context.RoleActivity on a.activityid equals ra.activityid
                         into ar
                         from ara in ar.DefaultIfEmpty()
                         join r in _context.Role on ara.roleid equals r.roleid into rr
                         from rra in rr.DefaultIfEmpty()
                         

                         select new {
                             a.activityid, a.activityname,
                             ara.create, 
                             ara.read,
                              ara.update, 
                              ara.RAid,
                             ara.delete, 
                             rra.rolename,
                         rra.roleid};



            foreach (var item in obj)
            {
                users.Add(new Permission
                {
                    activityid = item.activityid,
                    activityname = item.activityname,
                    roleid = item.roleid,
                    rolename=item.rolename,
                    create = item.create,
                    update = item.update,
                    read = item.read,
                    RAid= item.RAid,
                    delete = item.delete,
                });
            }

            return users;
        }

      


        // POST: api/RoleActivities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoleActivity>> PostRoleActivity(RoleActivity roleActivity)
        {

         
            if (roleActivity == null)
            {

                return BadRequest(new {
                    Message = "Wrong Request"
                });



            }
            _context.RoleActivity.Add(roleActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoleActivity", new { id = roleActivity.RAid }, roleActivity);
        }
        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<RoleActivity>> PutRole(int id, RoleActivity roleActivity)
        {
            if (id==null)
            {
                return BadRequest();
            }

            _context.Entry(roleActivity).State = EntityState.Modified;
            await _context.SaveChangesAsync();



            return Ok(new
            {
                Message="Permission"
            }) ;
        }

        [HttpGet("{id}")]
        public async Task<List<Permission>> GetRoleByid(int id)
        {
              List<Permission> users = new List<Permission>();
              //var obj = from a in _context.Activities
              //          join ra in _context.RoleActivity on a.activityid equals ra.activityid
                        


              //          into ar
              //          from ara in ar.DefaultIfEmpty()
              //          join r in _context.Role on ara.roleid equals r.roleid into rr
              //          from rra in rr.DefaultIfEmpty()
                      

              //          select new
              //          {
              //              a.activityid,
              //              a.activityname,
              //              ara.create,
              //              ara.read,
              //              ara.update,
              //              ara.RAid,
              //              ara.delete,
              //              rra.rolename,
              //              rra.roleid
              //          };
            
              foreach (var item in obj)
              {
                  users.Add(new Permission
                  {
                      activityid = item.activityid,
                      activityname = item.activityname,
                      rolename = item.rolename,
                      create = item.create,
                      update = item.update,
                      read = item.read,
                      delete = item.delete,
                  });
              }

            return users ;
            
        }
    }
}
