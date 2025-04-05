using System.Collections.Generic;
using System.Linq;
using global::PROMHUB.Data;
using PROMHUB.Data.Models;

namespace PROMHUB.Controllers
{
    public class ServiceClassDataCompanyDistributorProductTables
    {
        private readonly AppDbContext _context;
        private readonly ImageService _imageService; // Внедряем службу ImageService

        public ServiceClassDataCompanyDistributorProductTables(AppDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService; // Инициализируем службу ImageService
        }

        public IEnumerable<List<CombinedDataCompanyDistributorProductTables>> GetCombinedData()
        {
            var combinedData = (from product in _context.Product
                               join productShop in _context.ProductShop on product.Id equals productShop.ProductId
                               join shop in _context.Shop on productShop.ShopId equals shop.Id
                               join company in _context.Company on shop.CompanyId equals company.Id
                               join companyInfo in _context.CompanyInfo on company.Id equals companyInfo.CompanyId
                               select new CombinedDataCompanyDistributorProductTables
                               {
                                   Product = new ProductWithDistributorCompanuID
                                   {
                                       IdProduct = product.Id,
                                       Name = product.Name,
                                       Price = product.Price,
                                       Photo = _imageService.GetImageUrl(product.Photo),
                                       Discount = product.Discount,
                                       IdShop = shop.Id,
                                       IdCompany = company.Id
                                   }
                               }).ToList();

            var chunkSize = 5;
            var totalCount = combinedData.Count();
            var pages = (int)Math.Ceiling((double)totalCount / chunkSize);

            for (int i = 0; i < pages; i++)
            {
                yield return combinedData.Skip(i * chunkSize).Take(chunkSize).ToList();
            }
        }
    }
}

