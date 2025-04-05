using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROMHUB.Data;
using PROMHUB.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace PROMHUB.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Shop>> GetAsync()
        {
            return await _context.Shop.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var distributor = await _context.Shop.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }
            return Ok(distributor);
        }
    }
}
