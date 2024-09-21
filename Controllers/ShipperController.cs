using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWS.Contexts;
using SalesWS.DTOs;

namespace SalesWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly StoreSampleContext _context;
        private readonly IMapper _mapper;

        public ShipperController(StoreSampleContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Shipper
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipperDTO>>> GetShippers()
        {
            var shipper = await _context.Shippers.ToListAsync();
            var shipperDTO = _mapper.Map<List<ShipperDTO>>(shipper);
            return shipperDTO;
        }

        //// GET: api/Shipper/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ShipperDTO>> GetShipper(int id)
        //{
        //    var shipper = await _context.Shippers.FindAsync(id);
        //    if (shipper == null)
        //    {
        //        return NotFound();
        //    }
        //    var shipperDTO = _mapper.Map<ShipperDTO>(shipper);
        //    return shipperDTO;
        //}

        //// PUT: api/Shipper/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutShipper(int id, Shipper shipper)
        //{
        //    if (id != shipper.Shipperid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(shipper).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ShipperExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Shipper
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Shipper>> PostShipper(Shipper shipper)
        //{
        //    _context.Shippers.Add(shipper);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetShipper", new { id = shipper.Shipperid }, shipper);
        //}

        //// DELETE: api/Shipper/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteShipper(int id)
        //{
        //    var shipper = await _context.Shippers.FindAsync(id);
        //    if (shipper == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Shippers.Remove(shipper);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ShipperExists(int id)
        {
            return _context.Shippers.Any(e => e.Shipperid == id);
        }
    }
}
