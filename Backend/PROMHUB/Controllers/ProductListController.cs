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
    public class ProductListController : Controller
    {
        private readonly AppDbContext _context;

        public ProductListController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductList>> GetAsync()
        {
            // Загружаем только базовые данные о записях ProductList без связанных сущностей User и Product
            return await _context.ProductList
                .Select(p => new ProductList
                {
                    Id = p.Id,
                    Quantity = p.Quantity,
                    UserId = p.UserId,
                    ProductId = p.ProductId
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            // Находим только нужную запись ProductList без связанных сущностей User и Product
            var distributor = await _context.ProductList
                .Where(p => p.Id == id)
                .Select(p => new ProductList
                {
                    Id = p.Id,
                    Quantity = p.Quantity,
                    UserId = p.UserId,
                    ProductId = p.ProductId
                })
                .FirstOrDefaultAsync();

            if (distributor == null)
            {
                return NotFound();
            }

            return Ok(distributor);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductListInputModel productListInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(productListInput.UserId);
            var product = await _context.Product.FindAsync(productListInput.ProductId);


            if (user == null || product == null)
            {
                return NotFound("User or product not found");
            }

            var newProductList = new ProductList
            {
                Quantity = productListInput.Quantity,
                UserId = productListInput.UserId,
                ProductId = productListInput.ProductId,
                User = user,
                Product = product,
            };

            _context.ProductList.Add(newProductList);
            await _context.SaveChangesAsync();

            return StatusCode(201, new
            {
                message = "Resource created successfully",
                id = newProductList.Id
            });
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var productList = await _context.ProductList.FindAsync(id);
            if (productList == null)
            {
                return NotFound();
            }

            _context.ProductList.Remove(productList);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
