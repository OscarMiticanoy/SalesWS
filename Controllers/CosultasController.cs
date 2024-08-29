using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWS.Contexts;
using SalesWS.DTOs;

namespace SalesWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CosultasController : ControllerBase
    {
        private readonly StoreSampleContext _context;   

        public CosultasController(StoreSampleContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesDatePrediction>>> GetSalesDatePrediction()
        {
            return await _context.Set<SalesDatePrediction>().ToListAsync();
        }

    }
}
