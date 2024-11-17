using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudOperations;
using CrudOperations.Models;

namespace CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuditLogsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AuditLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLog>>> GetauditLogs()
        {
            return await _context.auditLogs.ToListAsync();
        }
       
    }
}
