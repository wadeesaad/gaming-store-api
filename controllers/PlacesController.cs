using GamingStoreApi.Data;
using GamingStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlacesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {
            return await _context.Places.ToListAsync();
        }
    }
}