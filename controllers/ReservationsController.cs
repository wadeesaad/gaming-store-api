using GamingStoreApi.Data;
using GamingStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace GamingStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ReservationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _context.Reservations
                .Join(
                    _context.Customers,
                    reservation => reservation.CustomerId,
                    customer => customer.Id,
                    (reservation, customer) => new
                    {
                        reservation.Id,
                        reservation.PlaceId,
                        reservation.StartTime,
                        reservation.EndTime,
                        reservation.TotalPrice,
                        reservation.Status,
                        reservation.CreatedAt,
                        reservation.UpdatedAt,
                        reservation.CustomerId,
                        CustomerName = customer.Name,
                        CustomerPhone = customer.Phone
                    }
                )
                .ToListAsync();

            return Ok(reservations);
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<IActionResult> CreateReservation(
            CreateReservationRequest request)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Phone == request.CustomerPhone);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = request.CustomerName,
                    Phone = request.CustomerPhone
                };

                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }

            var reservation = new Reservation
            {
                PlaceId = request.PlaceId,
                CustomerId = customer.Id,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                TotalPrice = request.TotalPrice,
                Status = "Booked",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}