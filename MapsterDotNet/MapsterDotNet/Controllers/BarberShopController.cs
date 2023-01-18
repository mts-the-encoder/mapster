using Mapster;
using MapsterDotNet.Data;
using MapsterDotNet.Entities;
using MapsterDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapsterDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarberShopController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarberShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BarberShopModel model)
        {
            var barberShop = model.Adapt<BarberShop>();
            _context.Add(barberShop);

            await _context.SaveChangesAsync();

            return Ok(barberShop);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var barberShops = await _context
                .BarberShops
                .ProjectToType<BarberShopModel>()
                .ToListAsync();

            return Ok(barberShops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _context
                .BarberShops
                .Where(x => x.Id == id)
                .ProjectToType<BarberShopResultModel>()
                .ToListAsync();

            return Ok(response);
        }
    }
}
