using Microsoft.AspNetCore.Mvc;
using PROMHUB.Data.Models;
using System.Collections.Generic;

namespace PROMHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombinedDataCompanyDistributorProductTablesController : ControllerBase
    {
        private readonly ServiceClassDataCompanyDistributorProductTables _service;

        public CombinedDataCompanyDistributorProductTablesController(ServiceClassDataCompanyDistributorProductTables service)
        {
            _service = service;
        }

        // GET: api/CombinedData
        [HttpGet]
        public ActionResult<IEnumerable<CombinedDataCompanyDistributorProductTables>> GetCombinedData()
        {
            var combinedData = _service.GetCombinedData();
            return Ok(combinedData);
        }
    }
}
