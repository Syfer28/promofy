using Microsoft.AspNetCore.Mvc;
using PROMHUB.Data;
using PROMHUB.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PROMHUB.Controllers

{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ImageService _imageService;

        public CompanyController(AppDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAsync()
        {
            var companies = await _context.Company.ToListAsync();
            // Обновляем URL изображений для каждой компании
            foreach (var company in companies)
            {
                company.Photo = _imageService.GetImageUrl(company.Photo);
            }
            return companies;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            // Обновляем URL изображения
            company.Photo = _imageService.GetImageUrl(company.Photo);
            return Ok(company);
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    companies.Remove(companies.SingleOrDefault(p => p.Id == id));
        //    return Ok();
        //}

        //[HttpPost]
        //public IActionResult Post([FromBody] Company newCompany)
        //{
        //    if (newCompany == null)
        //    {
        //        return BadRequest("Invalid data");
        //    }
        //    newCompany.Id = companies.Max(p => p.Id) + 1;
        //    companies.Add(newCompany);
        //    return CreatedAtAction(nameof(Get), new { id = newCompany.Id }, newCompany);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Company updatedCompany)
        //{
        //    if (updatedCompany == null)
        //    {
        //        return BadRequest("Invalid data");
        //    }
        //    var existingCompany = companies.SingleOrDefault(p => p.Id == id);
        //    if (existingCompany == null)
        //    {
        //        return NotFound();
        //    }
        //    // Обновляем данные компании
        //    existingCompany.Name = updatedCompany.Name;
        //    // Добавьте здесь обновление других свойств компании при необходимости
        //    return Ok(existingCompany);
        //}
    }
}
