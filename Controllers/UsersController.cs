using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudOperations.Models;
using Microsoft.AspNetCore.Authorization;
using CrudOperations.Data;
using CrudOperations.Services;

namespace CrudOperations.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userservice;
        private readonly AuditLogService _auditlogservice;

        public UsersController(UserService userservice, AuditLogService auditlogservice)
        {
            _userservice = userservice;
            _auditlogservice = auditlogservice;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers() => Ok(await _userservice.GetAllUsersAsync());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) => Ok(await _userservice.GetUserByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userservice.AddUserAsync(user);
            await _auditlogservice.LogActionAsync(user.UserName, "Created", "User created");
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            await _userservice.UpdateUserAsync(user);
            await _auditlogservice.LogActionAsync(user.UserName, "Updated", "User updated");
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userservice.GetUserByIdAsync(id);
            if (user != null)
            {
                //No Delete provision for Admin Users
                if (user.Role == "Admin")
                {
                    return BadRequest("No delete option for Admin users");
                }
                else
                    await _userservice.DeleteUserAsync(id);
                await _auditlogservice.LogActionAsync(user.UserName, "Deleted", "User Deleted");
            }
            return NoContent();
        }
    }
}
