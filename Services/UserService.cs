using CrudOperations.Data;
using CrudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsersAsync() => await _context.users.ToListAsync();

        public async Task<User> GetUserByIdAsync(int id)=> await _context.users.FindAsync(id);

        public async Task AddUserAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(User user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
