using CrudOperations.Data;
using CrudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Services
{
    public class AuditLogService
    {
        private readonly AppDbContext _context;

        public AuditLogService(AppDbContext context)
        {
            _context = context;
        }
        public async Task LogActionAsync(string userName, string action,string details)
        {
            _context.auditLogs.Add(new AuditLog
            {
                UserName = userName,
                Action = action,
                TimeStamp = DateTime.Now,
                Details=details
            });
            await _context.SaveChangesAsync();
        }
    }
}
