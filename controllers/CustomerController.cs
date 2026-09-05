using GamingStoreApi.Data;
using GamingStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers/phone/71123456
        [HttpGet("phone/{phone}")]
        public async Task<ActionResult<Customer>> GetCustomerByPhone(string phone)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Phone == phone);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Phone == customer.Phone);

            if (existingCustomer != null)
            {
                return Ok(existingCustomer);
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCustomerByPhone),
                new { phone = customer.Phone },
                customer
            );
        }
    }
}