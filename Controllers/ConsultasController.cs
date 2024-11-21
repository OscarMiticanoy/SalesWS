using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWS.Contexts;
using SalesWS.DTOs;

namespace SalesWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly StoreSampleContext _context;   

        public ConsultasController(StoreSampleContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesDatePrediction>>> GetSalesDatePrediction()
        {
            return await _context.Set<SalesDatePrediction>().ToListAsync();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Product>> InsertOrder(Order orden)
        //{
        //    var response = this._context.Database.clos.ExecuteSqlCommand();
        //    await _context.SaveChangesAsync();

        //   // return CreatedAtAction("GetProduct", new { id = product.Productid }, product);
        //}

    }
}
