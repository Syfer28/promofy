using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROMHUB.Data;
using PROMHUB.Data.Models;

namespace PROMHUB.Controllers
{
    [Route("api/[controller]")]
    
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var distributor = await _context.Users.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }
            return Ok(distributor);
        }
    }
}
