namespace PROMHUB.Controllers
{
    public class CombinedDataCompanyDistributorProductTables
    {
        public ProductWithDistributorCompanuID Product { get; set; }
    }

    public class ProductWithDistributorCompanuID
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Photo { get; set; }
        public int Discount { get; set; }
        public int IdShop { get; set; }
        public int IdCompany { get; set; }
    }
}
