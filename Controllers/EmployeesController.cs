using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWS.Contexts;
using SalesWS.DTOs;

namespace SalesWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly StoreSampleContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(StoreSampleContext context, IMapper _mapper)
        {
            this._context = context;
            this._mapper = _mapper;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employee = await _context.Employees.ToListAsync();
            var employeeDTO = _mapper.Map<List<EmployeeDTO>>(employee);
            return employeeDTO;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Empid)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Empid }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Empid == id);
        }
    }
}
